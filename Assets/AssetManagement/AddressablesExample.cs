using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AddressablesExample : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var handle = Addressables.LoadAssetAsync<GameObject>("Assets/AssetManagement/ManyRocks.prefab");
            handle.Completed += OnAssetLoad;
        }
    }

    void OnAssetLoad(AsyncOperationHandle<GameObject> handle)
    {
        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            Instantiate(handle.Result);
        }
        else
        {
            Debug.LogError("Failed to load: " + handle.Result.name);
        }
    }
}
