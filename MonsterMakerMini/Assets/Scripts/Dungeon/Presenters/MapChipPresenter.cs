using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using Unity.Linq;
using UnityEngine.Serialization;

public class MapChipPresenter : MonoBehaviour
{
    [SerializeField] private Light directionalLight;

    [SerializeField] private GameObject mapChipPrefab = null;

    [SerializeField] private float openLightSpeed = 0.1f;

    [SerializeField] private float fadeOutSpeed = 0.001f;

    private List<MapChipView> _mapChipViews = new List<MapChipView>();

    /// <summary>
    /// カードの設定
    /// </summary>
    /// <param name="x">X座標</param>
    /// <param name="y">Y座標</param>
    /// <param name="atlasIndex">選択マップ番号</param>
    /// <param name="imageIndex">イメージ番号</param>
    /// <param name="callback">選択したときのコールバック</param>
    public void AddMapChip(int x, int y, int atlasIndex, int imageIndex, Action<int> callback)
    {
        //  マップチップ生成
        var gobj = gameObject.Add(mapChipPrefab);
        //  指定の座標にセット
        gobj.GetComponent<RectTransform>().localPosition = new Vector3(x, y, 0);
        var mapChipView = gobj.GetComponent<MapChipView>();
        //  タップされたときに返るようにコールバックの登録
        mapChipView.SetClickCallback(callback);
        //  カードのイメージ番号と通し番号をセット
        mapChipView.SetMapImage(atlasIndex, imageIndex, _mapChipViews.Count);
        //  リストに追加
        _mapChipViews.Add(mapChipView);
    }

    /// <summary>
    /// 指定のカードを開く
    /// </summary>
    /// <param name="cardIndex">開く対象のカードインデックス</param>
    public void CardOpenAction(int cardIndex)
    {
        var mapChipView = _mapChipViews[cardIndex];
        mapChipView.ChangeMaterial();
        Observable.FromCoroutine(_ => OpenAction(mapChipView))
            .Subscribe(_ => directionalLight.intensity = 0.8f)
            .AddTo(this);
    }

    private IEnumerator OpenAction(MapChipView mapChipView)
    {
        float alpha = 1.0f;
        //  ディレクショナリライトのIntesity を 0.8 から 20 くらいまで加える
        while (directionalLight.intensity < 20.0f)
        {
            directionalLight.intensity += 4 * openLightSpeed;
            if (directionalLight.intensity >= 20.0f)
                directionalLight.intensity = 20.0f;
            yield return null;
        }

        while (alpha > 0.0f)
        {
            alpha -= fadeOutSpeed;
            if (alpha <= 0.0f)
                alpha = 0.0f;
            mapChipView.Alpha = alpha;
            directionalLight.intensity -= openLightSpeed;
            if (directionalLight.intensity <= 0.8f)
                directionalLight.intensity = 0.8f;
            yield return null;
        }
    }
}