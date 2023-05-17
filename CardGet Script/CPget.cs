using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CPget : MonoBehaviour {
    public int GC;//機率變數
    public Button Go;//抽卡按鈕
    public List<int> cn = new List<int>(); //機率結果儲存
    public List<string> GR = new List<string>(); //得到的R卡紀錄
    public List<string> GSR = new List<string>();
    public List<string> GSSR = new List<string>();
    public List<string> GN = new List<string>();
    //public GameObject Book; //按鈕激活
    public GameObject[] DrawPre;//確保本體不滅，抽卡影片克隆
    public GameObject[] R_elf;
    public GameObject[] SR_elf;
    public GameObject[] SSR_elf;
    public GameObject[] N_elf;
    public int VVID; //要調用的本體陣列第幾位
    public GameObject Draw; //抽卡影片本體
    public GameObject VC; //防止影片在背景撥放
    public int CG;//計算單一抽卡list次數(調用抽到第幾張)
    public int allCG;//計算抽卡累積次數(將來可作保底)
    public GameObject Cardshow;
    public GameObject FirstV;
    public Button Search;//查詢紀錄按鈕
    public string ListData; //儲存抽卡紀錄
    // Use this for initialization
    void Start() {
        CG = 0;
        if (PlayerPrefs.HasKey("抽卡次數"))
        {
            allCG = PlayerPrefs.GetInt("抽卡次數");
        }
        else allCG = 0;

        if (PlayerPrefs.HasKey("抽卡紀錄"))
        {
            ListData = PlayerPrefs.GetString("抽卡紀錄");
        }
        else ListData = "";
        StartCoroutine(CoNov());
        
        Go.onClick.AddListener(delegate ()
        {
            for (int t = 1; t <=6; t++) {
                GC = 100 - (Random.Range(0, 100));
                Debug.Log(GC);
                cn.Add(GC);
                ListData += GC.ToString()+",";
                PlayerPrefs.SetString("抽卡紀錄",ListData);
                PlayerPrefs.Save();
                Debug.Log("資料-全部 存檔完成");

            }
            
            VC.gameObject.active = true;
            Draw = Instantiate(DrawPre[VVID], new Vector3(960, 540, 0), Quaternion.Euler(new Vector3(0, 0, 0)), FirstV.transform);
            //Draw.transform.position = new Vector3(960, 540, 0);
            StartCoroutine(CoVideo());
            //DestroyImmediate(Draw, true);
        });
        
        Search.onClick.AddListener(delegate ()
        {
            Debug.Log("Enter");
            if (PlayerPrefs.HasKey("抽卡次數"))
            {
                Debug.Log("Yes");
                Debug.Log(PlayerPrefs.GetInt("抽卡次數"));               
            }
            if (PlayerPrefs.HasKey("抽卡紀錄"))
            {
                Debug.Log("Yoo");
                Debug.Log(PlayerPrefs.GetString("抽卡紀錄"));

                //卡冊會用到，讀取拆解抽卡紀錄資料，讀取數字並重新克隆該數字的卡片
                string[] A = PlayerPrefs.GetString("抽卡紀錄").Split(char.Parse(","));
                for (int i = 0; i < A.Length; i++)
                {
                    Debug.Log(A[i]);
                }
            }
        });
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.E))
        {
            PlayerPrefs.DeleteKey("抽卡次數");
            Debug.Log("資料-抽卡次數 刪除完成");
            allCG = 0;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            PlayerPrefs.DeleteKey("抽卡紀錄");
            Debug.Log("資料-抽卡紀錄 刪除完成");
            ListData = "";
        }
    }
    IEnumerator CoNov()
    {
        yield return new WaitForSeconds(6);
        Go.gameObject.active = true;
        Search.gameObject.active = true;
    }
    IEnumerator CoVideo()
    {
        Go.gameObject.active = false;
        Search.gameObject.active = false;
        //Book.active = false;
        yield return new WaitForSeconds(3.3f);
        Debug.Log("第一張");
        CardBool();
        yield return new WaitForSeconds(2.2f);
        Debug.Log("第一張消失");
        Destroy(Cardshow);
        yield return new WaitForSeconds(3.3f);
        Debug.Log("第二張");
        CardBool();
        yield return new WaitForSeconds(2.2f);
        Debug.Log("第二張消失");
        Destroy(Cardshow);
        yield return new WaitForSeconds(3.3f);
        Debug.Log("第三張");
        CardBool();
        yield return new WaitForSeconds(2.2f);
        Debug.Log("第三張消失");
        Destroy(Cardshow);
        yield return new WaitForSeconds(3.3f);
        Debug.Log("第四張");
        CardBool();
        yield return new WaitForSeconds(2.2f);
        Debug.Log("第四張消失");
        Destroy(Cardshow);
        yield return new WaitForSeconds(3.3f);
        Debug.Log("第五張");
        CardBool();
        yield return new WaitForSeconds(2.2f);
        Debug.Log("第五張消失");
        Destroy(Cardshow);
        yield return new WaitForSeconds(3.3f);
        Debug.Log("第六張");
        CardBool();
        yield return new WaitForSeconds(2f);
        Debug.Log("第六張消失");
        Destroy(Cardshow);
        //Book.active = true;
        CG = 0;
        Go.gameObject.active = true;
        Search.gameObject.active = true;
        yield return new WaitForSeconds(0.2f);
        Destroy(Draw);
        VC.gameObject.active = false;
        Debug.Log("DD");
    }

    /// <summary>
    /// 抽卡稀有度判定
    /// </summary>
    public void CardBool()
    {
        Debug.Log(CG);
        if (cn[CG] >= 1 && cn[CG] <= 5)
        {
            Cardshow = Instantiate(SSR_elf[Random.Range(0, 2)], new Vector3(960, 540, 0), Quaternion.Euler(new Vector3(0, 0, 0)), Draw.transform);
        }
        else if (cn[CG] >= 6 && cn[CG] <= 20)
        {
            Cardshow = Instantiate(SR_elf[Random.Range(0, 3)], new Vector3(960, 540, 0), Quaternion.Euler(new Vector3(0, 0, 0)), Draw.transform);
        }
        else if (cn[CG] >= 21 && cn[CG] <= 50)
        {
            Cardshow = Instantiate(R_elf[Random.Range(0, 3)], new Vector3(960, 540, 0), Quaternion.Euler(new Vector3(0, 0, 0)), Draw.transform);
        }
        else if (cn[CG] >= 51 && cn[CG] <= 100)
        {
            Cardshow = Instantiate(N_elf[Random.Range(0, 7)], new Vector3(960, 540, 0), Quaternion.Euler(new Vector3(0, 0, 0)), Draw.transform);
        }
        CG++;
        allCG++;
        PlayerPrefs.SetInt("抽卡次數", allCG);
        Debug.Log(PlayerPrefs.GetInt("抽卡次數"));
        //Debug.Log(allCG);
    }
}
