using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour {
    Bone BC;
    public int C;
    public Text score;
    public string High;
    public float S;
    public GameObject objPre;
    public GameObject PL;
    public GameObject BA;
    public Button play;
    public Button back;
    // Use this for initialization
    void Start () {
        BC = new Bone(); //1.需將引用的腳本命名縮寫並實例化,稱為建構子 引用Bone腳本的東西 
        score.enabled = true;
        S = 0;
        score.text = S.ToString();
        if (PlayerPrefs.HasKey("分數"))
        {
            High = PlayerPrefs.GetString("分數");
        }
        else
        {
            High = "0";
        }

        play.onClick.AddListener(delegate ()
        {
            SceneManager.LoadScene("Google");
        });

        back.onClick.AddListener(delegate ()
        {
            SceneManager.LoadScene("Menu");
        });
    }
	
	// Update is called once per frame
	void Update () {
        C = Random.Range(0, 71);
        if (Google.live == true) //2.複合 被調用的變數須在原腳本變數前加上public static全域靜態
        {
            if(C==70)
            {
                BC.Creat(objPre);
            }
            FrameTimeEvent();           
        }
        if (Google.live == false)
        {
            if (S >= float.Parse(High))
            {
                PlayerPrefs.SetString("分數", S.ToString("0"));
                PlayerPrefs.Save();
                Debug.Log(High);
                Debug.Log("資料-全部 存檔完成");
            }
            // Destroy(score);
            score.enabled = false;
            PL.SetActive(true);
            BA.SetActive(true);
        }
    }

    void FrameTimeEvent()
    {
        //至下一偵(frame)所花時間(為了遊戲公平性 解釋給同學聽吧!!)、也可用來做計時器。
        S += (Time.deltaTime) / 2;
        score.text = S.ToString("0") + "M";
    }
}
