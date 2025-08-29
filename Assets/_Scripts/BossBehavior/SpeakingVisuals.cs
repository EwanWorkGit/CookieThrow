using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeakingVisuals : MonoBehaviour
{
    public ClipPlayer SoundPlayer;

    public GameObject[] Expressions;

    public float Duration = 0.3f;

    public bool ShouldSpeak;
    public bool IsSpeaking;

    int Index;

    private void Update()
    {
        ShouldSpeak = SoundPlayer.IsPlaying;

        if(!IsSpeaking && ShouldSpeak)
        {
            StartCoroutine(LoopExpressions());
        }
        else if(!ShouldSpeak)
        {
            ReturnToSmile();
        }
    }

    IEnumerator LoopExpressions()
    {
        IsSpeaking = true;

        foreach(GameObject expression in Expressions)
        {
            if(expression == Expressions[Index])
            {
                expression.SetActive(true);
            }
            else
            {
                expression.SetActive(false);
            }
        }

        if(Index + 1 < Expressions.Length)
        {
            Index++;
        }
        else
        {
            Index = 0;
        }

        yield return new WaitForSeconds(Duration);

        IsSpeaking = false;
    }

    void ReturnToSmile()
    {
        foreach(GameObject expression in Expressions)
        {
            if(expression == Expressions[0])
            {
                expression.SetActive(true);
            }
            else
            {
                expression.SetActive(false);
            }
        }
    }
}
