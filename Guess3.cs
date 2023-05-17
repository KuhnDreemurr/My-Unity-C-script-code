using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Guess3 : MonoBehaviour {
    public Text range;
    public Text times;
    public InputField A;
    public Button OK;
    public int guess;
    public int T;
    public bool restart;
    public int i;
    public List<int> small = new List<int>();
    public List<int> big = new List<int>();
    public int M;
    public int N;
    // Use this for initialization
    void Start () {
        OPEN();
        OK.onClick.AddListener(delegate ()
        {
            guess = int.Parse(A.text);
            T = (T + 1); //猜數字的次數
            if (restart == true) //如果遊戲重啟條件true
            {
                OPEN();//執行重新設定的方法Method
            }

            if (restart == false) //遊戲重啟條件為false
             {
                    if (guess == i)
                    {
                        range.text = "恭喜答對";
                        times.text = "已猜" + T + "次";
                        restart = true;
                        A.text = "0";
                    }
                    if (guess > i && guess < big[M])
                    {
                        times.text = "已猜" + T + "次";
                        range.text = small[N] + "~" + guess.ToString();
                        //M = M + 1;
                    }
                    else if (guess < i && guess < big[M])
                    {
                        times.text = "已猜" + T + "次";
                        range.text = guess.ToString() + "~" + big[M];
                        //M = M + 1;
                    }

                    if (guess < i && guess > small[N] && guess != 0)
                    {
                        times.text = "已猜" + T + "次";
                        range.text = guess.ToString() + "~" + big[M];
                        //M = M + 1;
                    }
                    else if (small[N] < i && i < guess)
                    {
                        times.text = "已猜" + T + "次";
                        range.text = small[N] + "~" + guess.ToString();
                        //M = M + 1;
                    }

                    if (i < big[M] && big[M] < guess && guess != 0)
                    {
                        range.text = "你壞壞，給我重來!";
                        A.text = "";
                        restart = true;
                    }
                    else if (guess < small[N] && small[N] < i && guess != 0)
                    {
                        range.text = "你壞壞，給我重來!";
                        A.text = "";
                        restart = true;
                    }
                    else if (guess == 0)
                    {
                        range.text = "1~100";
                    }

                    if (guess > i && guess != 0)
                    {
                        big.Add(guess);
                        M = M + 1;
                    }
                    else if (guess < i && guess != 0)
                    {
                        small.Add(guess);
                        N = N + 1;
                    }

            }
        });
    }

    /// <summary>
    /// 設定題目
    /// </summary>
    void OPEN()
    {
        A.text = "";
        restart = false;//遊戲重啟後把遊戲重啟判定關掉
        range.text = "1~100"; 
        i = Random.Range(1, 101);//設定題目範圍
        T = 0; //猜數字次數歸0
        #region 我把以前寫的舊的程式碼隱藏
        //if (small.Count > 1)
        //{
        //    small.RemoveAt(N);
        //}
        //if (big.Count > 1)
        //{
        //    big.RemoveAt(M);
        //}
        #endregion 
        small.Clear(); //清除List資料
        big.Clear(); //清除List資料
        small.Add(1);
        big.Add(100);
        M = 0;
        N = 0;

        //guess = 1;
        //A.text = "0";
    }
	// Update is called once per frame
	void Update () {
		
	}
}
