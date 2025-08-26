using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDoor : MonoBehaviour, IInteractible
{
    [SerializeField] Transform Player, End;

    public void Interact()
    {
        Player.position = End.position;
        Debug.Log("TP:d!");

        //add rotation
    }
}
