using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveCookie : MonoBehaviour, IInteractible
{
    public Action OnInteraction;

    public void Interact()
    {
        Debug.Log("You interacted with " + transform.name);
        OnInteraction?.Invoke();
        gameObject.SetActive(false);
    }
}
