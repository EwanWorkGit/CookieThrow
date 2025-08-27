using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDesk : MonoBehaviour, IInteractible
{
    [SerializeField] Transform CookiePlacement;
    [SerializeField] Transform Cookie;

    [SerializeField] float BlowTime = 2f;

    public void Interact()
    {
        Cookie.gameObject.SetActive(true);
        Cookie.position = CookiePlacement.position;

        StartCoroutine(WaitAndBlow());
    }

    IEnumerator WaitAndBlow()
    {
        yield return new WaitForSeconds(BlowTime);
        //blow up
        Debug.Log("BOOOOOOM!");
        GameSceneManager.Instance.ExitToMenu();
    }

}
