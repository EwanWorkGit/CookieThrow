using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInit : MonoBehaviour
{
    [SerializeField] int Index = 0;

    Button Button;

    private void Start()
    {
        Button = GetComponent<Button>();
        
        switch(Index)
        {
            case 0:
                {
                    Button.onClick.AddListener(GameSceneManager.Instance.ExitToMenu);
                    break;
                }
            case 1:
                {
                    Button.onClick.AddListener(GameSceneManager.Instance.StartGame);
                    break;
                }
            case 2:
                {
                    Button.onClick.AddListener(GameSceneManager.Instance.ExitGame);
                    break;
                }
        }
    }
}
