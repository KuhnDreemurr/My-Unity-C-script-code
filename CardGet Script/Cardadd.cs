using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Cardadd : MonoBehaviour {
    public Sprite S1;
    public Sprite S2;
    public Sprite S3;
    public Button Cb1;
    public Button Cb2;
    public Button Cb3;
    public GameObject CPre1;
    public GameObject Cpre2;
    public GameObject Cpre3;
    public Button CD1;
    public Button CD2;
    public Button CD3;
    public List<int> CN = new List<int>();
    public int a;
    public int save;
    public int N1;
    public int N2;
    public int N3;
    public Canvas CP;

	// Use this for initialization
	void Start () {

        int A = 200;
        save = PlayerPrefs.GetInt("牌組存檔");
        N1 = 0;
        N2 = 0;
        N3 = 0;
        Cb1.onClick.AddListener(delegate () {

            if (N1 <= 2) {
                CN.Add(1);
                
                Instantiate(CPre1, new Vector3(A, 830, 0), Quaternion.Euler(new Vector3(0, 0, 0)), CP.transform);
                CPre1.transform.localPosition = new Vector3(0, 0, 0);
      
                Debug.Log(CN.Count);
                a = CN.Count;
                for (int i = 1; i < a; i++)
                {
                    Debug.Log(Cb1);
                }
                A += 300;
                N1++;
            }
        });
        Cb2.onClick.AddListener(delegate () {
            if (N2 <= 2) {
                CN.Add(2);
                //Debug.Log(CN.Count);
                a = CN.Count;
                for (int i = 1; i < a; i++)
                {
                    Debug.Log(Cb2);
                }
                N2++;
            }

        });
        Cb3.onClick.AddListener(delegate ()
        {
            if (N3 <= 2)
            {
                CN.Add(3);
                Debug.Log(CN.Count);
                a = CN.Count;
                for (int i = 1; i < a; i++)
                {
                    Debug.Log(Cb3);
                }
                N3++;
            }

        });
        CD1.onClick.AddListener(delegate ()
        {
            Debug.Log("XDDD");//沒有進來這一步
            Destroy(CPre1);
        });


    }
	
	// Update is called once per frame
	void Update () {
     
    }
}
