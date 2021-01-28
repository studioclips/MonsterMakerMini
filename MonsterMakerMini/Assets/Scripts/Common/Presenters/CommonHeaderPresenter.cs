using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonHeaderPresenter : MonoBehaviour
{
    private CommonHeaderView _commonHeaderView;
    // Start is called before the first frame update
    void Start()
    {
        _commonHeaderView = GetComponent<CommonHeaderView>();
    }
    
    /// <summary>
    /// プレイヤー名の設定
    /// </summary>
    /// <param name="playerName">設定するプレイヤー名</param>
    public void SetPlayerName(String playerName)
    {
        _commonHeaderView.PlayerName = playerName;
    }

    /// <summary>
    /// 称号名の設定
    /// </summary>
    /// <param name="titleName">設定する称号名</param>
    public void SetTitleName(String titleName)
    {
        _commonHeaderView.TitleName = titleName;
    }

    /// <summary>
    /// レベルの設定
    /// </summary>
    /// <param name="level">設定するレベル</param>
    public void SetLevel(int level)
    {
        _commonHeaderView.LevelText = "Lvl. " + level.ToString();
    }

    /// <summary>
    /// 体力の設定
    /// </summary>
    /// <param name="currentHP">現在の体力</param>
    /// <param name="maxHP">最大の体力</param>
    public void SetHp(int currentHP, int maxHP)
    {
        _commonHeaderView.HpText = "HP " + currentHP.ToString("D3") + "/" + maxHP.ToString("D3");
    }

    /// <summary>
    /// 次の経験値設定
    /// </summary>
    /// <param name="nextExp">次の経験値</param>
    public void SetNextExp(int nextExp)
    {
        _commonHeaderView.ExpText = "NEXP " + nextExp.ToString("D9");
    }

    /// <summary>
    /// 数値設定
    /// </summary>
    /// <param name="counter">数値</param>
    public void SetCounter1(int counter)
    {
        _commonHeaderView.Counter1Text = counter.ToString();
    }

    /// <summary>
    /// 数値設定
    /// </summary>
    /// <param name="counter">数値</param>
    public void SetCounter2(int counter)
    {
        _commonHeaderView.Counter2Text = counter.ToString();
    }
}
