using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesFolderExample : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var myPrefab = Resources.Load<GameObject>("ManyRocksResources");
            Instantiate(myPrefab);
        }
    }
}
