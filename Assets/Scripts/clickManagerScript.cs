using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using ZSerializer;

public class clickManagerScript : PersistentMonoBehaviour
{

    public List<float> attackFairy = new List<float>();
    
    public int attackFairyPrice;
    public int attackFairyPower = 1;
    private const float attackFairyTime = 1.0f;
    public TextMeshProUGUI attackFairyQtyText;
    public TextMeshProUGUI attackFairyLabel;

    public int swordUpgradePrice;
    public int swordUpgradeCount;
    public TextMeshProUGUI swordUpgradeQtyText;
    public TextMeshProUGUI swordUpgradeLabel;

    public int tForcePwrUpgradePrice;
    public int tForcePowerUpgradeCount;
    public TextMeshProUGUI tForcePowerQtyText;
    public TextMeshProUGUI tForcePowerLabel;



    // Update is called once per frame
    void Update()
    {
        // Loop through each Autoclicker
        for (int i = 0; i < attackFairy.Count; i++)
        {
            Debug.Log(attackFairy[i].ToString() + "Time: " + Time.time);

            attackFairy[i] -= Time.deltaTime;

            while (attackFairy[i] <= 0.0f)
            {
                attackFairy[i] += attackFairyTime;
                enemyManagerScript.instance.currentEnemy.damage(attackFairyPower * gameManagerScript.instance.attackMultiplier);
            }
        }
    }

    public void OnBuyAttackFairy()
    {
        if (gameManagerScript.instance.money >= attackFairyPrice)
        {
            gameManagerScript.instance.removeMoney(attackFairyPrice);

            attackFairy.Add(attackFairyTime);

            attackFairyPrice = (int)(attackFairyPrice * 1.2);

            attackFairyQtyText.text = "x " + attackFairy.Count.ToString();
            attackFairyLabel.text = "Attack \nfairy \n(" + attackFairyPrice.ToString() + ")";
        }
    }

    public void onBuySwordUpgrade()
    {
        if (gameManagerScript.instance.money >= swordUpgradePrice)
        {
            gameManagerScript.instance.baseAttack += 1;
            swordUpgradeCount += 1;

            gameManagerScript.instance.removeMoney(swordUpgradePrice);

            swordUpgradePrice = (int)(swordUpgradePrice * 1.2);

            swordUpgradeLabel.text = "Sword \n Upgrade \n(" + swordUpgradePrice.ToString() + ")";
            swordUpgradeQtyText.text = "x " + swordUpgradeCount.ToString();
        }
    }

    public void onBuyTForcePowerUpgrade()
    {
        if (gameManagerScript.instance.money >= tForcePwrUpgradePrice)
        {
            gameManagerScript.instance.attackMultiplier += 1;
            tForcePowerUpgradeCount += 1;

            gameManagerScript.instance.removeMoney(tForcePwrUpgradePrice);

            tForcePwrUpgradePrice = (int)(tForcePwrUpgradePrice * 1.2);

            tForcePowerLabel.text = "Triforce \n of Power \n (" + tForcePwrUpgradePrice.ToString() + ")";
            tForcePowerQtyText.text = "x " + tForcePowerUpgradeCount.ToString();

        }
    }

    public void loadGame()
    {
        ZSerialize.LoadScene();
        tForcePowerQtyText.text = "x " + tForcePowerUpgradeCount.ToString();
        swordUpgradeQtyText.text = "x " + swordUpgradeCount.ToString();
        attackFairyQtyText.text = "x " + attackFairy.Count.ToString();

     }
}
