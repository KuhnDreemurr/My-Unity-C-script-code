using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class UIswitch : MonoBehaviour
{
    /// <summary>
    /// �}�l�C�����s
    /// </summary>
    public Button Sbtn;
    /// <summary>
    /// ���}���s
    /// </summary>
    public Button Qbtn;
    public VideoPlayer MV;
    // Start is called before the first frame update
    void Start()
    {
        MV.loopPointReached += check;
        Sbtn.onClick.AddListener(delegate () {
            SceneManager.LoadScene("StartMV");
        });

        Qbtn.onClick.AddListener(delegate () {
            Application.Quit();
        });
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            PlayerPrefs.DeleteAll();
            Debug.Log("���-���� �R������");
        }
    }

    void check(UnityEngine.Video.VideoPlayer vp)
    {
        Sbtn.gameObject.SetActive(true);
        Qbtn.gameObject.SetActive(true);
    }
}
