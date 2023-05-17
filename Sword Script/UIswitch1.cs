using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIswitch1 : MonoBehaviour
{
    /// <summary>
    /// �}�l�C�����s
    /// </summary>
    public Button Sbtn;
    /// <summary>
    /// ���}���s
    /// </summary>
    public Button Qbtn;
    public Button menu;
    // Start is called before the first frame update
    void Start()
    {
        Sbtn.onClick.AddListener(delegate () {
            SceneManager.LoadScene("StartMV");
        });

        Qbtn.onClick.AddListener(delegate () {
            Application.Quit();
        });

        menu.onClick.AddListener(delegate() {
            SceneManager.LoadScene("Menu");
        });
    }

    // Update is called once per frame
    void Update()
    {

    }

    void check(UnityEngine.Video.VideoPlayer vp)
    {
        Sbtn.gameObject.SetActive(true);
        Qbtn.gameObject.SetActive(true);
    }
}
