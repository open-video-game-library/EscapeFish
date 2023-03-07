using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningAnimation: MonoBehaviour
{
    [SerializeField] float DefalutPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(transform.position.x < DefalutPosition)
        {
            transform.position += new Vector3(0.1f, 0, 0);
        }

        if(transform.position.x > DefalutPosition)
        {
            transform.position = new Vector3(DefalutPosition, transform.position.y, transform.position.z);
            Destroy(this);
        }
    }
}
