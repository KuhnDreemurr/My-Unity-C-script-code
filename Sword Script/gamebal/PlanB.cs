using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public partial class Play : MonoBehaviour
{
    /// <summary>
    /// 玩家下注
    /// </summary>
    public Text playerG;
    /// <summary>
    /// 玩家籌碼
    /// </summary>
    public Text MTG;
    /// <summary>
    /// 莊家籌碼
    /// </summary>
    public Text PCG;
    /// <summary>
    /// 空白圖片
    /// </summary>
    public Image[] imgs;
    /// <summary>
    /// spr父物件
    /// </summary>
    public GameObject Sprs;
    /// <summary>
    /// 儲存圖片活
    /// </summary>
    public Sprite live;
    /// <summary>
    /// 儲存圖片死
    /// </summary>
    public Sprite dead;
    /// <summary>
    /// 儲存圖片空白
    /// </summary>
    public Sprite No;

    //public int [] it;
    //public PlayerData artP;
    //public DOAData dd2;
    //public Play py;
    // Start is called before the first frame update
    void Art()
    {
        //artP = new PlayerData();
        //artP = JsonUtility.FromJson<PlayerData>(PlayerPrefs.GetString("玩家資料"));

        MTG.text = "玩家籌碼:" + all.coinA.ToString();
        PCG.text = "莊家籌碼:" + all.PC.ToString();
        playerG.text = (string.Format("1號: {0}, 2號: {1}, 3號: {2}, 4號: {3}, 5號: {4}, 6號: {5}, 7號: {6}, 8號: {7}", all.coin[0].ToString(), all.coin[1].ToString(), all.coin[2].ToString(), all.coin[3].ToString(), all.coin[4].ToString(), all.coin[5].ToString(), all.coin[6].ToString(), all.coin[7].ToString()));

        imgs = new Image[8];
        //it = new int[8];
        for (int x = 0; x < imgs.Length; x++)
        {
            imgs[x] = Sprs.transform.Find("NO" + x).GetComponentInChildren<Image>(); //腳本不是掛在父物件上，要記得在transform前面打上父物件名稱 
            imgs[x].sprite = No;
        }

            for (int c = 0; c < select.Length; c++)
            {
            
            //imgs[c].sprite = No;

                if (rot[select[c]] == 0)
                {
                    imgs[select[c]].sprite = live;
                }
                else if (rot[select[c]] == 1)
                {
                    imgs[select[c]].sprite = dead;
                }
                else if (rot[select[c]] == 2)
                {
                    imgs[select[c]].sprite = No;
                }
            }

                MTG.text = "玩家籌碼:" + all.coinA.ToString();
                PCG.text = "莊家籌碼:" + all.PC.ToString();
            
    }
           

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.F))
        //{
        //    PlayerPrefs.DeleteKey("生死判斷");
        //    Debug.Log("資料-全部 刪除完成");
        //}
    }

}
