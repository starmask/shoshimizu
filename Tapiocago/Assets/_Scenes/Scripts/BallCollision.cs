using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class BallCollision : MonoBehaviour
{
   void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "ball")
        {
            Debug.Log("Collision");
            SceneManager.LoadScene("TapiBattle");
        }
    }
}
