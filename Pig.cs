using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pig : MonoBehaviour {
    #region 骰子點數圖片1~6
    public Sprite s1;
    public Sprite s2;
    public Sprite s3;
    public Sprite s4;
    public Sprite s5;
    public Sprite s6;
    #endregion
    /// <summary>
    /// 玩家A骰子點數總和暫存
    /// </summary>
    public int DAp;
    /// <summary>
    /// 玩家A實得分數
    /// </summary>
    public int Ap;
    /// <summary>
    /// 玩家B骰子點數總和暫存
    /// </summary>
    public int DBp;
    /// <summary>
    /// 玩家B實得分數
    /// </summary>
    public int Bp;
    /// <summary>
    /// 骰子點數
    /// </summary>
    public int Dice;
    /// <summary>
    /// 玩家A累積分數顯示
    /// </summary>
    public Text AP;
    /// <summary>
    /// 玩家A暫存分數顯示
    /// </summary>
    public Text ADP;
    /// <summary>
    /// 玩家B累積分數顯示
    /// </summary>
    public Text BP;
    /// <summary>
    /// 玩家B暫存分數顯示
    /// </summary>
    public Text BDP;
    /// <summary>
    /// 骰子圖片UI
    /// </summary>
    public Image DI;
    /// <summary>
    /// 擲骰子按鈕
    /// </summary>
    public Button Play;
    /// <summary>
    /// 保留點數按鈕
    /// </summary>
    public Button Keep;
    /// <summary>
    /// 更換玩家回合判定
    /// </summary>
    public bool player;
    /// <summary>
    /// 輸贏判定
    /// </summary>
    public bool WIN;
    /// <summary>
    /// 玩家A獲勝顯示
    /// </summary>
    public Text WINA;
    /// <summary>
    /// 玩家B獲勝顯示
    /// </summary>
    public Text WINB;
    // Use this for initialization
    void Start() {
        player = false; //玩家A先
        WIN = false;
        Dice = 0;
        DI.sprite = null;
        Ap = 0;
        Bp = 0;
        DAp = 0;
        DBp = 0;
        WINA.text = "玩家A";
        WINB.text = "玩家B";
        Play.onClick.AddListener(delegate ()
        {
            if (WIN == false)
            {
                Dice = Random.Range(1, 7);
                Debug.Log(Dice);
                #region 骰子
                if (Dice == 1)
                {
                    DI.sprite = s1;
                }
                else if (Dice == 2)
                {
                    DI.sprite = s2;
                }
                else if (Dice == 3)
                {
                    DI.sprite = s3;
                }
                else if (Dice == 4)
                {
                    DI.sprite = s4;
                }
                else if (Dice == 5)
                {
                    DI.sprite = s5;
                }
                else if (Dice == 6)
                {
                    DI.sprite = s6;
                }
                #endregion
                if (player == false && Dice != 1)
                {
                    DAp += Dice;
                }
                else if ( Dice == 1 && player == false )
                {
                    DAp = 0;
                    Debug.Log("換B");
                    player = true;
                    Debug.Log("歸0");
                    Dice = 0;
                }
                if (player == true && Dice != 1)
                {
                    DBp += Dice;
                }
                else if ( Dice == 1 && player == true)
                {
                    DBp = 0;                   
                    Debug.Log("換A");
                    player = false;
                    Debug.Log("歸0");
                    Dice = 0;
                }
            }
            
            else if (WIN == true)
            {
                player = false;
                Dice = 0;
                DI.sprite = null;
                Ap = 0;
                Bp = 0;
                DAp = 0;
                DBp = 0;
                WINA.text = "玩家A";
                WINB.text = "玩家B";
                WIN = false;
            }

        });

        Keep.onClick.AddListener(delegate ()
        {
            if (player == false)
            {
                Ap += DAp;
                DAp = 0;
                player = true;
                Debug.Log("換B");

            }
            else if (player == true)
            {
                Bp += DBp;
                DBp = 0;
                player = false;
                Debug.Log("換A");
            }
        });
	}
	
	// Update is called once per frame
	void Update () {
            ADP.text = DAp.ToString();
            AP.text = Ap.ToString();
            BDP.text = DBp.ToString();
            BP.text = Bp.ToString();
        


        if (Ap >= 100 || Bp >= 100)
        {
            WIN = true;
            if (Ap >= 100)
            {
                WINA.text = "玩家A獲勝";
            }
            else
            {
                WINB.text = "玩家B獲勝";
            }
        }

    }
}
