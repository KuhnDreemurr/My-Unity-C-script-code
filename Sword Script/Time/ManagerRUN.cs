using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ManagerRUN : MonoBehaviour
{
    /// <summary>
    /// 下注時間
    /// </summary>
    public float Times;
    /// <summary>
    /// 下注時間顯示
    /// </summary>
    public Text Timetxt;
    public Count _ct;
    #region 宣告按鈕&下注文字
    public Text[] Ptxt;
    public GameObject Gtxt;
    /// <summary>
    /// Jason要打包的資料
    /// </summary>
    public PlayerData jp;
    /// <summary>
    /// 可用籌碼顯示文字
    /// </summary>
    public Text MT;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(_ct.PM.Length);
        Times = 10;
        Numtxt();
        jp = new PlayerData();
        jp.coin = new int[8];
    }

    // Update is called once per frame
    void Update()
    {
        Timetxt.text = Times.ToString("0");
        TimeC();
        jp.MM = _ct.Money;
        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    PlayerPrefs.DeleteAll();
        //    Debug.Log("資料-全部 刪除完成");
        //}
    }
    /// <summary>
    /// 建立下注表
    /// </summary>
    public void Numtxt()
    {
        Ptxt = new Text[Gtxt.transform.childCount];
        for (int i = 0; i < Gtxt.transform.childCount; i++)
        {
            //腳本不是掛在父物件上，要在transform前面加上父物件的名稱
            Ptxt[i] = Gtxt.transform.Find("TX" + i).GetComponentInChildren<Text>();
        }

    }

    public void TimeC()
    {
        string JS;
        if (Times > 0)
        {
            Times -= Time.deltaTime;

            for (int i = 0; i < 8; i++)
            {
                Ptxt[i].text = _ct.PM[i].ToString();
                MT.text = _ct.Money.ToString();
                //Debug.Log(_ct.PM[i]);
            }
        }
        else
        {
            //jason存檔
            for (int i = 0; i < _ct.PM.Length; i++)
            {
                int tindex;
                tindex = i;
                jp.coin[tindex] = _ct.PM[tindex];
                jp.coinA=(jp.MM += jp.coin[tindex]);
                //Debug.Log(tindex+":"+_ct.PM[tindex].ToString());
                //Debug.Log(JS);
            }
            jp.PC = _ct.PCM;
            JS = JsonUtility.ToJson(jp);
            //Debug.Log("JSON格式資料 : " + JS); //*用字串處理去解析*
            //PlayerPrefs儲存jason格式string資料
            PlayerPrefs.SetString("玩家資料", JS);
            PlayerPrefs.Save();

            SceneManager.LoadScene("gamebal");
        }
    }
}

