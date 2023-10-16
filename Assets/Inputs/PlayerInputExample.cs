using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputExample : MonoBehaviour
{
    public float m_JumpForce = 350f;
    public float m_Speed = 5f;

    public InputActionReference m_Move;
    public InputActionReference m_Jump;

    Rigidbody m_Rigidbody;

    void OnEnable()
    {
        m_Rigidbody = GetComponent<Rigidbody>();

        m_Move.action.Enable();
        m_Jump.action.Enable();

        m_Jump.action.performed += Jump;

    }

    void OnDisable()
    {
        m_Move.action.Disable();
        m_Jump.action.Disable();

        m_Jump.action.performed -= Jump;
    }

    private void Update()
    {
        Move(m_Move.action.ReadValue<Vector2>());
    }

    void Move(Vector2 movement)
    {
        Vector2 direction = movement.normalized;
        transform.position += new Vector3(direction.x, 0, direction.y) * Time.deltaTime * m_Speed;
    }

    void Jump(InputAction.CallbackContext ctx)
    {
        m_Rigidbody.AddForce(Vector3.up * m_JumpForce);
    }

    void Cancelled(InputAction.CallbackContext ctx)
    {
        Debug.Log("Cancelled input");
    }
}
