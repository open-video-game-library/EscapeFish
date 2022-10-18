using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class DataManager : MonoBehaviour
{
    // もしWebGL版の場合は、JavaScript側で動く関数を取得する
    // addData → 1試行ごとにjsにデータを送信する関数
    // downloadData → 任意の試行が終わったのち、csvデータをダウンロードする関数
#if UNITY_WEBGL && !UNITY_EDITOR
     [DllImport("__Internal")]
     private static extern void addData(string jsonData);
 
     [DllImport("__Internal")]
     private static extern void downloadData();
#endif

    // 取得するデータのクラスを定義
    // Escape-Fishの場合は「スコアscore」「獲得魚数」「ダメージ数」
    [System.Serializable]
    public class Data
    {
        public int score;
        public int hit_num;
        public float hit_rate;
    }

    // 試行が終わったときに呼び出す関数
    // Hunter-Chameleonでは、ゲーム終了のときに「スコア」「ヒット数」「トリガーを引いた数」を引数としてこの関数を呼び出しています
    // ゲームに応じて分かりやすい変数名にしてください
    public void postData(int _score, int _get_Fish, int _pressButtonMany)
    {
        Data data = new Data(); // クラスを生成
        data.score = _score; // スコア
        data.hit_num = _get_Fish; // ヒット数
        data.hit_rate = _pressButtonMany; // ヒット率
        string json = JsonUtility.ToJson(data); // json形式に変換してjsに渡す
#if UNITY_WEBGL && !UNITY_EDITOR
         addData(json);
#endif
    }

    // ダウンロードボタンを押したときに呼び出す関数
    public void getData()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
         downloadData();
#endif
    }
}