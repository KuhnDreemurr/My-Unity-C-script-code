using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    /// <summary>
    /// 玩家下注
    /// </summary>
    public int[] coin;          
    /// <summary>
    /// 剩餘籌碼
    /// </summary>
    public int MM;
    /// <summary>
    /// 下注總額暫存
    /// </summary>
    public int coinA;
    /// <summary>
    /// 莊家籌碼
    /// </summary>
    public int PC;
}

[System.Serializable]
public class DOAData
{
    /// <summary>
    /// 儲存Enum資料
    /// </summary>
    public int[] Fen;
    public int[] Rint;
}
