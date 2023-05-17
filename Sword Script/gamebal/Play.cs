using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
public partial class Play : MonoBehaviour
//public class Play : MonoBehaviour
{
    public RawImage op;
    public VideoPlayer opV;
    public PlayerData all;
    public Image win;
    public Image lose;
    //public DOAData dd;
    /// <summary>
    /// 劍的位置
    /// </summary>
    public int[] select;
    /// <summary>
    /// 生或死或空白
    /// </summary>
    public int[] rot;
    public DOA end;
    /// <summary>
    /// 抽位子
    /// </summary>
    public int a;
    /// <summary>
    /// 抽生死
    /// </summary>
    public int b;

    // Start is called before the first frame update
    void Start()
    {
        opV.loopPointReached += check;
        select = new int[4];
        rot = new int[8];

        all = new PlayerData();
        all = JsonUtility.FromJson<PlayerData>(PlayerPrefs.GetString("玩家資料"));

        //dd = new DOAData();
        //dd.Fen = new int[4];
        //dd.Rint = new int[8];
        Debug.Log(PlayerPrefs.GetString("玩家資料"));

        for (int x = 0; x < rot.Length; x++)
        {
            rot[x] = 2;
        }
        for (a = 0; a < select.Length; a++)
        {
            select[a] = Random.Range(0, 8);
            Debug.Log("選擇第"+a+"位"+select[a]);
            rot[select[a]] = Random.Range(0, 3);
            Debug.Log("第"+select[a]+"位生死:"+rot[select[a]]);

        }

        for (b = 0; b < select.Length; b++)
        {
            if (all.coin[select[b]] != 0)
            {
                if (rot[select[b]] == 0)
                {
                    all.coinA += (all.coin[select[b]] * 30);
                    all.PC -= (all.coin[select[b]] * 30);
                    end = DOA.生;
                    Debug.Log("下注結果第" + (select[b] + 1) + "號生");

                }
                else if (rot[select[b]] == 1)
                {
                    all.coinA -= (all.coin[select[b]] * 30);
                    all.PC += (all.coin[select[b]] * 30);
                    end = DOA.死;
                    Debug.Log("下注結果第" + (select[b] + 1) + "號死");
                }
                else if (rot[select[b]] == 2)
                {
                    end = DOA.無;
                    Debug.Log("下注結果第" + (select[b] + 1) + "號Safe");
                }

            }
            else if(all.coin[select[b]] ==0)
            {
                if (rot[select[b]] == 0)
                    Debug.Log("第"+ (select[b] + 1) + "號下注Miss生");
                else if (rot[select[b]] == 1)
                    Debug.Log("第" + (select[b] + 1) + "號下注Miss死");
                else if (rot[select[b]] ==2)
                    Debug.Log("第" + (select[b] + 1) + "號下注Miss無");
            }

            //dd.Fen[b] = select[b];
            //dd.Rint[b] = rot[b];
           // Debug.Log(dd.Fen[b]);
        }

        if (all.PC <= 0)
        {
            Invoke("lag",3f);
            PlayerPrefs.DeleteAll();
            Debug.Log("資料-全部 刪除完成");
        }
        else if (all.coinA <= 0)
        {
            Invoke("lagL", 3f);
            PlayerPrefs.DeleteAll();
            Debug.Log("資料-全部 刪除完成");
        }
        all.MM = all.coinA;
        //寫jason存檔

        //string LOL;
        //LOL = JsonUtility.ToJson(dd);
        //PlayerPrefs.SetString("生死判斷", LOL);
        //PlayerPrefs.Save();

        string XD;
        XD = JsonUtility.ToJson(all);
        PlayerPrefs.SetString("玩家資料", XD);
        PlayerPrefs.Save();
        Art();

    }

    void check(UnityEngine.Video.VideoPlayer vp)
    {
        op.gameObject.SetActive(false);
     }

    void lag()
    {
        win.gameObject.SetActive(true);
    }
    void lagL()
    {
        lose.gameObject.SetActive(true);
    }

}

[System.Serializable]
public class IntData
{
/// <summary>
/// random出來的數字丟進來
/// </summary>
    public int[] iran;
/// <summary>
/// 檢測出現重複的就++計算次數
/// </summary>
    public int irc;
}

public enum DOA
{
    生,
    死,
    無,
}