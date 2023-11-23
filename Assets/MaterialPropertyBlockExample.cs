using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialPropertyBlockExample : MonoBehaviour
{
    public Color m_Color;
    void Start()
    {
        var mpb = new MaterialPropertyBlock();
        mpb.SetColor("_Color", m_Color);
        GetComponent<Renderer>().SetPropertyBlock(mpb);
        //GetComponent<Renderer>().material.color = m_Color;
    }
}
