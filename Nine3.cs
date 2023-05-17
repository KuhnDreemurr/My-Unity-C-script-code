using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//用bool去判定按鈕已按過,去阻止重複按
public class Nine3 : MonoBehaviour {
    public Work w;
    public Button[] btn0 = new Button[3];
    public Button[] btn1 = new Button[3];
    public Button[] btn2 = new Button[3];
    public Text[] txt0 = new Text[3];
    public Text[] txt1 = new Text[3];
    public Text[] txt2 = new Text[3];
    public bool[,] bN = new bool[3, 3];
    public bool b2;
    public int i;
    public Text OX;
    public int[] tf = new int[9];
    public PlayerData _PlayerData;
    public string s2cString;
    // Use this for initialization
    void Start()
    {
        if(PlayerPrefs.HasKey("jasonooxx")==false)
        {
            ReS();
            jasonooxx();
            Debug.Log(PlayerPrefs.GetString("jasonooxx"));
        }
        s2cString = PlayerPrefs.GetString("jasonooxx");
        if (PlayerPrefs.HasKey("jasonooxx") != false)
        {
            i = JsonUtility.FromJson<PlayerData>(s2cString).turn;
            w = (Work)JsonUtility.FromJson<PlayerData>(s2cString).ww;//轉型enum  
            txt0[0].text = JsonUtility.FromJson<PlayerData>(s2cString).ooxx.Substring(0, 1);
            txt0[1].text = JsonUtility.FromJson<PlayerData>(s2cString).ooxx.Substring(2, 1);
            txt0[2].text = JsonUtility.FromJson<PlayerData>(s2cString).ooxx.Substring(4, 1);
            txt1[0].text = JsonUtility.FromJson<PlayerData>(s2cString).ooxx.Substring(6, 1);
            txt1[1].text = JsonUtility.FromJson<PlayerData>(s2cString).ooxx.Substring(8, 1);
            txt1[2].text = JsonUtility.FromJson<PlayerData>(s2cString).ooxx.Substring(10, 1);
            txt2[0].text = JsonUtility.FromJson<PlayerData>(s2cString).ooxx.Substring(12, 1);
            txt2[1].text = JsonUtility.FromJson<PlayerData>(s2cString).ooxx.Substring(14, 1);
            txt2[2].text = JsonUtility.FromJson<PlayerData>(s2cString).ooxx.Substring(16, 1);
            if (JsonUtility.FromJson<PlayerData>(s2cString).oxtf.Substring(0, 1) == "0")
            {
                bN[0,0] = false;
            }
            else if (JsonUtility.FromJson<PlayerData>(s2cString).oxtf.Substring(0, 1) == "1")
            {
                bN[0,0] = true;
            }

            if (JsonUtility.FromJson<PlayerData>(s2cString).oxtf.Substring(1, 1) == "0")
            {
                bN[0,1] = false;
            }
            else if (JsonUtility.FromJson<PlayerData>(s2cString).oxtf.Substring(1, 1) == "1")
            {
                bN[0,1] = true;
            }

            if (JsonUtility.FromJson<PlayerData>(s2cString).oxtf.Substring(2, 1) == "0")
            {
                bN[0,2] = false;
            }
            else if (JsonUtility.FromJson<PlayerData>(s2cString).oxtf.Substring(2, 1) == "1")
            {
                bN[0,2] = true;
            }

            if (JsonUtility.FromJson<PlayerData>(s2cString).oxtf.Substring(3, 1) == "0")
            {
                bN[1, 0] = false;
            }
            else if (JsonUtility.FromJson<PlayerData>(s2cString).oxtf.Substring(3, 1) == "1")
            {
                bN[1, 0] = true;
            }

            if (JsonUtility.FromJson<PlayerData>(s2cString).oxtf.Substring(4, 1) == "0")
            {
                bN[1, 1] = false;
            }
            else if (JsonUtility.FromJson<PlayerData>(s2cString).oxtf.Substring(4, 1) == "1")
            {
                bN[1, 1] = true;
            }

            if (JsonUtility.FromJson<PlayerData>(s2cString).oxtf.Substring(5, 1) == "0")
            {
                bN[1, 2] = false;
            }
            else if (JsonUtility.FromJson<PlayerData>(s2cString).oxtf.Substring(5, 1) == "1")
            {
                bN[1, 2] = true;
            }

            if (JsonUtility.FromJson<PlayerData>(s2cString).oxtf.Substring(6, 1) == "0")
            {
                bN[2, 0] = false;
            }
            else if (JsonUtility.FromJson<PlayerData>(s2cString).oxtf.Substring(6, 1) == "1")
            {
                bN[2, 0] = true;
            }

            if (JsonUtility.FromJson<PlayerData>(s2cString).oxtf.Substring(7, 1) == "0")
            {
                bN[2, 1] = false;
            }
            else if (JsonUtility.FromJson<PlayerData>(s2cString).oxtf.Substring(7, 1) == "1")
            {
                bN[2, 1] = true;
            }

            if (JsonUtility.FromJson<PlayerData>(s2cString).oxtf.Substring(8, 1) == "0")
            {
                bN[2, 2] = false;
            }
            else if (JsonUtility.FromJson<PlayerData>(s2cString).oxtf.Substring(8, 1) == "1")
            {
                bN[2, 2] = true;
            }

            if (JsonUtility.FromJson<PlayerData>(s2cString).WL.ToString().Substring(0, 1) == "0")
            {
                b2 = false;
            }
            else if (JsonUtility.FromJson<PlayerData>(s2cString).WL.ToString().Substring(0, 1) == "1")
            {
                b2 = true;
            }
            OX.text = JsonUtility.FromJson<PlayerData>(s2cString).gg.Substring(0, 5);
            jasonooxx();
            Debug.Log(PlayerPrefs.GetString("jasonooxx"));
        }



        OOXX();
    }
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.D))
        {
            PlayerPrefs.DeleteAll();
            Debug.Log("資料-全部 刪除完成");
        }
    }
    /// <summary>
    /// OOXX程式碼
    /// </summary>
    void OOXX()
    {
        Button[,]btn = new Button[3, 3];
        Text[,]txt = new Text[3, 3];
        btn[0, 0] = btn0[0];
        btn[0, 1] = btn0[1];
        btn[0, 2] = btn0[2];
        btn[1, 0] = btn1[0];
        btn[1, 1] = btn1[1];
        btn[1, 2] = btn1[2];
        btn[2, 0] = btn2[0];
        btn[2, 1] = btn2[1];
        btn[2, 2] = btn2[2];
        txt[0, 0] = txt0[0];
        txt[0, 1] = txt0[1];
        txt[0, 2] = txt0[2];
        txt[1, 0] = txt1[0];
        txt[1, 1] = txt1[1];
        txt[1, 2] = txt1[2];
        txt[2, 0] = txt2[0];
        txt[2, 1] = txt2[1];
        txt[2, 2] = txt2[2];
        btn[0,0].onClick.AddListener(delegate ()
        {
            if (bN[0,0] == false && b2 == false)
            {
                i = i + 1;
                if (i % 2 == 1)
                {
                    w = Work.O;
                }
                else if (i % 2 == 0)
                {
                    w = Work.X;
                }
                string s = w.ToString();
                Debug.Log(i + ":" + s);

                if (w == Work.O)
                {
                    bN[0,0] = true;
                    txt[0,0].text = "O";
                }
                else if (w == Work.X)
                {
                    bN[0,0] = true;
                    txt[0,0].text = "X";
                }
                Debug.Log(txt0[0].text+","+txt0[1].text+","+txt0[2].text+"\n"
                    +txt1[0].text + "," + txt1[1].text + "," + txt1[2].text + "\n" 
                    + txt2[0].text + "," + txt2[1].text + "," + txt2[2].text);

                if (txt[0,0].text == "O" && txt[0,1].text == "O" && txt[0,2].text == "O" || txt[0,0].text == "O" && txt[1,0].text == "O" && txt[2,0].text == "O" ||
                    txt[0,0].text == "O" && txt[1,1].text == "O" && txt[2,2].text == "O"
                    )
                {
                    Debug.Log("圈圈win");
                    OX.text = "圈圈win";
                    b2 = true;
                }
                else if (txt[0,0].text == "X" && txt[0,1].text == "X" && txt[0,2].text == "X" || txt[0,0].text == "X" && txt[1,0].text == "X" && txt[2,0].text == "X" ||
                        txt[0,0].text == "X" && txt[1,1].text == "X" && txt[2,2].text == "X"
                        )
                {
                    Debug.Log("叉叉win");
                    OX.text = "叉叉win";
                    b2 = true;
                }
            }
            jasonooxx();
         
        });



        btn[0,1].onClick.AddListener(delegate ()
        {
            if (bN[0,1] == false && b2 == false)
            {
                i = i + 1;
                if (i % 2 == 1)
                {
                    w = Work.O;
                }
                else if (i % 2 == 0)
                {
                    w = Work.X;
                }
                string s = w.ToString();
                Debug.Log(i + ":" + s);

                if (w == Work.O)
                {
                    txt[0,1].text = "O";
                    bN[0,1] = true;
                }
                else if (w == Work.X)
                {
                    txt[0,1].text = "X";
                    bN[0,1] = true;
                }
                    Debug.Log(txt0[0].text+","+txt0[1].text+","+txt0[2].text+"\n"
                    +txt1[0].text + "," + txt1[1].text + "," + txt1[2].text + "\n" 
                    + txt2[0].text + "," + txt2[1].text + "," + txt2[2].text);
                if (txt[0,1].text == "O" && txt[0,0].text == "O" && txt[0,2].text == "O" || txt[0,1].text == "O" && txt[1,1].text == "O" && txt[2,1].text == "O")
                {
                    Debug.Log("圈圈win");
                    OX.text = "圈圈win";
                    b2 = true;
                }
                else if (txt[0,1].text == "X" && txt[0,0].text == "X" && txt[0,2].text == "X" || txt[0,1].text == "O" && txt[1,1].text == "X" && txt[2,1].text == "X")
                {
                    Debug.Log("叉叉win");
                    OX.text = "叉叉win";
                    b2 = true;
                }
            }
            jasonooxx();

        });



        btn[0,2].onClick.AddListener(delegate ()
        {
            if (bN[0,2] == false && b2 == false)
            {
                i = i + 1;
                if (i % 2 == 1)
                {
                    w = Work.O;
                }
                else if (i % 2 == 0)
                {
                    w = Work.X;
                }
                string s = w.ToString();
                Debug.Log(i + ":" + s);

                if (w == Work.O)
                {
                    txt[0,2].text = "O";
                    bN[0,2] = true;
                }
                else if (w == Work.X)
                {
                    txt[0,2].text = "X";
                    bN[0,2] = true;
                }
                     Debug.Log(txt0[0].text+","+txt0[1].text+","+txt0[2].text+"\n"
                    +txt1[0].text + "," + txt1[1].text + "," + txt1[2].text + "\n" 
                    + txt2[0].text + "," + txt2[1].text + "," + txt2[2].text);

                if (txt[0,2].text == "O" && txt[0,0].text == "O" && txt[0,1].text == "O" || txt[0,2].text == "O" && txt[1,2].text == "O" && txt[2,2].text == "O" || txt[0,2].text == "O" && txt[1,1].text == "O" && txt[2,0].text == "O")
                {
                    Debug.Log("圈圈win");
                    OX.text = "圈圈win";
                    b2 = true;
                }
                else if (txt[0,2].text == "X" && txt[0,0].text == "X" && txt[0,1].text == "X" || txt[0,2].text == "X" && txt[1,2].text == "X" && txt[2,2].text == "X" || txt[0,2].text == "X" && txt[1,1].text == "X" && txt[2,0].text == "X")
                {
                    Debug.Log("叉叉win");
                    OX.text = "叉叉win";
                    b2 = true;
                }
            }
            jasonooxx();

        });



        btn[1,0].onClick.AddListener(delegate ()
        {
            if (bN[1,0] == false && b2 == false)
            {
                i = i + 1;
                if (i % 2 == 1)
                {
                    w = Work.O;
                }
                else if (i % 2 == 0)
                {
                    w = Work.X;
                }
                string s = w.ToString();
                Debug.Log(i + ":" + s);

                if (w == Work.O)
                {
                    txt[1,0].text = "O";
                    bN[1,0] = true;
                }
                else if (w == Work.X)
                {
                    txt[1,0].text = "X";
                    bN[1,0] = true;
                }
                     Debug.Log(txt0[0].text+","+txt0[1].text+","+txt0[2].text+"\n"
                    +txt1[0].text + "," + txt1[1].text + "," + txt1[2].text + "\n" 
                    + txt2[0].text + "," + txt2[1].text + "," + txt2[2].text);
                if (txt[1,0].text == "O" && txt[1,1].text == "O" && txt[1,2].text == "O" || txt[1,0].text == "O" && txt[0,0].text == "O" && txt[2,0].text == "O")
                {
                    Debug.Log("圈圈win");
                    OX.text = "圈圈win";
                    b2 = true;
                }
                else if (txt[1,0].text == "X" && txt[1,1].text == "X" && txt[1,2].text == "X" || txt[1,0].text == "X" && txt[0,0].text == "X" && txt[2,0].text == "X")
                {
                    Debug.Log("叉叉win");
                    OX.text = "叉叉win";
                    b2 = true;
                }
            }
            jasonooxx();

        });



        btn[1,1].onClick.AddListener(delegate ()
        {
            if (bN[1,1] == false && b2 == false)
            {
                i = i + 1;
                if (i % 2 == 1)
                {
                    w = Work.O;
                }
                else if (i % 2 == 0)
                {
                    w = Work.X;
                }
                string s = w.ToString();
                Debug.Log(i + ":" + s);

                if (w == Work.O)
                {
                    txt[1,1].text = "O";
                    bN[1,1] = true;
                }
                else if (w == Work.X)
                {
                    txt[1,1].text = "X";
                    bN[1,1] = true;
                }
                Debug.Log(txt0[0].text + "," + txt0[1].text + "," + txt0[2].text + "\n"
                + txt1[0].text + "," + txt1[1].text + "," + txt1[2].text + "\n"
                + txt2[0].text + "," + txt2[1].text + "," + txt2[2].text);

                if (txt[1,1].text == "O" && txt[1,0].text == "O" && txt[1,2].text == "O" || txt[1,1].text == "O" && txt[0,1].text == "O" && txt[2,1].text == "O" ||
                    txt[1,1].text == "O" && txt[0,0].text == "O" && txt[2,2].text == "O" || txt[1,1].text == "O" && txt[0,2].text == "O" && txt[2,0].text == "O"
                   )
                {
                    Debug.Log("圈圈win");
                    OX.text = "圈圈win";
                    b2 = true;
                }
                else if (txt[1,1].text == "X" && txt[1,0].text == "X" && txt[1,2].text == "X" || txt[1,1].text == "X" && txt[0,1].text == "X" && txt[2,1].text == "X" ||
                        txt[1,1].text == "X" && txt[0,0].text == "X" && txt[2,2].text == "X" || txt[1,1].text == "X" && txt[0,2].text == "X" && txt[2,0].text == "X"
                        )
                {
                    Debug.Log("叉叉win");
                    OX.text = "叉叉win";
                    b2 = true;
                }
            }
            jasonooxx();

        });



        btn[1,2].onClick.AddListener(delegate ()
        {
            if (bN[1,2] == false && b2 == false)
            {
                i = i + 1;
                if (i % 2 == 1)
                {
                    w = Work.O;
                }
                else if (i % 2 == 0)
                {
                    w = Work.X;
                }
                string s = w.ToString();
                Debug.Log(i + ":" + s);

                if (w == Work.O)
                {
                    txt[1,2].text = "O";
                    bN[1,2] = true;
                }
                else if (w == Work.X)
                {
                    txt[1,2].text = "X";
                    bN[1,2] = true;
                }
                 Debug.Log(txt0[0].text + "," + txt0[1].text + "," + txt0[2].text + "\n"
                + txt1[0].text + "," + txt1[1].text + "," + txt1[2].text + "\n"
                + txt2[0].text + "," + txt2[1].text + "," + txt2[2].text);

                if (txt[1,2].text == "O" && txt[1,0].text == "O" && txt[1,1].text == "O" || txt[1,2].text == "O" && txt[0,2].text == "O" && txt[2,2].text == "O")
                {
                    Debug.Log("圈圈win");
                    OX.text = "圈圈win";
                    b2 = true;
                }
                else if (txt[1,2].text == "X" && txt[1,0].text == "X" && txt[1,1].text == "X" || txt[1,2].text == "X" && txt[0,2].text == "X" && txt[2,2].text == "X")
                {
                    Debug.Log("叉叉win");
                    OX.text = "叉叉win";
                    b2 = true;
                }
            }
            jasonooxx();

        });


        btn[2,0].onClick.AddListener(delegate ()
        {
            if (bN[2,0] == false && b2 == false)
            {
                i = i + 1;
                if (i % 2 == 1)
                {
                    w = Work.O;
                }
                else if (i % 2 == 0)
                {
                    w = Work.X;
                }
                string s = w.ToString();
                Debug.Log(i + ":" + s);

                if (w == Work.O)
                {
                    txt[2,0].text = "O";
                    bN[2,0] = true;
                }
                else if (w == Work.X)
                {
                    txt[2,0].text = "X";
                    bN[2,0] = true;
                }
                Debug.Log(txt0[0].text + "," + txt0[1].text + "," + txt0[2].text + "\n"
                + txt1[0].text + "," + txt1[1].text + "," + txt1[2].text + "\n"
                + txt2[0].text + "," + txt2[1].text + "," + txt2[2].text);
                if (txt[2,0].text == "O" && txt[2,1].text == "O" && txt[2,2].text == "O" || txt[2,0].text == "O" && txt[0,0].text == "O" && txt[1,0].text == "O" || txt[2,0].text == "O" && txt[1,1].text == "O" && txt[0,2].text == "O")
                {
                    Debug.Log("圈圈win");
                    OX.text = "圈圈win";
                    b2 = true;
                }
                else if (txt[2,0].text == "X" && txt[2,1].text == "X" && txt[2,2].text == "X" || txt[2,0].text == "X" && txt[0,0].text == "X" && txt[1,0].text == "X" || txt[2,0].text == "X" && txt[1,1].text == "X" && txt[0,2].text == "X")
                {
                    Debug.Log("叉叉win");
                    OX.text = "叉叉win";
                    b2 = true;
                }
            }
            jasonooxx();

        });



        btn[2,1].onClick.AddListener(delegate ()
        {
            if (bN[2,1] == false && b2 == false)
            {
                i = i + 1;
                if (i % 2 == 1)
                {
                    w = Work.O;
                }
                else if (i % 2 == 0)
                {
                    w = Work.X;
                }
                string s = w.ToString();
                Debug.Log(i + ":" + s);

                if (w == Work.O)
                {
                    txt[2,1].text = "O";
                    bN[2,1] = true;
                }
                else if (w == Work.X)
                {
                    txt[2,1].text = "X";
                    bN[2,1] = true;
                }
                Debug.Log(txt0[0].text + "," + txt0[1].text + "," + txt0[2].text + "\n"
                + txt1[0].text + "," + txt1[1].text + "," + txt1[2].text + "\n"
                + txt2[0].text + "," + txt2[1].text + "," + txt2[2].text);
                if (txt[2,1].text == "O" && txt[2,0].text == "O" && txt[2,2].text == "O" || txt[2,1].text == "O" && txt[0,1].text == "O" && txt[1,1].text == "O")
                {
                    Debug.Log("圈圈win");
                    OX.text = "圈圈win";
                    b2 = true;
                }
                else if (txt[2,1].text == "X" && txt[2,0].text == "X" && txt[2,2].text == "X" || txt[2,1].text == "X" && txt[0,1].text == "X" && txt[1,1].text == "X")
                {
                    Debug.Log("叉叉win");
                    OX.text = "叉叉win";
                    b2 = true;
                }
            }
            jasonooxx();

        });

        btn[2,2].onClick.AddListener(delegate ()
        {
            if (bN[2,2] == false && b2 == false)
            {
                i = i + 1;
                if (i % 2 == 1)
                {
                    w = Work.O;
                }
                else if (i % 2 == 0)
                {
                    w = Work.X;
                }
                string s = w.ToString();
                Debug.Log(i + ":" + s);

                if (w == Work.O)
                {
                    txt[2,2].text = "O";
                    bN[2,2] = true;
                }
                else if (w == Work.X)
                {
                    txt[2,2].text = "X";
                    bN[2,2] = true;
                }
                Debug.Log(txt0[0].text + "," + txt0[1].text + "," + txt0[2].text + "\n"
                + txt1[0].text + "," + txt1[1].text + "," + txt1[2].text + "\n"
                + txt2[0].text + "," + txt2[1].text + "," + txt2[2].text);
                if (txt[2,2].text == "O" && txt[2,0].text == "O" && txt[2,1].text == "O" || txt[2,2].text == "O" && txt[0,2].text == "O" && txt[1,2].text == "O" || txt[2,2].text == "O" && txt[0,0].text == "O" && txt[1,1].text == "O")
                {
                    Debug.Log("圈圈win");
                    OX.text = "圈圈win";
                    b2 = true;
                }
                else if (txt[2,2].text == "X" && txt[2,0].text == "X" && txt[2,1].text == "X" || txt[2,2].text == "X" && txt[0,2].text == "X" && txt[1,2].text == "X" || txt[2,2].text == "X" && txt[0,0].text == "X" && txt[1,1].text == "X")
                {
                    Debug.Log("叉叉win");
                    OX.text = "叉叉win";
                    b2 = true;
                }


                    for (int i1 = 0; i1 <= 2; i1++)
                    {
                    if (txt0[i1].text != "N" && txt1[i1].text != "N" && txt2[i1].text != "N"&& b2 ==false)
                    {
                        OX.text = "平手   ";
                        b2 = true;
                    }
                    }
                   
            }
            jasonooxx();

        });
    } 
    /// <summary>
    /// 遊戲起始Start設定
    /// </summary>
    void ReS()
    {
        w = Work.N;
        for (int i1 = 0; i1 <= 2; i1++)
        {
            txt0[i1].text = "N";
            txt1[i1].text = "N";
            txt2[i1].text = "N";
            for (int i2 = 0; i2 <= 2; i2++)
            {
                bN[i1, i2] = false;
            }
        }

        b2 = false;
        i = 0;
    }  //遊戲初始start設定
    /// <summary>
    /// jason資料
    /// </summary>
    void jasonooxx()
    {
        PlayerData pd = new PlayerData();
        if (bN[0,0] == false)
        {
            tf[0] = 0;
        }
        else if (bN[0,0] == true)
        {
            tf[0] = 1;
        }

        if (bN[0,1] == false)
        {
            tf[1] = 0;
        }
        else if (bN[0,1] == true)
        {
            tf[1] = 1;
        }

        if (bN[0,2] == false)
        {
            tf[2] = 0;
        }
        else if (bN[0,2] == true)
        {
            tf[2] = 1;
        }

        if (bN[1,0] == false)
        {
            tf[3] = 0;
        }
        else if (bN[1,0] == true)
        {
            tf[3] = 1;
        }

        if (bN[1,1] == false)
        {
            tf[4] = 0;
        }
        else if (bN[1,1] == true)
        {
            tf[4] = 1;
        }

        if (bN[1,2] == false)
        {
            tf[5] = 0;
        }
        else if (bN[1,2] == true)
        {
            tf[5] = 1;
        }

        if (bN[2,0] == false)
        {
            tf[6] = 0;
        }
        else if (bN[2,0] == true)
        {
            tf[6] = 1;
        }

        if (bN[2,1] == false)
        {
            tf[7] = 0;
        }
        else if (bN[2,1] == true)
        {
            tf[7] = 1;
        }

        if (bN[2,2] == false)
        {
            tf[8] = 0;
        }
        else if (bN[2,2] == true)
        {
            tf[8] = 1;
        }
        pd.ooxx = txt0[0].text+","+txt0[1].text+","+txt0[2].text+","+ txt1[0].text +","+ txt1[1].text+","+txt1[2].text+","+txt2[0].text+","+txt2[1].text+","+txt2[2].text;
        pd.oxtf = tf[0].ToString() + tf[1].ToString() + tf[2].ToString()+
                tf[3].ToString() + tf[4].ToString() + tf[5].ToString()+
                tf[6].ToString() + tf[7].ToString() + tf[8].ToString();
        if (w == Work.N)
        {
            pd.ww = 0;
        }
        else if (w == Work.O)
        {
            pd.ww = 1;
        }
        else if (w == Work.X)
        {
            pd.ww = 2;
        }
        pd.turn = i;
        if (b2 == false)
        {
            pd.WL = 0;
        }
        else if (b2 == true)
        {
            pd.WL = 1;
        }
        pd.gg = OX.text;
        string s2cString = JsonUtility.ToJson(pd);       
        PlayerPrefs.SetString("jasonooxx", s2cString);
        Debug.Log("資料-全部 存檔完成");
        Debug.Log("JSON格式資料 : " + PlayerPrefs.GetString("jasonooxx"));

    }
}
public enum Work
{
    N,
    O,
    X,
}
[System.Serializable]
public class PlayerData
{
    public string ooxx;
    public string oxtf;
    public int ww;
    public int turn;
    public int WL;
    public string gg;
}

