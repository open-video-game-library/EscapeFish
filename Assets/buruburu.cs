using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buruburu : MonoBehaviour
{
    Vector2 defa;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = this.transform.parent.position + new Vector3(0.23f, -4.4f, 0f) + new Vector3(Random.Range(-0.02f, 0.02f), Random.Range(-0.02f, 0.05f), 0f);
    }
}
