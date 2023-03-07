using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dive : MonoBehaviour
{
    float preX;
    float preY;
    float X;
    float Y;
    Transform Player;
    bool go;
    Stage Stage;
    float EnemySpeed;
    float t;
    float thisX;
    float thisY;
    float sinpuku;
    float akusin;
    float prethisX;
    Vector3 a;
    float height;
    float width;
    // Start is called before the first frame update
    void Start()
    {
        height = Camera.main.orthographicSize;
        width = height * Screen.width / Screen.height;
        Player = GameObject.Find("Player").transform;
        Stage = this.GetComponent<Stage>();
        EnemySpeed = -Stage.EnemySpeed;
        t = 0;
        Stage.EnemySpeed = -3f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(go == true)
        {
            var z = this.GetComponent<Rigidbody2D>().velocity.normalized;

            this.transform.eulerAngles = new Vector3(0f, 0f, 270f - 180f /Mathf.PI * Mathf.Atan2(z.x, z.y));
        }

        /*
        float XX = this.transform.position.x - Player.position.x;
        //float X = this.transform.position.y - pre;
        float YY = this.transform.position.y - Player.position.y;

        if (YY - XX < -6)
        {
            go = false;
        }
        else if (YY - XX > 0 && go == false && akusin * t < Mathf.PI)
        {
            a = new Vector3(-EnemySpeed, 0, 0);
            //this.GetComponent<Rigidbody2D>().velocity;
            this.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            go = true;
            X = Player.transform.position.x;
            Y = Player.transform.position.y;
            thisX = this.transform.position.x;
            thisY = this.transform.position.y;
            EnemySpeed = Mathf.Abs(this.transform.position.x - prethisX) / 2;
            sinpuku = Mathf.Abs(Player.transform.position.y - this.transform.position.y);
            if (sinpuku == 0) go = false;
            akusin = Mathf.Abs(Mathf.Asin(Mathf.Abs(EnemySpeed / sinpuku)));

        }
        */
        float a = (this.transform.position.x - Player.transform.position.x) / Mathf.Abs(this.GetComponent<Rigidbody2D>().velocity.x * Time.deltaTime);

        if(Mathf.Abs(this.transform.position.y - Player.transform.position.y) - (9.8f * a * a  / 32f /4f)* Time.deltaTime > 0f)
            {
                
                go = true;

            this.GetComponent<Rigidbody2D>().gravityScale = 9.8f / 16f;
        }

        if (catchedup == true && this.transform.position.y >= 4.2f)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<Rigidbody2D>().velocity.x, 0);
            this.GetComponent<Rigidbody2D>().gravityScale = 0f;
        }

        
    }

    void LateUpdate()
    {
        if (catchedup == true)
        {
            if (transform.childCount >= 1)
            {

                transform.GetChild(4).transform.position = this.transform.position;
                transform.GetChild(4).transform.position -= new Vector3(0, 0.5f, 0);
            }
        }
    }

        bool catchedup;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player") //ÉvÉåÉCÉÑÅ[Ç…ìñÇΩÇ¡ÇΩÇÁ
        {
            Debug.Log("chatched");
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<Rigidbody2D>().velocity.x, -this.GetComponent<Rigidbody2D>().velocity.y);
            collision.GetComponent<Collider2D>().enabled = false;
            collision.GetComponent<Rigidbody2D>().isKinematic = true;
            collision.transform.parent = this.transform;
            catchedup = true;
        }
    }
}
