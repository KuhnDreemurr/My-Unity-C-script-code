using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SM : MonoBehaviour {
    public GameObject s1;
    public GameObject s2;
    public GameObject s3;
    public GameObject s4;
    public GameObject SC;
    public int Ran;
    public float AD;


    // Use this for initialization
    void Start () {
        AD = 12;
        SC.transform.localPosition = new Vector3(50, 3, 6);
    }
	
	// Update is called once per frame
	void Update () {
        Ran = Random.Range(1, 5);
        if (AD <= 12)
        {
            AD += Time.deltaTime;
        }

        if (AD>=12 && Google.live==true)
        {
            if (Ran == 1)
            {
                Instantiate(s1, new Vector3(40, 3, 6), Quaternion.Euler(new Vector3(0, 0, 0)), SC.transform);
                
            }
            else if (Ran == 2)
            {
                Instantiate(s2, new Vector3(40, 3, 6), Quaternion.Euler(new Vector3(0, 0, 0)), SC.transform);
            }
            else if (Ran == 3)
            {
                Instantiate(s3, new Vector3(40, 3, 6), Quaternion.Euler(new Vector3(0, 0, 0)), SC.transform);
            }
            else if(Ran==4)
            {
                Instantiate(s4, new Vector3(40, 3, 6), Quaternion.Euler(new Vector3(0, 0, 0)), SC.transform);
            }
            SC.transform.localPosition = new Vector3(50, 3, 6);
            AD =0;
        }
    }
}
