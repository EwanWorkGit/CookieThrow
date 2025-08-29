using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipPlayer : MonoBehaviour
{
    public bool IsPlaying;
    public AudioClip[] Clips;

    [SerializeField] AudioSource AudioPlayer;

    private void Update()
    {
        IsPlaying = AudioPlayer.isPlaying;
    }

    public void PlayClip(int index)
    {
        AudioPlayer.clip = Clips[index];
        AudioPlayer.Play();
    }
}
