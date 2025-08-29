using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlap : MonoBehaviour
{
    [SerializeField] Camera Cam;
    [SerializeField] AudioSource AudioPlayer;
    [SerializeField] AudioClip SlapAudio;

    [SerializeField] float SlapDistance = 2f, SlapDamage = 55f, SlapPower = 2f, SlapCooldownTime = 0.2f;

    bool IsSlapping = false;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && !IsSlapping)
        {
            StartCoroutine(SlapCooldown()); //IsSlapping toggle

            Ray ray = Cam.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f));
            Physics.Raycast(ray, out RaycastHit hit, SlapDistance);

            if(hit.collider != null)
            {
                if(hit.transform.TryGetComponent(out CookieCrook Crook))
                {
                    Crook.Health -= SlapDamage;
                    if(Crook.transform.TryGetComponent(out Rigidbody Rb))
                    {
                        Rb.AddForce(transform.forward * SlapPower, ForceMode.Impulse);
                    }

                    AudioPlayer.PlayOneShot(SlapAudio);
                }
            }

            
        }
    }

    IEnumerator SlapCooldown()
    {
        IsSlapping = true;

        yield return new WaitForSeconds(SlapCooldownTime);

        IsSlapping = false;
    }
}
