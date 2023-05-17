using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCM : MonoBehaviour {
    public float MS;
    // Use this for initialization
    void Start () {
        MS = 2.5f;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position -= new Vector3(MS * Time.deltaTime, 0, 0);
        Destroy(gameObject, 30);
    }
}
