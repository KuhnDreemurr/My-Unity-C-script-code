using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Google :MonoBehaviour {
    public Rigidbody rb;
    public Vector3 V3;
    public float power;
    public static bool live; 
    public GameObject DieVideo;
    //public RawImage RV;
    // public GameObject GGV;

    // Use this for initialization
    void Start () {
        DieVideo.active = false;
        live = true;
        V3 =new Vector3(0, 1, 0);
        power = 5;

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            VelocityEvent();
        }

	}

    void OnCollisionEnter(Collision hit)
    {
        if (hit.collider.tag == "Die")
        {
            live = false;
            //Instantiate(GGV, new Vector3(0, 0, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
            DieVideo.active = true;
            Debug.Log("播放影片");
            //Instantiate(DieVideo, new Vector3(0, 2, -3), Quaternion.Euler(new Vector3(0, 0, 0)));
            //Destroy(gameObject);

        }
        Debug.Log(live);
    }

    void VelocityEvent()//不受Mess質量影響
    {
        rb.velocity = V3 * power;
    }



}
