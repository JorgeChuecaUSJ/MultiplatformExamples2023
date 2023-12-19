using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public bool DoChangeColor = false;

    public static int ColorID = Shader.PropertyToID("_Color");
    Renderer[] renderers;
    MaterialPropertyBlock materialPropertyBlock;

    void Start()
    {
        Init();
    }

    private void Update()
    {
        if (DoChangeColor)
        {
            ChangeMaterialColor();
            DoChangeColor = false;
        }
    }

    void Init()
    {
        if (renderers == null)
        {
            renderers = GetComponentsInChildren<Renderer>();
        }

        if (materialPropertyBlock == null)
        {
            materialPropertyBlock = new MaterialPropertyBlock();
        }
    }

    void ChangeMaterialColor()
    {
        foreach ( Renderer r in renderers )
        {
            r.material.color = RandomColor();
        }
    }

    void ChangeMaterialColor2()
    {
        foreach (Renderer r in renderers)
        {
            materialPropertyBlock.SetColor(ColorID, RandomColor());
            r.SetPropertyBlock(materialPropertyBlock);
        }
    }

    public static Color RandomColor()
    {
        return Random.ColorHSV(0f, 1f, .8f, 1f, .8f, 1f);
    }
}
