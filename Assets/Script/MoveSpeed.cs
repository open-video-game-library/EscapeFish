using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpeed : MonoBehaviour
{
    public float speed;
    public Player_Move Player_Move;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //speed = Player_Move.tide * 0.01f;
        transform.position += new Vector3(speed, 0, 0);

    }
}
