using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GOGO : MonoBehaviour {
    public Text txt;
    public Button play;
    public Button exit;
    void Start()
    {
        if (PlayerPrefs.HasKey("分數"))
        {
            txt.text = PlayerPrefs.GetString("分數");
        }

        play.onClick.AddListener(delegate ()
        {
            SceneManager.LoadScene("Google");
        });

        exit.onClick.AddListener(delegate ()
        {
            Application.Quit();
        });
    }
}
