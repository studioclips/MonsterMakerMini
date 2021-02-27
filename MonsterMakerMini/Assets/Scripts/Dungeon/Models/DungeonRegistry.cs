using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DungeonRegistry : MonoBehaviour
{
    //  ダンジョンマップ
    private DungeonMapModel _mapModel = null;
    public  DungeonMapModel MapModel
    {
        get { return _mapModel; }
    }
    
    /// <summary>
    /// ダンジョンマップの読み込み
    /// </summary>
    /// <param name="fileName">マップファイル名</param>
    public void LoadModelData(string fileName)
    {
        var mapModel = Resources.Load<TextAsset>(fileName).text;
        _mapModel = JsonUtility.FromJson<DungeonMapModel>(mapModel);
    }
}
