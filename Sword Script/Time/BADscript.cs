using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BADscript : MonoBehaviour
{
    /// <summary>
    /// 減少下注按鈕
    /// </summary>
    public Button[] butBad;
    /// <summary>
    /// 減少下注按鈕父物件
    /// </summary>
    public GameObject BaDDD;
    public Count Cbad;
    // Start is called before the first frame update
    void Start()
    {
        Badbtns();

    }
    /// <summary>
    /// 建立減少下注按鈕方法
    /// </summary>
    public void Badbtns()
    {
        butBad = new Button[BaDDD.transform.childCount];
        for (int i = 0; i < BaDDD.transform.childCount; i++)
        {
            butBad[i] = transform.Find("BA" + i).GetComponentInChildren<Button>();
        }

        for (int i = 0; i < butBad.Length; i++)
        {
            int index;
            index = i;
            butBad[i].onClick.AddListener(delegate ()
            {
                if (Cbad.PM[index] > 0)
                {
                    Cbad.PM[index] -= 1;
                    Cbad.Money += 1;
                }
            });
        }
    }
}
