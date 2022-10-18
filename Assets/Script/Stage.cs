using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    float width; //スクリーン横
    float size;
    public float EnemySpeed; //敵キャラクターのソクド

    Rigidbody2D rb2d;
    bool move;
    Player_Move player_move;
    UIController uicontroller;
    // Start is called before the first frame update
    void Start()
    {
        width = Camera.main.orthographicSize * Screen.width / Screen.height;
        //size = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
        rb2d = GetComponent<Rigidbody2D>();
        player_move = GameObject.Find("Player").GetComponent<Player_Move>();
        uicontroller = GameObject.Find("Stage").GetComponent<UIController>();

        float tide = -1f * uicontroller.tide/ 3f;

        this.transform.parent = null;
        move = true;

        rb2d.velocity = new Vector3(EnemySpeed * tide, 0, 0);
    }
    // Update is called once per frame
    void Update()
    {
        /*
        if(this.transform.position.x <= width + size/2 && move == false)
        {
            float tide = -1/3 * player_move.tide;

            this.transform.parent = null;
            move = true;
            
            rb2d.velocity = new Vector3(EnemySpeed * tide, 0, 0);
            Debug.Log(tide);
        }
        */
    }

    
}
