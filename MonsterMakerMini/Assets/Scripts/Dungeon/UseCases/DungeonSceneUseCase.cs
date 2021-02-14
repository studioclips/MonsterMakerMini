using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class DungeonSceneUseCase : MonoBehaviour
{
    [SerializeField] private ScrollBaseUseCase _scrollBaseUseCase = null;

    // Start is called before the first frame update
    void Start()
    {
        Observable.EveryUpdate()
            .Where(_ => Input.GetKeyDown(KeyCode.LeftArrow))
            // .ThrottleFirst(System.TimeSpan.FromSeconds(1))
            .Subscribe(_ => _scrollBaseUseCase.scrollType.Value = ScrollBaseUseCase.ScrollBaseType.Left)
            .AddTo(this);
        Observable.EveryUpdate()
            .Where(_ => Input.GetKeyDown(KeyCode.RightArrow))
            // .ThrottleFirst(System.TimeSpan.FromSeconds(1))
            .Subscribe(_ => _scrollBaseUseCase.scrollType.Value = ScrollBaseUseCase.ScrollBaseType.Right)
            .AddTo(this);
        Observable.EveryUpdate()
            .Where(_ => Input.GetKeyDown(KeyCode.UpArrow))
            // .ThrottleFirst(System.TimeSpan.FromSeconds(1))
            .Subscribe(_ => _scrollBaseUseCase.scrollType.Value = ScrollBaseUseCase.ScrollBaseType.Up)
            .AddTo(this);
        Observable.EveryUpdate()
            .Where(_ => Input.GetKeyDown(KeyCode.DownArrow))
            // .ThrottleFirst(System.TimeSpan.FromSeconds(1))
            .Subscribe(_ => _scrollBaseUseCase.scrollType.Value = ScrollBaseUseCase.ScrollBaseType.Down)
            .AddTo(this);
    }
}
