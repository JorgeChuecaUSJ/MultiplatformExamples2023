using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectReferenceExample : MonoBehaviour
{
    public GameObject m_Prefab;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(m_Prefab);
        }
    }
}
