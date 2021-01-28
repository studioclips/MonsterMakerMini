using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SpeachBubbleView : MonoBehaviour
{
    //  表示対象テキスト
    [SerializeField] private Text speachBubbleText;
    //  表示速度
    [SerializeField] private float speachSpeed = 0.1f;
    //  表示するメッセージ
    private String _bubbleMessage = "";
    //  現在の文字数
    private int _stringCount = 0;
    //  コルーチン管理用
    private IDisposable _disposable;
    // Start is called before the first frame update
    void Start()
    {
        speachBubbleText.text = "";
    }

    public void SetBubbleMessage(String msg)
    {
        _bubbleMessage = msg;
        _disposable = Observable.FromCoroutine(ActionBubbleMessage)
            .Subscribe(_=>Debug.Log("end"));
    }

    private IEnumerator ActionBubbleMessage()
    {
        _stringCount = 0;
        while (_bubbleMessage.Length > _stringCount)
        {
            _stringCount++;
            var msg = _bubbleMessage.Substring(0, _stringCount);
            speachBubbleText.text = msg;
            yield return new WaitForSeconds(speachSpeed);
        }
    }
    
}
