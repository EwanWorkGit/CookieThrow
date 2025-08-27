using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDoor : MonoBehaviour, IInteractible
{
    [SerializeField] Transform Player, End;
    [SerializeField] List<CookieCrook> Crooks = new(); 

    public void Interact()
    {
        if(Crooks.Count <= 0)
        {
            Player.position = End.position;
        }
        else
        {
            //display lock
            Debug.Log("KILL THEM ALL!");
        }
    }
}
