using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class PlayerManagerScript : MonoBehaviour
{
    public Player playerStructure;
    public static PlayerManagerScript instance;

    private void Start()
    {
        CreatePlayer();

    }
    private void Awake()
    {
        instance = this;
    }

    public void CreatePlayer()
    {
        Debug.Log("Creating Player");

        playerStructure = GetComponent<Player>();

        Debug.Log(playerStructure);


    }
    

}
