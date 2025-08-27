using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieCrook : MonoBehaviour
{
    public float Health = 100f;

    [SerializeField] DefaultDoor Door;
    [SerializeField] GameObject BulletPrefab;
    [SerializeField] Transform Player, BulletOrigin;
    [SerializeField] CameraMovement CamMovement;

    [SerializeField] float FireDelay = 0.1f, BulletForce = 45f, ReloadTime = 2f;
    [SerializeField] int MaxAmmo = 7, CurrentAmmo = 0;

    Rigidbody Rb;

    bool CanFire = false;
    bool IsFiring = false;
    bool IsReloading = false;

    private void Start()
    {
        CurrentAmmo = MaxAmmo;

        Rb = GetComponent<Rigidbody>();
        Door.OnEnter += Activate;
    }

    private void Update()
    {
        if(Health <= 0)
        {
            Die();
        }

        if(!IsFiring && CanFire && CamMovement.CanMove && !IsReloading && CurrentAmmo > 0)
        {
            //inside firing cone and can fire and not already firing
            StartCoroutine(Fire());
            CurrentAmmo--;
        }
        else if(!IsReloading && CurrentAmmo <= 0)
        {
            StartCoroutine(Reload());
        }
    }

    private void FixedUpdate()
    {
        if(CanFire && CamMovement.CanMove)
        {
            //look towards player
            Vector3 dir = transform.position - Player.transform.position; //taget is player
            dir.y = 0;
            Quaternion targetRot = Quaternion.LookRotation(dir); //so visor is right way
            Rb.MoveRotation(targetRot);
        }
    }

    void Activate()
    {
        Debug.Log("Activated!");

        //play anim, once done look towards player and fire

        CanFire = true;

        Door.OnEnter -= Activate;
    }

    IEnumerator Fire()
    {
        IsFiring = true;

        //get dir and fire towards current position, not future since behavior should be dumb
        Vector3 dir = transform.position - Player.transform.position;
        dir.y = 0;

        Quaternion bulletRot = Quaternion.LookRotation(dir, transform.up) * Quaternion.Euler(-90f, 0f, 0f); //enemy forward will be bullet forward, eventually gun forw..
        GameObject bullet = Instantiate(BulletPrefab, BulletOrigin.position, bulletRot);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.AddForce(bullet.transform.up * BulletForce, ForceMode.Impulse); //up since its rotated

        yield return new WaitForSeconds(FireDelay);

        IsFiring = false;
    }

    IEnumerator Reload()
    {
        IsReloading = true;

        yield return new WaitForSeconds(ReloadTime);

        CurrentAmmo = MaxAmmo;

        IsReloading = false;
    }

    void Die()
    {
        //Play anim, destroy / disable
        Destroy(gameObject);
    }
}
