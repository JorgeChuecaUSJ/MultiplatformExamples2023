using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementOOP : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float size = 64;
        transform.position = new Vector3(Random.value * size, 0, Random.value * size);
    }

    // Update is called once per frame
    void Update()
    {
        float speed = 5f;
        float offset = transform.position.x * .2f;
        float amplitude = 0.1f;
        transform.position += Vector3.up * Mathf.Sin(Time.time * speed + offset) * amplitude;
    }
}
