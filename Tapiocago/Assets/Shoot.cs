using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{
    public GameObject ball;
    private Vector3 throwSpeed = new Vector3(0, 26, 40); 
    public Vector3 ballPos;
    private bool thrown = false;
    private GameObject ballClone;

    public GameObject availableShotsGO;
    private int availableShots = 5;

    public GameObject meter;
    public GameObject arrow;
    private float arrowSpeed = 0.3f; //Difficulty
    private bool right = true;
    private bool power_decided = false;
    public GameObject gameOver;

    // Use this for initialization
    void Start()
    {
        /* Increase Gravity */
        Physics.gravity = new Vector3(0, -20, 0);
    }

    void FixedUpdate()
    {
        /* Move Meter Arrow */
        
        if (arrow.transform.position.x < 4.7f && right)
        {
            arrow.transform.position += new Vector3(arrowSpeed, 0, 0);
        }
        if (arrow.transform.position.x >= 4.7f)
        {
            right = false;
        }
        if (right == false)
        {
            arrow.transform.position -= new Vector3(arrowSpeed, 0, 0);
        }
        if ( arrow.transform.position.x <= -4.7f)
        {
            right = true;
        }

        /* Shoot ball on Tap */

        if (Input.GetButton("Fire1") && !thrown && availableShots > 0)
        {
            thrown = true;
            availableShots--;
            availableShotsGO.GetComponent<GUIText>().text = availableShots.ToString();

            ballClone = Instantiate(ball, ballPos, transform.rotation) as GameObject;
            throwSpeed.y = throwSpeed.y + arrow.transform.position.x; //縦方向スピード
            throwSpeed.z = throwSpeed.z + arrow.transform.position.x;　//  前進方向スピード

            ballClone.GetComponent<Rigidbody>().AddForce(throwSpeed, ForceMode.Impulse);
            GetComponent<AudioSource>().Play();
        }

        /* Remove Ball when it hits the floor */

        if (ballClone != null && ballClone.transform.position.y <1)
        {
            Destroy(ballClone);
            thrown = false;
            throwSpeed = new Vector3(0, 26, 40);//Reset perfect shot variable

            /* Check if out of shots */
            
            if (availableShots == 0)
            {
                arrow.GetComponent<Renderer>().enabled = false;
                Instantiate(gameOver, new Vector3(0.31f, 0.2f, 0), transform.rotation);
                Invoke("restart", 2);
            }
        }
    }
    

    void restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}