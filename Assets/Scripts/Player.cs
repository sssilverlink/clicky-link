using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZSerializer;
using TMPro;


public class Player : PersistentMonoBehaviour
{
    public int currentHP;
    public int maxHP = 5;

    public string playerName;
    public TextMeshProUGUI playerNameTextBox;

    public TextMeshProUGUI playerCurrentHPTextBox;

    private void Start()
    {
        currentHP = maxHP;
        playerNameTextBox.text = playerName;
        playerCurrentHPTextBox.text = currentHP.ToString();

    }

    public void damage(int damage)
    {
        //Damage Player
        currentHP -= (int)damage;
        playerCurrentHPTextBox.text = currentHP.ToString();

        if (currentHP < 0)
        {
            // Player is Dead
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
