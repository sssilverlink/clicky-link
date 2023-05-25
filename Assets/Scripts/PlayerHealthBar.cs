using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZSerializer;

public class PlayerHealthBar : PersistentMonoBehaviour
{
    public GameObject heartPrefab;
    public PlayerHealth playerHealth;

    List<PlayerHealth> hearts = new List<PlayerHealth>();



    private void Start()
    {
        DrawHearts();
    }

    public void DrawHearts()
    {
       int heartsToMake;
        ClearHearts();

        // Determine number of hearts to draw based on Player Max Health
        float maxHealthRemainder = 0;//playerHealth.maxHealth % 4;
        if (maxHealthRemainder > 0)
        {
            heartsToMake = (int)(0);// playerHealth.maxHealth / 4 + 1);
        }
        else
        {
            heartsToMake = (int)(0);//playerHealth.maxHealth / 4);
        }
        
        for (int i = 0; i < heartsToMake; i++)
        {
            CreateEmptyHearts();
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
