using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSpeedObject : MonoBehaviour
{
    UIController uicontroller;

    // Start is called before the first frame update
    void Start()
    {
        uicontroller = GameObject.Find("Stage").GetComponent<UIController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(uicontroller.tide * 0.01f * 1f, 0, 0);
    }
}
