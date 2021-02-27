using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DungeonMapModel
{
    //  マップ情報
    public static uint mapEnableMoveUp      = 0x0001;       //  上移動可能
    public static uint mapEnableMoveRight   = 0x0002;       //  右移動可能
    public static uint mapEnableMoveDown    = 0x0004;       //  下移動可能
    public static uint mapEnableMoveLeft    = 0x0008;       //  左移動可能

    [Serializable]
    public class Point
    {
        public int x;
        public int y;
    }
    //  マップパラメータ
    [Serializable]
    public class MapParam
    {
        public int mapSrcNum;                               //  マップ選択番号
        public Point mapSrcPos;                             //  マップ切り取り位置
        public uint mapType;                                //  マップ情報
        public uint reserve1;
        public uint reserve2;
    };

    [Serializable]
    public class MapPack
    {
        public List<MapParam> mapData;
    }

    //  マップの大きさ
    public Point mapSize;
    //  マップデータ
    public List<MapPack> mapData;
}
