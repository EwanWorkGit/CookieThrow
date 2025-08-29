using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySync : MonoBehaviour
{
    [SerializeField] CookieCrook[] Crooks;
    [SerializeField] Animator[] Animators;
    [SerializeField] DefaultDoor EnemyDoor;
    [SerializeField] CameraMovement CamMove;


    private void Start()
    {
        EnemyDoor.OnEnter += TriggerAnimate;
    }

    void TriggerAnimate()
    {
        Debug.Log("Animation started.");
        StartCoroutine(Animate());
    }

    IEnumerator Animate()
    {
        yield return new WaitForSeconds(1f);
        Animators[0].SetTrigger("LeftTurn");
        Animators[1].SetTrigger("RightTurn");
        yield return new WaitForSeconds(2f);

        foreach (CookieCrook crook in Crooks)
        {
            crook.ChangeExpression(1);
        }

        yield return new WaitForSeconds(1f);
        foreach(Animator animator in Animators)
        {
            animator.enabled = false;
        }

        CamMove.Animator.SetTrigger("EnemyConvoFinished");
    }
    

    
}
