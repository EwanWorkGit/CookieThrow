using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHandler : MonoBehaviour
{
    public float Health;

    DeathHandler _DeathHandler;

    private void Start()
    {
        _DeathHandler = DeathHandler.Instance;
    }

    private void Update()
    {
        if(Health <= 0)
        {
            if(!_DeathHandler.IsDead)
            {
                _DeathHandler.KillPlayer();
            }
        }
    }
}
