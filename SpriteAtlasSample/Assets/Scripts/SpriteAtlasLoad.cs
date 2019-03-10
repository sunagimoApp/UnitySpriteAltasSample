using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;

public class SpriteAtlasLoad : MonoBehaviour
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

    /// <summary>
    /// スプライト名。
    /// </summary>
    [Header("スプライト名。")]
    [SerializeField]
    string spName = null;

    /// <summary>
    /// イメージ。
    /// </summary>
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
    }

    void Start()
    {
        var request = assetBundle.LoadAssetAsync<SpriteAtlas>(assetName);
        request.completed += (operation) => {
            var atlas = (SpriteAtlas)request.asset;
            var atlasSp = atlas.GetSprite(spName);
            img.sprite = atlasSp;
        };
    }
}
