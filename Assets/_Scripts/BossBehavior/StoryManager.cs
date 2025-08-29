using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    [SerializeField] ClipPlayer AudioHandler;
    [SerializeField] Animator PedistalAnimator;
    [SerializeField] ExplosiveCookie Cookie;
    [SerializeField] DefaultDoor Door;
    [SerializeField] SpeakCollider SpeakCollider;
    [SerializeField] SpeakCollider SpeakColliderExit;
    [SerializeField] DefaultDoor EnemyDoor;
    [SerializeField] EndDoor EndDoor;

    [SerializeField] int Index = 0;

    bool PlayedSpikeDialog, PlayedSpikeDialogTwo;

    private void Start()
    {
        Cookie.OnInteraction += CookieAudio;
        Door.OnEnter += DoorAudio;
        EnemyDoor.OnEnter += EnemyDoorAudio;
        EndDoor.OnEnter += NOOOOAudio;

        AudioHandler.PlayClip(0);
        StartCoroutine(FirstSegment());

        Index++;
    }

    IEnumerator FirstSegment()
    {
        yield return new WaitWhile(() => AudioHandler.IsPlaying);
        PedistalAnimator.SetTrigger("FirstLineDone");
        AudioHandler.PlayClip(1);

        Index++;
    }

    void CookieAudio()
    {
        Cookie.OnInteraction -= CookieAudio;

        AudioHandler.PlayClip(2);
        Index++;
    }

    void DoorAudio()
    {
        Door.OnEnter -= DoorAudio;

        AudioHandler.PlayClip(3);
        Index++;
    }

    private void Update()
    {
        if(!PlayedSpikeDialog && Index >= 4 && SpeakCollider.EnteredCollider)
        {
            PlayedSpikeDialog = true;

            AudioHandler.PlayClip(4);
            Index++;
        }

        if(!PlayedSpikeDialogTwo && Index >= 5 &&  SpeakColliderExit.EnteredCollider)
        {
            PlayedSpikeDialogTwo = true;

            AudioHandler.PlayClip(5);
            Index++;
        }
    }

    void EnemyDoorAudio()
    {
        EnemyDoor.OnEnter -= EnemyDoorAudio;

        AudioHandler.PlayClip(6);
        Index++;
    }

    void NOOOOAudio()
    {
        EndDoor.OnEnter -= NOOOOAudio;
        AudioHandler.PlayClip(7);
        Index++;
    }
}
