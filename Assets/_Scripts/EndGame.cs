using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    public static EndGame Instance;

    [SerializeField] Image FadingScreen;
    [SerializeField] GameObject ThankYouText;

    [SerializeField] float FadeTime = 0.2f;

    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        FadingScreen.color = new Color32(0, 0, 0, 0);
    }

    public void TriggerFade()
    {
        StartCoroutine(FadeToMenu());
    }
    IEnumerator FadeToMenu()
    {
        float minOpacity = 0, maxOpacity = 1;

        float t = 0;
        float currentOpacity = 0;

        while (t <= 1f)
        {
            t += Time.deltaTime / FadeTime;
            currentOpacity = Mathf.Lerp(minOpacity, maxOpacity, Mathf.Clamp01(t));
            byte alpha = (byte)(currentOpacity * 255f);
            FadingScreen.color = new Color32(0, 0, 0, alpha);

            yield return null;
        }

        ThankYouText.SetActive(true);
        yield return new WaitForSeconds(5f);

        Cursor.lockState = CursorLockMode.None;

        GameSceneManager.Instance.ExitToMenu();
    }
}
