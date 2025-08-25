using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveCookie : MonoBehaviour, IInteractible
{
    //player looks for IInteractible and interacts via the interaface, needs to hold a ref to player because of action
    public void Interact()
    {
        Debug.Log("You interacted with " + transform.name);
        gameObject.SetActive(false);
    }
}
