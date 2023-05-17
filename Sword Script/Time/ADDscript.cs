using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ADDscript : MonoBehaviour
{

    /// <summary>
    /// 加注按鈕
    /// </summary>
    public Button[] butAdds;
    /// <summary>
    /// 加注按鈕父物件
    /// </summary>
    public GameObject ADDDAD;
    public Count Cad;
    // Start is called before the first frame update
    void Start()
    {
        //Cad = new Count(); //已經有mono實例化就不要亂new!!包裹送錯地址啦!!
        CAbtn();
    }

    /// <summary>
    /// 建立加注按鈕方法
    /// </summary>
    public void CAbtn()
    {
        butAdds = new Button[ADDDAD.transform.childCount];
        for (int i = 0; i < ADDDAD.transform.childCount; i++)
        {
            butAdds[i] = transform.Find("ADD" + i).GetComponentInChildren<Button>();
        }

        for (int i = 0; i < butAdds.Length; i++)
        {
            int index;
            index = i;
            butAdds[i].onClick.AddListener(delegate ()
            {
                //Debug.Log(index + "按下按鈕");
                if (Cad.Money > 0)
                {
                    Cad.PM[index] += 1;
                    Cad.Money -= 1;
                }
                //Debug.Log("CAD.PM:" + Cad.PM[index]);
                Debug.Log(Cad.Money);
            });
        }
    }
}
