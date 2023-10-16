using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public string m_PlayerName;
    public int m_Score;

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
        SaveSystemInClass.SavePlayer(this);

        Debug.Log("Player Saved");
    }

    private void LoadPlayer()
    {
        var playerData = SaveSystemInClass.LoadPlayer();

        if (playerData != null)
        {
            m_PlayerName = playerData.name;
            transform.position = playerData.position.ToVector3();
            transform.rotation = playerData.rotation.ToQuaternion();
            m_Score = playerData.score;
        }

        Debug.Log("Player Loaded");
    }
}
