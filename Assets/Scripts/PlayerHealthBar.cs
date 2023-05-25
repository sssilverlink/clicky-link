using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZSerializer;

public class PlayerHealthBar : PersistentMonoBehaviour
{

    public GameObject heartPrefab;
    public Player player;

    List<PlayerHealth> hearts = new List<PlayerHealth>();


    private void OnEnable()
    {
        Player.OnPlayerDamaged += DrawHearts;
    }

    private void OnDisable()
    {
        Player.OnPlayerDamaged -= DrawHearts;
    }

    private void Start()
    {
        DrawHearts();
    }

    public void DrawHearts()
    {
       int heartsToMake;
       ClearHearts();

        // Determine number of hearts to draw based on Player Max Health
        float maxHealthRemainder = player.maxHP % 4;
        if (maxHealthRemainder > 0)
        {
            heartsToMake = (int)(player.maxHP / 4 + 1);
        }
        else
        {
            heartsToMake = (int)(player.maxHP / 4);
        }
        
        for (int i = 0; i < heartsToMake; i++)
        {
            CreateEmptyHearts();
        }

        for(int i = 0;i < hearts.Count;i++)
        {
            int heartStatusRemainder = Mathf.Clamp(player.currentHP - (i*4), 0, 4);
            hearts[i].setHeartStatus((HeartStatus)heartStatusRemainder);
        }
    }

    public void CreateEmptyHearts()
    {
        GameObject newHeart = Instantiate(heartPrefab);
        newHeart.transform.SetParent(transform);

        PlayerHealth heartComponent = newHeart.GetComponent<PlayerHealth>();
        heartComponent.setHeartStatus(HeartStatus.Empty);
        hearts.Add(heartComponent);
    }

    public void ClearHearts()
    {
        foreach(Transform t in transform)
        {
            Destroy(t.gameObject);
        }
        hearts = new List<PlayerHealth>();
    }

}
