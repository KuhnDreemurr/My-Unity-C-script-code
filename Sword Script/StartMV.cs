using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class StartMV : MonoBehaviour
{
   
    public VideoPlayer MV;
    // Start is called before the first frame update
    void Start()
    {
        MV.loopPointReached += check;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void check(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene("Time");
    }
}
