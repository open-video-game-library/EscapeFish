using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoNext : MonoBehaviour
{
    public int a = 0;
    public GameObject sliderObj;             /////スライダオブジェクト
    Slider sensitivitySlider;
    public static float sensitivity;
    public GameObject parameterTextObj;     ////スライダUIの下に表示させるパラメーター
    Text parameterText;

    public GameObject sliderObj2;             /////スライダオブジェクト
    Slider sensitivitySlider2;
    public static float sensitivity2;
    public GameObject parameterTextObj2;     ////スライダUIの下に表示させるパラメーター
    Text parameterText2;

    public GameObject sliderObj3;             /////スライダオブジェクト
    Slider sensitivitySlider3;
    public static float sensitivity3;
    public GameObject parameterTextObj3;     ////スライダUIの下に表示させるパラメーター
    Text parameterText3;

    public static float sensivity = 1f;
    public static float power = 1f;
    // Start is called before the first frame update

    float presens;
    float prepower;

    public Player_Move Player_Move;

    void Start()
    {
        sensitivitySlider = sliderObj.GetComponent<Slider>();
        parameterText = parameterTextObj.GetComponent<Text>();

        sensitivitySlider2 = sliderObj2.GetComponent<Slider>();
        parameterText2 = parameterTextObj2.GetComponent<Text>();

        sensitivitySlider3 = sliderObj3.GetComponent<Slider>();
        parameterText3 = parameterTextObj3.GetComponent<Text>();

        Debug.Log("sensitivity" + sensivity);
        sensitivitySlider.value = sensivity;
        sensitivitySlider2.value = power;

    }

    // Update is called once per frame
    void Update()
    {
        sensivity = sensitivitySlider.value;
        power = sensitivitySlider2.value;

        if(sensivity != presens || prepower != power)
        {
            Player_Move.sensUpdate();
        }


        presens = sensivity;
        prepower = power;

        sensitivity = sensitivitySlider.value;
        parameterText.text = sensitivity.ToString("f2");  ///"f2"は、小数点第二位まで表示という意味。自由に変更可。

        sensitivity2 = sensitivitySlider2.value;
        parameterText2.text = sensitivity2.ToString("f2");

        sensitivity3 = sensitivitySlider3.value;
        parameterText3.text = sensitivity3.ToString("f2");

        if (Input.GetKeyDown(KeyCode.Return)){
            SceneManager.LoadScene("MainScene");
        }
    }

    public static float getSensitivity()          ///別スクリプトから呼び出す関数。関数名は任意。型は変数の型にする。
    {
        return sensitivity;     ////調整した変数を戻り値にする。
    }

    public static float getSensitivity2()          ///別スクリプトから呼び出す関数。関数名は任意。型は変数の型にする。
    {
        return sensitivity2;     ////調整した変数を戻り値にする。
    }

    public static float getSensitivity3()          ///別スクリプトから呼び出す関数。関数名は任意。型は変数の型にする。
    {
        return sensitivity3;     ////調整した変数を戻り値にする。
    }

}
