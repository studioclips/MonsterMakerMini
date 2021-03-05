using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapChip3DView : MonoBehaviour
{
    [Serializable]
    public class SpriteList
    {
        public List<Sprite> mapChipLists = new List<Sprite>();

        public SpriteList(List<Sprite> list)
        {
            mapChipLists = list;
        }
    }
    //  マップチップリスト
    [SerializeField] private List<Material> _mapChipMaterials = new List<Material>();

    //  マップチップマテリアル
    [SerializeField] private MeshRenderer _chipMeshRenderer;

    private Action<int> _callback = null;

    private int _cardIndex = -1;
    
    public float Alpha
    {
        get { return _chipMeshRenderer.material.GetColor("_Color").a; }
        set { _chipMeshRenderer.material.SetColor("_Color", new Color(1.0f, 1.0f, 1.0f, value)); }
    }

    /// <summary>
    /// マップチップに画像を適用
    /// </summary>
    /// <param name="atlasIndex">適用するアトラス番号</param>
    /// <param name="imageIndex">適用するマップ番号</param>
    /// <param name="cardIndex">リスト登録されたカード番号</param>
    public void SetMapImage(int atlasIndex, Vector2Int imageIndex, int cardIndex)
    {
        _cardIndex = cardIndex;
        _chipMeshRenderer.material = _mapChipMaterials[atlasIndex];
        var x = (float) (3 - imageIndex.x) * 0.25f;
        var y = (float) imageIndex.y * 0.25f;
        
        _chipMeshRenderer.material.SetTextureOffset("_MainTex", new Vector2(x, y));
    }
    
    /// <summary>
    /// コールバックの設定
    /// </summary>
    /// <param name="callback">設定するコールバック</param>
    public void SetClickCallback(Action<int> callback)
    {
        _callback = callback;
    }
    
    /// <summary>
    /// マウスがクリックされた（一度だけ反応したら二度は反応しない）
    /// </summary>
    private void OnMouseDown()
    {
        Debug.Log("On Click Card");
        if (null != _callback)
        {
            _callback(_cardIndex);
            _callback = null;
        }
    }
}
