using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gamble : MonoBehaviour
{
    /// <summary>
    /// 玩家下注
    /// </summary>
    public Text playerG;
    /// <summary>
    /// 玩家籌碼
    /// </summary>
    public Text MTG;
    //複合
    public Play py;
  //  public PlayerData all;
    /// <summary>
    /// 莊家籌碼
    /// </summary>
    public Text PCG;
    // Start is called before the first frame update
    void Start()
    {

        MTG.text = "玩家籌碼:"+ py.all.coinA.ToString();
        PCG.text = "莊家籌碼:" + py.all.PC.ToString();
        playerG.text = (string.Format("1號: {0}, 2號: {1}, 3號: {2}, 4號: {3}, 5號: {4}, 6號: {5}, 7號: {6}, 8號: {7}", py.all.coin[0].ToString(), py.all.coin[1].ToString(), py.all.coin[2].ToString(), py.all.coin[3].ToString(), py.all.coin[4].ToString(), py.all.coin[5].ToString(), py.all.coin[6].ToString(), py.all.coin[7].ToString()));
      
    }

    // Update is called once per frame

    //public void T2_txt()
    //{
    //    s1 = ct.PM[0].ToString();
    //    s2= ct.PM[1].ToString();
    //    s3 = ct.PM[2].ToString();
    //    s4 = ct.PM[3].ToString();
    //    s5 = ct.PM[4].ToString();
    //    s6 = ct.PM[5].ToString();
    //    s7 = ct.PM[6].ToString();
    //    s8 = ct.PM[7].ToString();
    //}
}
