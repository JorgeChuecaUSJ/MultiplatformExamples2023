using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class MovementDOP : MonoBehaviour
{
    Transform[] cubes;
    void Start()
    {
        cubes = GetComponentsInChildren<Transform>();

        float size = 64;
        for (int i = 1; i < cubes.Length; i++)
        {
            cubes[i].position = new Vector3(Random.value * size, 0, Random.value * size);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float speed = 5f;
        float amplitude = 0.1f;
        for (int i = 1; i < cubes.Length; i++)
        {
            float offset = cubes[i].position.x * .2f;
            cubes[i].position += Vector3.up * Mathf.Sin(Time.time * speed + offset) * amplitude;
        }
    }
}
