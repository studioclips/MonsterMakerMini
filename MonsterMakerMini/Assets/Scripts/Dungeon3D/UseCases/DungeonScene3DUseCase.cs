using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class DungeonScene3DUseCase : MonoBehaviour
{
    [SerializeField] private ScrollBase3DUseCase _scrollBase3DUseCase = null;

    // Start is called before the first frame update
    void Start()
    {
        Observable.EveryUpdate()
            .Where(_ => Input.GetKeyDown(KeyCode.LeftArrow))
            // .ThrottleFirst(System.TimeSpan.FromSeconds(1))
            .Subscribe(_ => _scrollBase3DUseCase.ScrollPos(new Vector2(-1, 0)))
            .AddTo(this);
        Observable.EveryUpdate()
            .Where(_ => Input.GetKeyDown(KeyCode.RightArrow))
            // .ThrottleFirst(System.TimeSpan.FromSeconds(1))
            .Subscribe(_ => _scrollBase3DUseCase.ScrollPos(new Vector2(1, 0)))
            .AddTo(this);
        Observable.EveryUpdate()
            .Where(_ => Input.GetKeyDown(KeyCode.UpArrow))
            // .ThrottleFirst(System.TimeSpan.FromSeconds(1))
            .Subscribe(_ => _scrollBase3DUseCase.ScrollPos(new Vector2(0, 1)))
            .AddTo(this);
        Observable.EveryUpdate()
            .Where(_ => Input.GetKeyDown(KeyCode.DownArrow))
            // .ThrottleFirst(System.TimeSpan.FromSeconds(1))
            .Subscribe(_ => _scrollBase3DUseCase.ScrollPos(new Vector2(0, -1)))
            .AddTo(this);
    }
}
