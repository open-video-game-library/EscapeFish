using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour
{
    public float size;
    public Player_Move Player_Move;
    public float bairitsu;
    UIController uicontroller;
    GameObject a;
    float speed;
    private void Start()
    {
        //a = GameObject.Find("MainCamera");
        size = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
        uicontroller = GameObject.Find("Stage").GetComponent<UIController>();
    }
    void Update()
    {

        transform.position += new Vector3(uicontroller.tide*0.01f * bairitsu, 0, 0);
        
        if (transform.position.x < -size)
        {
            transform.position += new Vector3(size*2, 0, 0);
        }
    }
}