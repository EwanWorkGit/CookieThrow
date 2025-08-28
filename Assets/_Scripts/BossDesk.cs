using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDesk : MonoBehaviour, IInteractible
{
    [SerializeField] Transform CookiePlacement;
    [SerializeField] ExplosiveCookie Cookie;

    [SerializeField] float BlowTime = 2f;

    public void Interact()
    {
        Cookie.gameObject.SetActive(true);
        Cookie.transform.position = CookiePlacement.position;

        StartCoroutine(WaitAndBlow());
    }

    IEnumerator WaitAndBlow()
    {
        yield return new WaitForSeconds(BlowTime);
        Cookie.ExplosionVFX.Play();
        EndGame.Instance.TriggerFade(); //fades to menu
    }

}
