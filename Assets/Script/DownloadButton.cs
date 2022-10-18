using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DownloadButton : MonoBehaviour
{
    DataManager dataManager;
    public GameObject button;
    public GameObject button2;
    public GameObject button3;
    void Start()
    {

        dataManager = GameObject.Find("DataManager").GetComponent<DataManager>();
        button.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);
    }

    public void wakeUp()
    {
        button.SetActive(true);
        button2.SetActive(true);
        button3.SetActive(true);
    }

    // ƒ{ƒ^ƒ“‚ð‰Ÿ‚µ‚½‚ç
    public void OnClickButton()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OnClickButton2()
    {
        dataManager.getData();
    }
    public void OnClickButton3()
    {
        SceneManager.LoadScene("Opening");
    }
}
