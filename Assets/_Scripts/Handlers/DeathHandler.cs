using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathHandler : MonoBehaviour
{
    public static DeathHandler Instance;

    public float FadeTime = 1f;
    public bool IsDead = false;

    [SerializeField] Image FadingScreen;
    [SerializeField] GameObject DeathText, RetryButton, ExitButton;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        FadingScreen.color = new Color32(0, 0, 0, 0);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            //kills yourself
            KillPlayer();
        }
    }

    public void KillPlayer()
    {
        if(Instance != null)
        {
            StartCoroutine(FadeToBlackAndShowMenu());
        }
    }

    IEnumerator FadeToBlackAndShowMenu()
    {
        float minOpacity = 0, maxOpacity = 1;

        float t = 0;
        float currentOpacity = 0;

        IsDead = true;

        while (t <= FadeTime)
        {
            t += Time.deltaTime / FadeTime;
            currentOpacity =  Mathf.Lerp(minOpacity, maxOpacity, Mathf.Clamp01(t));
            byte alpha = (byte)(currentOpacity * 255f);
            FadingScreen.color = new Color32(0, 0, 0, alpha);

            yield return null;
        }

        Cursor.lockState = CursorLockMode.None;

        DeathText.SetActive(true);
        RetryButton.SetActive(true);
        ExitButton.SetActive(true);
    }
}
