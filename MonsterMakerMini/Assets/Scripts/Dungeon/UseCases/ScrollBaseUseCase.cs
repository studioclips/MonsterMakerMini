using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class ScrollBaseUseCase : MonoBehaviour
{
    public enum ScrollBaseType
    {
        Idle = 0,
        Left,
        Up,
        Right,
        Down
    }

    private Vector2[] _scrollAddTables = {new Vector2(-1, 0), new Vector2(0, 1), new Vector2(1, 0), new Vector2(0, -1)};
    private RectTransform _scrollBaseRect = null;

    public ReactiveProperty<ScrollBaseType> ScrollType = new ReactiveProperty<ScrollBaseType>(ScrollBaseType.Idle);
    //  スクロール状態
    [SerializeField] private float _scrollMaxSize = 180;
    [SerializeField] private float _stepDotCount = 10;
    private bool isScroll = false;
    private Vector2 scrollVec = Vector2.zero;
    private float _nowScrollSize = 0;

    // Start is called before the first frame update
    void Start()
    {
        //  移動のための transform 取得
        _scrollBaseRect = GetComponent<RectTransform>();
        ScrollType.Select(x => (int) x - 1)
            .Where(x => x >= 0 && !isScroll)
            .Subscribe(x =>
            {
                isScroll = true;
                scrollVec = _scrollBaseRect.localPosition;
                _nowScrollSize = 0;
                StartCoroutine(ScrollAction(x));
            }).AddTo(this);
    }

    /// <summary>
    /// 指定方向へ1ブロック分スクロール
    /// </summary>
    /// <param name="scrollDirection">スクロールの方向</param>
    /// <returns></returns>
    private IEnumerator ScrollAction(int scrollDirection)
    {
        while (_nowScrollSize < _scrollMaxSize)
        {
            var addScrollSize = _stepDotCount * Time.deltaTime;
            _nowScrollSize += addScrollSize;
            if(_nowScrollSize >= _scrollMaxSize)
                _nowScrollSize = _scrollMaxSize;
            scrollVec += _scrollAddTables[scrollDirection] * addScrollSize;
            _scrollBaseRect.localPosition = scrollVec;
            yield return null;
        }
        isScroll = false;
    }
}
