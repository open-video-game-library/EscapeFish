using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMaker : MonoBehaviour
{
    public GameObject maguro;
    public GameObject syake;
    public GameObject tori;
    public GameObject hari;
    public GameObject ami;
    public GameObject isogin_short;
    public GameObject isogin_middle;
    public GameObject isogin_long;
    public GameObject sakana;
    public UIController uicontroller;

    public Transform Stage;
    public int rate = 100;
    //amiÇ∆isoginÇ™ìØéûÇ…ë∂ç›ÇµÇ»Ç¢ÇÊÇ§Ç…
    int t;
    int tt;
    float preScore;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        t = 0;
        tt = 0;
        Stage = GameObject.Find("Stage").transform;
    }

    float masTime = 0f;

    // Update is called once per frame
    float prescore = 0f;
    void Update()
    {
        int a = Random.Range(1, 6);
        float height = Random.Range(-3.5f, 3.5f);
        int b = 0;
        int c = Random.Range(1, 3);
        int enemyRate = rate - Mathf.FloorToInt(uicontroller.score / 50);
        if (enemyRate <= 20)
        {
            Debug.Log("EnemyRateMax");
            enemyRate = 20;
        }

        //Debug.Log("enemyRate: " + enemyRate);

        masTime += (uicontroller.score - prescore);

        prescore = uicontroller.score;
        

        if (masTime > enemyRate)
        {
            masTime -= enemyRate;
            if (a == 1)
            {
                GameObject made = Instantiate(syake, new Vector3(12, height, 0), Quaternion.identity, Stage);
            }
            else if (a == 2)
            {
                GameObject made = Instantiate(syake, new Vector3(12, height, 0), Quaternion.identity, Stage);

            }
            else if (a == 3)
            {
                if (t > 50f)
                {
                    GameObject made = Instantiate(tori, new Vector3(12, 4.4f, 0), Quaternion.identity, Stage);
                }
            }
            else if (a == 4)
            {
                GameObject made = Instantiate(hari, new Vector3(12, 0.11f, 0), Quaternion.identity, Stage);
                height = Random.Range(0f, 3.5f);
                hari.transform.Find("genten").gameObject.transform.position = new Vector3(hari.transform.position.x, height, 0) ;
            
            }
            else if (a == 5)
            {

                if (c == 1)
                {
                    GameObject made = Instantiate(maguro, new Vector3(12, height, 0), Quaternion.identity, Stage);
                }
                else if (c == 2)
                {


                    b = Random.Range(1, 4);
                    if (b == 1)
                    {
                        GameObject made = Instantiate(ami, new Vector3(12, 0.11f, 0), Quaternion.identity, Stage);

                    }
                    else if (b == 2)
                    {

                        GameObject made = Instantiate(isogin_middle, new Vector3(12, 0, 0), Quaternion.identity, Stage);

                    }
                    else if (b == 3)
                    {
                        GameObject made = Instantiate(isogin_short, new Vector3(12, 0, 0), Quaternion.identity, Stage);
                    }
                }
            }
            

        }

        preScore = uicontroller.score;
        

    }

}
