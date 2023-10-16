using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputExampleUnity2 : MonoBehaviour
{
    public float m_Speed = 5f;
    public float m_JumpForce = 250f;

    Vector2 m_Direction;
    Rigidbody m_Rigidbody;

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        transform.position += new Vector3( m_Direction.x, 0, m_Direction.y ) * m_Speed * Time.deltaTime;
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        Vector2 tempDir = ctx.ReadValue<Vector2>();
        if (tempDir.sqrMagnitude > 1f)
        {
            tempDir.Normalize();
        }
        m_Direction = tempDir;
    }


    public void OnJump(InputAction.CallbackContext ctx)
    {
        if(ctx.performed)
        {
            Debug.Log("Jump");

            m_Rigidbody.AddForce(Vector3.up * m_JumpForce);
        }
    }
}
