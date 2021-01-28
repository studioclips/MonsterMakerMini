using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommonHeaderView : MonoBehaviour
{
    #region 外部定義変数

    [SerializeField] private Text _playerName = null;

    [SerializeField] private Text _titleName = null;

    [SerializeField] private Text _counter1Text = null;

    [SerializeField] private Text _levelText = null;

    [SerializeField] private Text _hpText = null;

    [SerializeField] private Text _expText = null;

    [SerializeField] private Text _counter2Text = null;

    #endregion

    #region 外部よりアクセスする変数

    public String PlayerName
    {
        set => _playerName.text = value;
    }
    
    public String TitleName
    {
        set => _titleName.text = value;
    }
    
    public String Counter1Text
    {
        set => _counter1Text.text = value;
    }
    
    public String LevelText
    {
        set => _levelText.text = value;
    }
    
    public String HpText
    {
        set => _hpText.text = value;
    }
    
    public String ExpText
    {
        set => _expText.text = value;
    }
    
    public String Counter2Text
    {
        set => _counter2Text.text = value;
    }

    #endregion
}
