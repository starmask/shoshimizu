using UnityEngine;
using System.Collections;

public class Basket : MonoBehaviour
{
    public GameObject score;
    public AudioClip tapiSound;

    void OnCollisionEnter()
    {
        GetComponent<AudioSource>().Play();
    }

    void OnTriggerEnter()
    {
        int currentScore = int.Parse(score.GetComponent<GUIText>().text) + 1;
        score.GetComponent<GUIText>().text = currentScore.ToString();
        //AudioSource.PlayClipAtPoint(basket, transform.position);
    }
}