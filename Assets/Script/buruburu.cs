using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buruburu : MonoBehaviour
{
    Vector2 defa;
    // Start is called before the first frame update
    void Start()
    {
        defa = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = defa + new Vector2(Random.Range(-0.05f, 0.05f), Random.Range(-0.05f, 0.05f));
    }
}
