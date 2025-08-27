using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Damage = 35f;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.TryGetComponent(out HealthHandler hpHandler))
        {
            if(hpHandler.Health > 0)
            {
                hpHandler.Health -= Damage;
            }
        }
        Destroy(gameObject);
    }
}
