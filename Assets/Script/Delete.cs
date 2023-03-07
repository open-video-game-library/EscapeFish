using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete : MonoBehaviour
{
    [SerializeField] Transform childMaker;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag != "Player" || other.gameObject.tag != "ami"
            )
        {
            /*
            other.transform.parent = childMaker.transform;
            other.gameObject.SetActive(false);
            */
            Destroy(other.gameObject);
        }
    }

}
