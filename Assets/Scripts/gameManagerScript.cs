using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ZSerializer;
using UnityEngine.SceneManagement;

public class gameManagerScript : PersistentMonoBehaviour
{


    public int money;

    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI levelCounter;
    public TextMeshProUGUI killCounter;

 
    private static gameManagerScript __instance;
    public static gameManagerScript instance { get { return __instance; } }


    public int level = 1;
    public int levelRequirement = 10;
    public int killCount = 1;

    public int baseAttack;
    public int attackMultiplier;
    public int attackPower;


    private void Start()
    {
        int loadGameSaved = PlayerPrefs.GetInt("Load Game");
        if (loadGameSaved == 1)
        {
            loadGame();
            // clickManagerScript.instance.loadGame();
        }
        moneyText.text = money.ToString();
        levelCounter.text = "Level: " + level.ToString();
    }
    private void Awake()
    {
        __instance = this;
        DontDestroyOnLoad(this);
    }  

    public void loadGame()
    {
        Debug.Log("Load Game was called");
        ZSerialize.LoadScene();
        enemyManagerScript.instance.replaceEnemy(gameObject);
        gameManagerScript.instance.loadGame();
    }
    public void saveGame()
    {
        ZSerialize.SaveScene();
    }

    public void addKill()
    {
        killCount++;
        if (killCount > levelRequirement) 
        {
            increaseLevel();
            killCount = 1;
        }
        killCounter.text = killCount.ToString() + "/" + levelRequirement;
    }

    public void increaseLevel()
    {
        level++;
        levelCounter.text = "Level: " + level.ToString();
    }

    public void addMoney(int amount)
    {
        money += amount * level;
        moneyText.text = money.ToString();
    }

    public void removeMoney(int amount)
    {
        money -= amount;
        moneyText.text = money.ToString();
    }

    public int getAttackPower()
    {
        attackPower = baseAttack * attackMultiplier;
        return (attackPower);
    }

}
