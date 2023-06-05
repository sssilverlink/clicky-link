using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using ZSerializer;
using Unity.VisualScripting;
using UnityEditorInternal;

public class MainMenuScript : MonoBehaviour
{

    public GameObject creditsPanel;

    bool creditsPanelisOn;

    public static bool toLoadGame;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }


        public void NewGame()
    {
        toLoadGame = false;
        SceneManager.LoadScene(1, LoadSceneMode.Additive);


    }

    public void LoadGame()
    {
        toLoadGame = true;
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
    }

    public void ShowCredits()
    {
        if (creditsPanelisOn)
        {
            creditsPanel.SetActive(false);
            creditsPanelisOn = false;
        }
        else
        {
            creditsPanel.SetActive(true);
            creditsPanelisOn = true;
        }

    }

}
