using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputExampleUnity : MonoBehaviour
{
    public float m_JumpForce = 350f;
    public float m_Speed = 5f;

    Vector2 direction;
    Rigidbody m_Rigidbody;

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        transform.position += (new Vector3(direction.x, 0, direction.y)).normalized * Time.deltaTime * m_Speed;
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        direction = ctx.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext ctx)
    {
        if (ctx.action.WasPerformedThisFrame()) { 
            m_Rigidbody.AddForce(Vector3.up * m_JumpForce);
        }
    }
}
