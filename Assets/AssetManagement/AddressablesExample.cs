using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;


[System.Serializable]
public class AssetReferenceAudioClip : AssetReferenceT<AudioClip>
{
    public AssetReferenceAudioClip(string guid) : base(guid)
    {
    }


}

public class AddressablesExample : MonoBehaviour
{
    public AssetReference m_AssetReference;
    public AssetLabelReference m_AssetLabel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //m_AssetReference.InstantiateAsync();


            var handle = Addressables.LoadAssetsAsync<GameObject>(m_AssetLabel, (go) => { Instantiate(go); });
            //handle.Completed += OnAssetLoad;

            //var handle = Addressables.LoadAssetAsync<GameObject>("Assets/AssetManagement/ManyRocks.prefab");
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








//
//
//    //public AssetReference m_AssetReference;
//    //public AssetReferenceGameObject m_AssetReferenceGameObject;
//    //public AssetReferenceAudioClip m_AssetReferenceAudioClip;
//    //public AssetLabelReference m_AssetLabelReference;
//    
//    //Addressables.LoadAssetsAsync<GameObject>(m_AssetLabelReference, (go) => { Instantiate(go); });
//    //var handle = m_AssetReferenceAudioClip.LoadAssetAsync<AudioClip>() ;
//    //var handle = m_AssetReference.LoadAssetAsync<GameObject>() ;
//    //m_AssetReferenceGameObject.InstantiateAsync();