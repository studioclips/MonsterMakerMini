using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapChipView : MonoBehaviour
{
    //  マップチップリスト
    [SerializeField] private List<Sprite> mapChipLists = new List<Sprite>();

    //  背景スプライトレンダラー
    [SerializeField] private SpriteRenderer mapBackSpriteRenderer = null;

    [SerializeField] private Material mapBackMaterial = null;

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
    /// <param name="imageIndex">適用するマップ番号</param>
    /// <param name="cardIndex">リスト登録されたカード番号</param>
    public void SetMapImage(int imageIndex, int cardIndex)
    {
        _cardIndex = cardIndex;
        GetComponent<SpriteRenderer>().sprite = mapChipLists[imageIndex];
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
