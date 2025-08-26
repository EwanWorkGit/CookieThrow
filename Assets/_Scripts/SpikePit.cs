using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikePit : MonoBehaviour
{
    DeathHandler _DeathHandler;

    void Start()
    {
        _DeathHandler = DeathHandler.Instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(_DeathHandler != null)
        {
            _DeathHandler.KillPlayer();
        }
    }
}
