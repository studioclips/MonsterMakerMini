using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class HomeSceneManager : MonoBehaviour
{
    [SerializeField] private SpeachBubbleView speachBubbleView;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            speachBubbleView.SetBubbleMessage("メッセージの表示はこんな感じです！");
        }
    }
}
