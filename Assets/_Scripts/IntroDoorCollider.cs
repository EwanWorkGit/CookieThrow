using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroDoorCollider : MonoBehaviour
{
    [SerializeField] ExplosiveCookie Cookie;

    private void Awake()
    {
        Cookie.OnInteraction += UnblockDoor;
    }

    void UnblockDoor()
    {
        Cookie.OnInteraction -= UnblockDoor;
        Destroy(gameObject);
    }
}
