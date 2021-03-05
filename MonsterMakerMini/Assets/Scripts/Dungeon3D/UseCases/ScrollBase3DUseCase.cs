using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ScrollBase3DUseCase : MonoBehaviour
{
    [SerializeField]
    private Transform _scrollPanel;
    private float xAngle = 35f;
    private bool _isActive = false;

    public void ScrollPos(Vector2 moveAddPos)
    {
        if(_isActive)
            return;
        _isActive = true;
        var pos = _scrollPanel.localPosition;
        pos += new Vector3(moveAddPos.x * 1f, moveAddPos.y * 1f, 0);
        _scrollPanel.DOLocalMove(pos, 0.5f).OnComplete(() => _isActive = false);
    }
}
