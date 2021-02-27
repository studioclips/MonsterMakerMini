using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class MapChipUseCase : MonoBehaviour
{
    private MapChipPresenter _mapChipPresenter = null;

    private DungeonRegistry _dungeonRegistry = null;
    
    private DungeonMapModel.Point _mapSize;

    private List<string> _mapDataFileNames = new List<string>()
    {
        "Dungeon/Datas/testmap",
    };

    // Start is called before the first frame update
    void Start()
    {
        _mapChipPresenter = GetComponent<MapChipPresenter>();
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
        var startX = ( _mapSize.x / 2) * -180 + (((_mapSize.x % 2) == 0) ? 90 : 0);
        var startY = ( _mapSize.y / 2) * 180 + (((_mapSize.y % 2) == 0) ? -90 : 0);
        foreach (var y in (Enumerable.Range(0,(int)_mapSize.y)))
        {
            foreach (var x in Enumerable.Range(0, (int)_mapSize.x))
            {
                var mapData = _dungeonRegistry.MapModel.mapData[y].mapData[x];
                var atlasIndex = mapData.mapSrcNum;
                var imageIndex = mapData.mapSrcPos.y * 4 + mapData.mapSrcPos.x;
                _mapChipPresenter.AddMapChip(startX + x * 180, startY - y * 180, atlasIndex, imageIndex, TapCard);
            }
        }
    }


    /// <summary>
    /// カードをタップ（コールバック）
    /// </summary>
    /// <param name="index">タップした番号が返る</param>
    private void TapCard(int index)
    {
        _mapChipPresenter.CardOpenAction(index);
    }
}
