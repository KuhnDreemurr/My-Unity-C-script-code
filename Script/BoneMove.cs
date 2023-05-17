using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneMove : MonoBehaviour {
    public float movSpeed;
	// Use this for initialization
	void Start () {
        movSpeed = 2;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position -= new Vector3(movSpeed * Time.deltaTime, 0, 0);
        Destroy(gameObject,13);
    }

}
