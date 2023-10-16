using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int level;
    public int health;


    void Start()
    {
        LoadPlayer();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SavePlayer();
        }


        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadPlayer();
        }
    }

    private void SavePlayer()
    {
        //SaveSystem.SavePlayer(this);
    }
    private void LoadPlayer()
    {/*
        var playerData = SaveSystem.LoadPlayer();

        if (playerData != null)
        {
            level = playerData.level;
            health = playerData.health;
            transform.position = playerData.position.ToVector3();
        }*/
    }
}
