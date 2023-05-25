using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class enemyManagerScript : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Enemy currentEnemy;
    public Transform canvas;
    public static enemyManagerScript instance;
    public float spawnTime = 1.0f;
    public float enemyAttackTimer = 1.0f;
    public Player currentPlayer;

    private void Awake()
    {
        instance = this;
    }

    public void SpawnEnemy()
    {
        Debug.Log("Detected " + enemyPrefabs.Length + " Enemy Prefabs");
        // Spawn new Object Instance
        GameObject enemyToSpawn = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
        GameObject obj = Instantiate(enemyToSpawn, canvas);


        currentEnemy = obj.GetComponent<Enemy>();
        if ((gameManagerScript.instance.level / 10) < 1)
        {
            currentEnemy.maxHP = (int)(currentEnemy.maxHP * (1 + (gameManagerScript.instance.level / 10)));
        }
        else
        {
            currentEnemy.maxHP = (int)(currentEnemy.maxHP * (gameManagerScript.instance.level * 0.3));

        }
        currentEnemy.currentHP = currentEnemy.maxHP;
     }

    public void replaceEnemy(GameObject enemy)
    { 
        // Remove existing object
        // Give Money to player 
        // Spawn new Object

        if (currentEnemy != null)
        {
            Destroy(currentEnemy.gameObject);
            currentEnemy = null;
        }
        SpawnEnemy();
    }

    private void Update()
    {

        // Takes Enemy Damage, attacks player once every 2 seconds
        int enemyAttack = currentEnemy.attackDamage;
        currentPlayer = GetComponent<Player>();
        spawnTime -= Time.deltaTime;
        while (spawnTime <= 0.0f)
        {
            currentPlayer.damage(enemyAttack);
            spawnTime = enemyAttackTimer;
        }


    }
}
