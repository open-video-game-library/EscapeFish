using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildMove : MonoBehaviour
{
    Player_Move player_move;
    // Start is called before the first frame update
    void Start()
    {
        player_move = GameObject.Find("Player").GetComponent<Player_Move>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        
        if (this.gameObject.tag == "Player")
        {
            player_move.Child_Hit(col);
        }

    }
}
