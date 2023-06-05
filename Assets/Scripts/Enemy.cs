using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{
    public int currentHP;
    public int maxHP;

    public int moneyToGive;

    public int attackDamage;

    public Image healthBarFilled;


    public void damage(int attackPower)
    {
        currentHP -= attackPower;
        healthBarFilled.fillAmount = (float)currentHP / (float)maxHP;

        if (currentHP <= 0)
        {
            enemyDead();
        }
    }

    public void enemyDead()
    {
        // Replace Enemy Once Dead
        gameManagerScript.instance.addMoney(moneyToGive);
        enemyManagerScript.instance.replaceEnemy(gameObject);
        gameManagerScript.instance.addKill();
    }

    public void OnMouseDown()
    {
        if (gameManagerScript.instance.gameActive)
        {
            damage(gameManagerScript.instance.getAttackPower());
        }

    }

}
