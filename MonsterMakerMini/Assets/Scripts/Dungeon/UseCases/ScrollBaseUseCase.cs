using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.Serialization;

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

    private readonly Vector2[] _scrollAddTables = {new Vector2(-1, 0), new Vector2(0, 1), new Vector2(1, 0), new Vector2(0, -1)};
    private RectTransform _scrollBaseRect = null;

    public ReactiveProperty<ScrollBaseType> scrollType = new ReactiveProperty<ScrollBaseType>(ScrollBaseType.Idle);
    //  スクロール状態
    [SerializeField] private float scrollMaxSize = 180;
    [SerializeField] private float stepDotCount = 600;
    private bool _isScroll = false;
    private Vector2 _scrollVec = Vector2.zero;
    private float _nowScrollSize = 0;

    // Start is called before the first frame update
    void Start()
    {
        //  移動のための transform 取得
        _scrollBaseRect = GetComponent<RectTransform>();
        scrollType.Select(x => (int) x - 1)
            .Where(x => x >= 0 && !_isScroll)
            .Subscribe(x =>
            {
                _isScroll = true;
                _scrollVec = _scrollBaseRect.localPosition;
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
        while (_nowScrollSize < scrollMaxSize)
        {
            var addScrollSize = stepDotCount * Time.deltaTime;
            _nowScrollSize += addScrollSize;
            if(_nowScrollSize >= scrollMaxSize)
                _nowScrollSize = scrollMaxSize;
            _scrollVec += _scrollAddTables[scrollDirection] * addScrollSize;
            _scrollBaseRect.localPosition = _scrollVec;
            yield return null;
        }

        scrollType.Value = ScrollBaseType.Idle;
        _isScroll = false;
    }
}
