using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultDoor : MonoBehaviour, IInteractible
{
    public Action OnEnter;

    [SerializeField] float Force = 40f;

    Rigidbody Rb;

    void Start()
    {
        Rb = GetComponent<Rigidbody>();
    }

    public void Interact()
    {
        Debug.Log("Interacted with " + transform.name);
        Rb.isKinematic = false;
        Rb.AddForce(transform.forward * Force, ForceMode.Impulse);
        OnEnter?.Invoke();
    }
}
