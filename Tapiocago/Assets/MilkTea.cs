using UnityEngine;
using System.Collections;

public class MilkTea : MonoBehaviour
{
    public GameObject score;
    public GameObject num;
    public AudioClip tapiSound;
    //milktea event
    void OnCollisionEnter()
    {
        GetComponent<AudioSource>().Play();
    }
    //入れた後の判定
    void OnTriggerEnter()
    {
        float currentScore = float.Parse(score.GetComponent<GUIText>().text) + 18.4f;
        int numball = int.Parse(num.GetComponent<GUIText>().text) + 1;
        //変数を次のシーンに渡すために保存する
        PlayerPrefs.SetFloat("score", currentScore); 
        PlayerPrefs.SetInt("num",numball);           
        score.GetComponent<GUIText>().text = currentScore.ToString();
    }
}