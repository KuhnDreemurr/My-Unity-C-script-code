using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Count : MonoBehaviour
{
    /// <summary>
    /// 可用籌碼
    /// </summary>
    public int Money;
    /// <summary>
    /// 儲存玩家下注資料
    /// </summary>
    public int[]PM;
    /// <summary>
    /// 建構
    /// </summary>
    public PlayerData CPD;
    /// <summary>
    /// 莊家籌碼
    /// </summary>
    public int PCM;

    // Start is called before the first frame update
    void Start()
    {
        Begin();
        //Begin2();
        //ButAC();
        //ButBC();
    }

    // Update is called once per frame
    void Update()
    {

    }
    /// <summary>
    /// 初始化玩家下注
    /// </summary>
    public void Begin()
    {
        PM = new int[8];

        if (PlayerPrefs.HasKey("玩家資料"))
        {
            Debug.Log(PlayerPrefs.GetString("玩家資料"));
            CPD = new PlayerData();
            CPD = JsonUtility.FromJson<PlayerData>(PlayerPrefs.GetString("玩家資料"));
            if (CPD.MM > 0 && CPD.PC >0)
            {
                for (int a = 0; a < 8; a++)
                {
                    PM[a] = 0;
                }
                Money = CPD.MM;
                PCM = CPD.PC;
            }
            else
            {
                for (int a = 0; a < 8; a++)
                {
                    PM[a] = 0;
                }
                Money = 300;
                PCM = 300;
            }

        }
        else
        {
            for (int a = 0; a < 8; a++)
            {
                PM[a] = 0;
            }
            Money = 300;
            PCM = 300;
        }
        #region 舊版暴力寫法
        //if (PlayerPrefs.HasKey("玩家下注1"))
        //    PM[0] = PlayerPrefs.GetInt("玩家下注1");
        //if (PlayerPrefs.HasKey("玩家下注2"))
        //    PM[1] = PlayerPrefs.GetInt("玩家下注2");
        //if (PlayerPrefs.HasKey("玩家下注3"))
        //    PM[2] = PlayerPrefs.GetInt("玩家下注3");
        //if (PlayerPrefs.HasKey("玩家下注4"))
        //    PM[3] = PlayerPrefs.GetInt("玩家下注4");
        //if (PlayerPrefs.HasKey("玩家下注5"))
        //    PM[4] = PlayerPrefs.GetInt("玩家下注5");
        //if (PlayerPrefs.HasKey("玩家下注6"))
        //    PM[5] = PlayerPrefs.GetInt("玩家下注6");
        //if (PlayerPrefs.HasKey("玩家下注7"))
        //    PM[6] = PlayerPrefs.GetInt("玩家下注7");
        //if (PlayerPrefs.HasKey("玩家下注8"))
        //    PM[7] = PlayerPrefs.GetInt("玩家下注8");
        #endregion
    }

    //public void Begin2()
    //{
    //    if (PlayerPrefs.HasKey("可用籌碼"))
    //    {
    //        Debug.Log(PlayerPrefs.GetInt("可用籌碼"));
    //        Money = PlayerPrefs.GetInt("可用籌碼");
    //        Debug.Log(Money);
    //    }
    //    else
    //    {
    //        Money = 1000;
    //        Debug.Log(Money);
    //    }
    //    Debug.Log("Begin已執行");
    //}

    //public void NbA()
    //{
    //    PM[i] += 1;
    //    Money -= 1;
    //    MT.text = Money.ToString();
    //}

    //public void ButAC()
    //{
    //    btA1.onClick.AddListener(delegate()
    //    {
    //        PM[0] += 1;
    //        Money -= 1;
    //        MT.text = Money.ToString();
    //    });
    //    btA2.onClick.AddListener(delegate ()
    //    {
    //        PM[1] += 1;
    //        Money -= 1;
    //        MT.text = Money.ToString();
    //    });
    //    btA3.onClick.AddListener(delegate ()
    //    {
    //        PM[2] += 1;
    //        Money -= 1;
    //        MT.text = Money.ToString();
    //    });
    //    btA4.onClick.AddListener(delegate ()
    //    {
    //        PM[3] += 1;
    //        Money -= 1;
    //        MT.text = Money.ToString();
    //    });
    //    btA5.onClick.AddListener(delegate ()
    //    {
    //        PM[4] += 1;
    //        Money -= 1;
    //        MT.text = Money.ToString();
    //    });
    //    btA6.onClick.AddListener(delegate ()
    //    {
    //        PM[5] += 1;
    //        Money -= 1;
    //        MT.text = Money.ToString();
    //    });
    //    btA7.onClick.AddListener(delegate ()
    //    {
    //        PM[6] += 1;
    //        Money -= 1;
    //        MT.text = Money.ToString();
    //    });
    //    btA8.onClick.AddListener(delegate ()
    //    {
    //        PM[7] += 1;
    //        Money -= 1;
    //        MT.text = Money.ToString();
    //    });
    //}

    //public void ButBC()
    //{
    //    btB1.onClick.AddListener(delegate ()
    //    {
    //        PM[0] -= 1;
    //        Money += 1;

    //    });
    //    btB2.onClick.AddListener(delegate ()
    //    {
    //        PM[1] -= 1;
    //        Money += 1;

    //    });
    //    btB3.onClick.AddListener(delegate ()
    //    {
    //        PM[2] -= 1;
    //        Money += 1;

    //    });
    //    btB4.onClick.AddListener(delegate ()
    //    {
    //        PM[3] -= 1;
    //        Money += 1;

    //    });
    //    btB5.onClick.AddListener(delegate ()
    //    {
    //        PM[4] -= 1;
    //        Money += 1;

    //    });
    //    btB6.onClick.AddListener(delegate ()
    //    {
    //        PM[5] -= 1;
    //        Money += 1;

    //    });
    //    btB7.onClick.AddListener(delegate ()
    //    {
    //        PM[6] -= 1;
    //        Money += 1;

    //    });
    //    btB8.onClick.AddListener(delegate ()
    //    {
    //        PM[7] -= 1;
    //        Money += 1;

    //    });
    //}


    //else
    //{
    //    PlayerPrefs.SetInt("可用籌碼",Money);
    //    PlayerPrefs.SetInt("玩家下注1",PM[0]);
    //    PlayerPrefs.SetInt("玩家下注2", PM[1]);
    //    PlayerPrefs.SetInt("玩家下注3", PM[2]);
    //    PlayerPrefs.SetInt("玩家下注4", PM[3]);
    //    PlayerPrefs.SetInt("玩家下注5", PM[4]);
    //    PlayerPrefs.SetInt("玩家下注6", PM[5]);
    //    PlayerPrefs.SetInt("玩家下注7", PM[6]);
    //    PlayerPrefs.SetInt("玩家下注8", PM[7]);
    //    PlayerPrefs.Save();
    //    Debug.Log("儲存剩餘籌碼");
    //    //記得切換場景
    //}


}
