using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class MapChip3DUseCase : MonoBehaviour
{
    private MapChip3DPresenter _mapChip3DPresenter = null;

    private DungeonRegistry _dungeonRegistry = null;
    
    private DungeonMapModel.Point _mapSize;

    private List<string> _mapDataFileNames = new List<string>()
    {
        "Dungeon/Datas/testmap",
    };

    // Start is called before the first frame update
    void Start()
    {
        _mapChip3DPresenter = GetComponent<MapChip3DPresenter>();
        _dungeonRegistry = GetComponent<DungeonRegistry>();
        InitMapData(0);
    }

    /// <summary>
    /// マップ表示
    /// </summary>
    /// <param name="mapNum">対応するマップ番号</param>
    private void InitMapData(int mapNum)
    {
        _dungeonRegistry.LoadModelData(_mapDataFileNames[mapNum]);
        _mapSize = _dungeonRegistry.MapModel.mapSize;
        var startX = (float)( (_mapSize.x + 1) / 2) * -1f;
        var startY = (float)( (_mapSize.y + 1) / 2) * 1f;
        foreach (var y in (Enumerable.Range(0,(int)_mapSize.y)))
        {
            foreach (var x in Enumerable.Range(0, (int)_mapSize.x))
            {
                var mapData = _dungeonRegistry.MapModel.mapData[y].mapData[x];
                var atlasIndex = mapData.mapSrcNum;
                var imageIndex = new Vector2Int(mapData.mapSrcPos.x, mapData.mapSrcPos.y);
                _mapChip3DPresenter.AddMapChip(startX + (float)x * 1f, startY - (float)y * 1f, atlasIndex, imageIndex, TapCard);
            }
        }
    }


    /// <summary>
    /// カードをタップ（コールバック）
    /// </summary>
    /// <param name="index">タップした番号が返る</param>
    private void TapCard(int index)
    {
        _mapChip3DPresenter.CardOpenAction(index);
    }
}
