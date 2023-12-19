using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialPropertiesExample : MonoBehaviour
{
    static readonly int ColorID = Shader.PropertyToID("_Color");

    public bool changeColor = false;
    public float rotationSpeed = 5f;

    void Update()
    {
        if (changeColor)
        {
            var renderers = GetComponentsInChildren<Renderer>();
            var propertyBlock = new MaterialPropertyBlock();

            foreach (Renderer renderer in renderers)
            {
                propertyBlock.SetColor(ColorID, Random.ColorHSV(0, 1, .8f, 1, .8f, 1));
                renderer.SetPropertyBlock(propertyBlock);

            }
            changeColor = false;
        }

        //transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

}
