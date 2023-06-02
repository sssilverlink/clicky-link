using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using ZSerializer;

public class MainMenuScript : MonoBehaviour
{

    public GameObject creditsPanel;

    bool creditsPanelisOn;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }


        public void NewGame()
    {
        PlayerPrefs.SetInt("Load Game", 0);
        Debug.Log("Player Prefs Set: Load Game = 0");
        PlayerPrefs.Save();
        Debug.Log("Player Prefs Saved");
        SceneManager.LoadScene(1);

    }

    public void LoadGame()
    {
        PlayerPrefs.SetInt("Load Game", 1);
        Debug.Log("Player Prefs Set: Load Game = 1");
        PlayerPrefs.Save();
        Debug.Log("Player Prefs Saved");
        SceneManager.LoadScene(1);
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
