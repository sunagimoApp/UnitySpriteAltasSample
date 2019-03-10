using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;

public class SpriteAtlasRequestLoad : MonoBehaviour
{
    /// <summary>
    /// アセットバンドル名。
    /// </summary>
    [Header("アセットバンドル名")]
    [SerializeField]
    string assetBundleName = null;

    /// <summary>
    /// アセット名。
    /// </summary>
    [Header("アセット名")]
    [SerializeField]
    string assetName =null;

    [Header("イメージ")]
    [SerializeField]
    Image img = null;
    
    /// <summary>
    /// AssetBundle。
    /// </summary>
    AssetBundle assetBundle;

    void Awake()
    {
        assetBundle = AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/" + assetBundleName);
        img.enabled = false;
    }

    void OnEnable()
    {
        SpriteAtlasManager.atlasRequested += OnAtlasRequested;
    }

    void OnDisable()
    {
        SpriteAtlasManager.atlasRequested -= OnAtlasRequested;
    }

    void OnAtlasRequested(string tag, System.Action<SpriteAtlas> atlasCallback)
    {   
        var request = assetBundle.LoadAssetAsync<SpriteAtlas>(assetName);
        request.completed += (operation) => {
            atlasCallback.Invoke((SpriteAtlas)request.asset);
            img.enabled = true;
        };
    }
}