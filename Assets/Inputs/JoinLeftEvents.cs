using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JoinLeftEvents : MonoBehaviour
{
    PlayerInputManager inputManager;
    List<GameObject> players;

    public void OnJoin(PlayerInput input)
    {
        players.Add(input.gameObject);
        Debug.Log("Joined: " + input.gameObject.transform.position);
    }

    public void OnLeave(PlayerInput input)
    {
        players.Remove(input.gameObject);
        Debug.Log("Left: " + input.gameObject.transform.position);
    }
}
