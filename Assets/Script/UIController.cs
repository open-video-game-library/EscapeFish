using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public Text text;
    public float score;
    public int scoreRate;
    public Text GameOver;
    public Text text_2;
    bool gameover;
    public float tide;
    Player_Move Player_Move;
    int sakanaMany;
    float time;
    DownloadButton DownloadButton;

    DataManager dataManager;
    public Text GameOverText;

    public GameObject Canvas;

    private bool wentHome = false;

    // Start is called before the first frame update
    void Start()
    {

        Player_Move = GameObject.Find("Player").GetComponent<Player_Move>();
        DownloadButton = GameObject.Find("DataManager").GetComponent<DownloadButton>();
        score = 0;
        scoreRate = 1;
        sakanaMany = 1;
        tide = -10;
        dataManager = GameObject.Find("DataManager").GetComponent<DataManager>();
        if (Canvas != null)
        {
            Canvas.SetActive(false);
        }
        
    }

    float tidedefuser = 0.1f;

    // Update is called once per frame
    void Update()
    {

        tide = -3 - score / 700;
        if (tide <= -8)
        {
            Debug.Log("tideMax");
            tide = -8;
        }
        //time += Time.deltaTime;
        //sakanaMany = Player_Move.sakanaMany;
        if(Player_Move.life != 0)
        {
            score += Time.deltaTime * 100;
        }
        else
        {
            
            tide += tidedefuser;
            tidedefuser += 0.08f;


            if(tide >= 0)
            {
                tide = 0f;
            }
            if (Canvas != null)
            {

                Canvas.SetActive(true);
            }
            float n = Mathf.Floor(score) / 100f;
            GameOverText.text = n.ToString() + "m";
            
        }
        // Debug.Log(tide);
        float sco = score / 100;
        float sco2 = (score - Mathf.FloorToInt(score / 100)*100) / 1;
        text.text = Mathf.FloorToInt(sco).ToString();
        text_2.text = Mathf.FloorToInt(sco2).ToString();
        string a = (sakanaMany - 1).ToString() + "/5";
        //sakana.text = a;
        if(gameover == true){
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //SceneManager.LoadScene("MainScene");
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ///SceneManager.LoadScene("Opening");
            }

        }
    }

    public void Gohome()
    {
        GameOver.text = "GameOver";

        DownloadButton.wakeUp();
        if (!gameover)
        {
            dataManager.postData(Mathf.FloorToInt(score), Player_Move.Get_Fish, Player_Move.PressButtonMany);
        }
        gameover = true;
    }

    public void Clear()
    {
        SceneManager.LoadScene("Goal");
        
    }
}
