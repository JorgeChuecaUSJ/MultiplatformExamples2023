using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualInstancing : MonoBehaviour
{

    public int numberOfInstances = 1000;
    public float radius = 50f;
    public Mesh mesh;
    public Material material;

    private Vector3[] positions;
    private Quaternion[] rotations;
    private Vector3[] scales;
    private Matrix4x4[] matrices;

    private MaterialPropertyBlock block;

    void Start()
    {
        SetDataInstancing();
    }

    // Update is called once per frame
    void Update()
    {
        SetDataInstancing();
        Graphics.DrawMeshInstanced(mesh, 0, material, matrices, numberOfInstances, block);
    }

    void SetDataInstancing()
    {
        positions = new Vector3[numberOfInstances];
        rotations = new Quaternion[numberOfInstances];
        scales = new Vector3[numberOfInstances];
        matrices = new Matrix4x4[numberOfInstances];

        Vector4[] colors = new Vector4[numberOfInstances];

        Random.InitState(1234);
        for (int i = 0; i < numberOfInstances; i++)
        {
            positions[i] = transform.position + Random.insideUnitSphere * radius + Vector3.one*Mathf.Sin(Time.time);
            rotations[i] = Random.rotation;
            scales[i] = Vector3.one * Random.Range(0.2f, 1f);

            matrices[i] = Matrix4x4.TRS(positions[i], rotations[i], scales[i]);

            colors[i] = ChangeColor.RandomColor();
        }

        if(block == null)
        {
            block = new MaterialPropertyBlock();
        }

        block.SetVectorArray("_Colors", colors);
    }
}
