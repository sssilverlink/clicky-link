using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZSerializer;
using TMPro;
using System;

public class Player : PersistentMonoBehaviour
{
    private static Player __instance;

    public static Player Instance { get { return __instance; } }


    public static event Action OnPlayerDamaged;

    public int currentHP;
    public int maxHP = 5;

    public string playerName;
    [NonZSerialized] public TextMeshProUGUI playerNameTextBox;

    [NonZSerialized] public TextMeshProUGUI playerCurrentHPTextBox;

    private void Start()
    {
        if (MainMenuScript.toLoadGame = false)
        {
            currentHP = maxHP;
        }

        playerNameTextBox.text = playerName;
        playerCurrentHPTextBox.text = currentHP.ToString();
    }


    private void Awake()
    {
        if (__instance != null && __instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            __instance = this;
        }
    }

    public void loadGame()
    {

    }
    public void damage(int damage)
    {
        //Damage Player
        currentHP -= (int)damage;
        
        OnPlayerDamaged?.Invoke();

        playerCurrentHPTextBox.text = currentHP.ToString();

        if (currentHP <= 0)
        {
            currentHP = 0;
            Debug.Log("Player is dead.");
            gameManagerScript.instance.gameOver();
        }
    }

    public void heal(int amount)
    {
        currentHP += amount;
        if (currentHP > maxHP)  
        {
            currentHP = maxHP;
        }
        playerCurrentHPTextBox.text += currentHP.ToString();
    }

    public int getMaxHealth()
    {
        return maxHP;
    }

    public int getHealth()
    {
        return currentHP;
    }
}
