using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapChipView : MonoBehaviour
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
    [SerializeField] private List<SpriteList> mapChipLists = new List<SpriteList>();

    //  背景スプライトレンダラー
    [SerializeField] private SpriteRenderer mapBackSpriteRenderer = null;

    [SerializeField] private Material mapBackMaterial = null;

    [SerializeField] private SpriteRenderer chipSpriteRenderer = null;

    private Action<int> _callback = null;

    private int _cardIndex = -1;
    
    /// スプライトのアルファ値をセットする
    public float Alpha
    {
        get { return mapBackSpriteRenderer.color.a; }
        set { mapBackSpriteRenderer.color = new Color(1.0f, 1.0f, 1.0f, value); }
    }
    
    /// <summary>
    /// マップチップに画像を適用
    /// </summary>
    /// <param name="atlasIndex">適用するアトラス番号</param>
    /// <param name="imageIndex">適用するマップ番号</param>
    /// <param name="cardIndex">リスト登録されたカード番号</param>
    public void SetMapImage(int atlasIndex, int imageIndex, int cardIndex)
    {
        _cardIndex = cardIndex;
        chipSpriteRenderer.sprite = mapChipLists[atlasIndex].mapChipLists[imageIndex];
    }

    /// <summary>
    /// マテリアルをライトを反映するように設定する
    /// </summary>
    public void ChangeMaterial()
    {
        mapBackSpriteRenderer.material = mapBackMaterial;
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
