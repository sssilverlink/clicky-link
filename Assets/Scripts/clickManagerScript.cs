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
    [NonZSerialized] public TextMeshProUGUI attackFairyQtyText;
    [NonZSerialized] public TextMeshProUGUI attackFairyLabel;

    public int swordUpgradePrice;
    public int swordUpgradeCount;
    [NonZSerialized] public TextMeshProUGUI swordUpgradeQtyText;
    [NonZSerialized] public TextMeshProUGUI swordUpgradeLabel;

    public int tForcePwrUpgradePrice;
    public int tForcePowerUpgradeCount;
    [NonZSerialized] public TextMeshProUGUI tForcePowerQtyText;
    [NonZSerialized] public TextMeshProUGUI tForcePowerLabel;
    
    private static clickManagerScript __instance;
    public static clickManagerScript instance { get { return __instance; } }


    // Update is called once per frame
    void Update()
    {
        // Loop through each Autoclicker
        if (gameManagerScript.instance.gameActive)
        {
            for (int i = 0; i < attackFairy.Count; i++)
            {
                attackFairy[i] -= Time.deltaTime;

                while (attackFairy[i] <= 0.0f)
                {
                    attackFairy[i] += attackFairyTime;
                    enemyManagerScript.instance.currentEnemy.damage(attackFairyPower * gameManagerScript.instance.attackMultiplier);
                }
            }
        }
        tForcePowerQtyText.text = "x " + tForcePowerUpgradeCount.ToString();
        tForcePowerLabel.text = "Triforce \n of Power \n (" + tForcePwrUpgradePrice.ToString() + ")";

        swordUpgradeQtyText.text = "x " + swordUpgradeCount.ToString();
        swordUpgradeLabel.text = "Sword \n Upgrade \n(" + swordUpgradePrice.ToString() + ")";

        attackFairyQtyText.text = "x " + attackFairy.Count.ToString();
        attackFairyLabel.text = "Attack \nfairy \n(" + attackFairyPrice.ToString() + ")";
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

    public async void loadGame()
    {
        ZSerialize.LoadScene();
        tForcePowerQtyText.text = "x " + tForcePowerUpgradeCount.ToString();
        swordUpgradeQtyText.text = "x " + swordUpgradeCount.ToString();
        attackFairyQtyText.text = "x " + attackFairy.Count.ToString();

     }
}
