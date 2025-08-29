using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDoor : MonoBehaviour, IInteractible
{
    public Action OnEnter;

    [SerializeField] Transform Player, End;
    [SerializeField] List<CookieCrook> Crooks = new(); 

    public void Interact()
    {
        if(Crooks.Count <= 0)
        {
            Player.position = End.position;
            OnEnter?.Invoke();
        }
        else
        {
            //display lock
            Debug.Log("KILL THEM ALL!");
        }
    }
}
