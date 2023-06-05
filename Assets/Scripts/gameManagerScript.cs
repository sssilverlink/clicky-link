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

    [NonZSerialized] public TextMeshProUGUI moneyText;
    [NonZSerialized] public TextMeshProUGUI levelCounter;
    [NonZSerialized] public TextMeshProUGUI killCounter;

    [NonZSerialized] public GameObject gameOverMenu;
 
    private static gameManagerScript __instance;
    public static gameManagerScript instance { get { return __instance; } }

    [NonZSerialized] public bool gameActive = true;
    
    public int level = 1;
    public int levelRequirement = 10;
    public int killCount = 1;

    public int baseAttack;
    public int attackMultiplier;
    public int attackPower;


    private void Start()
    {
        if (MainMenuScript.toLoadGame == true)
        {
            loadGame();
        }
        moneyText.text = "x" + money.ToString();
        levelCounter.text = "Level: " + level.ToString();
        SceneManager.UnloadSceneAsync(0);
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
        moneyText.text = "x" + money.ToString();
        killCounter.text = killCount.ToString() + "/" + levelRequirement;
        levelCounter.text = "Level: " + level.ToString();

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
        ZSerialize.SaveScene();
    }

    public void addMoney(int amount)
    {
        money += amount * level;
        moneyText.text = "x" + money.ToString();
    }

    public void removeMoney(int amount)
    {
        money -= amount;
        moneyText.text = "x" + money.ToString();
    }

    public int getAttackPower()
    {
        attackPower = baseAttack * attackMultiplier;
        return (attackPower);
    }

    public void gameOver()
    {
        gameActive = false;
        Debug.Log("Game OVer Called");
        gameOverMenu.SetActive(true);
    }
}
