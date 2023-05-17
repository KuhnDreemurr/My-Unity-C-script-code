using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Art : MonoBehaviour
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
    public PlayerData artP;
    public DOAData dd2;
    public Play py;
    // Start is called before the first frame update
    void Start()
    {
        artP = new PlayerData();
        artP= JsonUtility.FromJson<PlayerData>(PlayerPrefs.GetString("玩家資料"));
        Debug.Log(PlayerPrefs.GetString("生死判斷"));
        dd2 = JsonUtility.FromJson<DOAData>(PlayerPrefs.GetString("生死判斷"));
        MTG.text = "玩家籌碼:" + artP.coinA.ToString();
        PCG.text = "莊家籌碼:" + artP.PC.ToString();
        playerG.text = (string.Format("1號: {0}, 2號: {1}, 3號: {2}, 4號: {3}, 5號: {4}, 6號: {5}, 7號: {6}, 8號: {7}", artP.coin[0].ToString(), artP.coin[1].ToString(), artP.coin[2].ToString(), artP.coin[3].ToString(), artP.coin[4].ToString(), artP.coin[5].ToString(), artP.coin[6].ToString(), artP.coin[7].ToString()));

        imgs = new Image[8];
        //it = new int[8];

        //for (int n = 0; n < it.Length; n++)
        //{
        //    //it[n] = dd2.Fen[n];
        //    Debug.Log("複製後"+it[n]);
        //}

        dd2 = new DOAData();
        dd2 = JsonUtility.FromJson<DOAData>(PlayerPrefs.GetString("生死判斷"));
        //for (int c = 0; c < dd2.Fen.Length; c++)
        //{
        //    Debug.Log(dd2.Fen[c]);
        //}

        //for (int g = 0; g < imgs.Length; g++)
        //{
        //    it[g] = dd2.Fen[g];
        //}

        for (int c = 0; c < imgs.Length; c++)
        {
            imgs[c] = Sprs.transform.Find("NO" + c).GetComponentInChildren<Image>(); //腳本不是掛在父物件上，要記得在transform前面打上父物件名稱 
            imgs[c].sprite = No;
        }
        //Debug.Log(py.select.Length);
        //Debug.Log(py.rot.Length);
        for (int d = 0; d < py.select.Length; d++)
        {
            py.select[d] = dd2.Fen[d];
            py.rot[d] = dd2.Rint[d];
            //Debug.Log(py.select[d]);
            //Debug.Log(py.rot[d]);
            if (py.rot[py.select[d]] == 0)
            {
                imgs[py.select[d]].sprite = live;
            }
            else if (py.rot[py.select[d]] == 1)
            {
                imgs[py.select[d]].sprite = dead;
            }
            else if (py.rot[py.select[d]] == 2)
            {
                imgs[py.select[d]].sprite = No;
            }
        }

        //    for (int d = 0; d < py.select.Length; d++)
        //{             
        //    for (int a = 0; a < imgs.Length; a++)
        //    {

        //        if (artP.coin[a] != 0)
        //        {
        //            if (py.rot[d] == 0)
        //            {
        //                imgs[py.select[d]].sprite = live;
        //                end = DOA.生;
        //            }
        //            if (py.rot[d] == 1)
        //            {
        //                imgs[py.select[d]].sprite = dead;
        //                end = DOA.死;
        //            }
        //        }
        //        else if (artP.coin[a] == 0)
        //        {
        //            Debug.Log(a + "號" + "Safe");
        //        }
        MTG.text = "玩家籌碼:" + artP.coinA.ToString();
                PCG.text = "莊家籌碼:" + artP.PC.ToString();
    }
           

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            PlayerPrefs.DeleteKey("生死判斷");
            Debug.Log("資料-全部 刪除完成");
        }
    }

}
