using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float m_Speed = 5f;

    private void Start()
    {
        Random.InitState(gameObject.GetInstanceID());
        m_Speed *= Random.value * 2f - 1f;
    }
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * -m_Speed);
    }
}
