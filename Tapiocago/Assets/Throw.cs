using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class Throw : MonoBehaviour
{
    public GameObject ball;
    private Vector3 throwSpeed = new Vector3(0, 26, 40); 
    public Vector3 ballPos;
    private bool thrown = false;
    private bool power_decided=false;
    private bool state=false;
    private GameObject ballClone;

    public GameObject availableShotsGO;
    private int availableShots = 5;

    public GameObject meter;
    public GameObject arrow;

    public GameObject meter2;
    public GameObject arrow2;
    public GameObject cup;

    private float arrowSpeed = 0.2f; //Difficulty
    private float turnSpeed = 0.2f;
    private bool right = true;
    private bool up = true;
    private bool cright=true;
    public GameObject gameOver;

    // Use this for initialization
    void Start()
    {
        /* Increase Gravity */
        Physics.gravity = new Vector3(0, -20, 0);

    }
    void FixedUpdate()
    {   
        if (cup.transform.position.x < 2f && cright)
        {
            cup.transform.position += new Vector3(0.08f,0, 0);
        }
        if (cup.transform.position.x >= 2f)
        {
            cright = false;
        }
        if (cright == false)
        {
            cup.transform.position -= new Vector3(0.08f,0, 0);
        }
        if ( cup.transform.position.x <= -14f)
        {
            cright = true;
        }

        /* Move Power Meter Arrow */ 
        if(!power_decided){
        if (arrow.transform.position.y < 6.1f && up)
        {
            arrow.transform.position += new Vector3(0,arrowSpeed, 0);
        }
        if (arrow.transform.position.y >= 6.1f)
        {
            up = false;
        }
        if (up == false)
        {
            arrow.transform.position -= new Vector3(0,arrowSpeed, 0);
        }
        if ( arrow.transform.position.y <= -3.3f)
        {
            up = true;
        }
        }
        /* Shoot ball on Tap */

        if(Input.GetButtonUp("Fire1") &&!power_decided && !thrown && availableShots > 0)
        {
            power_decided = true;
        }

        if(power_decided&&!thrown){
            if (arrow2.transform.position.x < 4.7f && right)
            {
                arrow2.transform.position += new Vector3(turnSpeed, 0, 0);
            }
            if (arrow2.transform.position.x >= 4.7f)
            {
                right = false;
            }
            if (right == false)
            {
                arrow2.transform.position -= new Vector3(turnSpeed, 0, 0);
            }
            if ( arrow2.transform.position.x <= -4.7f)
            {
                right = true;
            }
        }
        if(Input.GetButtonDown("Fire1") &&power_decided && !thrown && availableShots > 0)
        {
            thrown = true;
            availableShots--;
            availableShotsGO.GetComponent<GUIText>().text = availableShots.ToString();

            ballClone = Instantiate(ball, ballPos, transform.rotation) as GameObject;
            throwSpeed.y = throwSpeed.y + arrow.transform.position.y; //縦方向スピード
            throwSpeed.z = throwSpeed.z + arrow.transform.position.y;　//  前進方向スピード
            throwSpeed.x = throwSpeed.x + arrow2.transform.position.x;
            ballClone.GetComponent<Rigidbody>().AddForce(throwSpeed, ForceMode.Impulse);
            GetComponent<AudioSource>().Play();
        }
        
        

        /* Remove Ball when it hits the floor */

        if (ballClone != null && ballClone.transform.position.y <1)
        {
            Destroy(ballClone);
            thrown = false;
            power_decided = false;
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
        //  Application.LoadLevel(Application.loadedLevel);
        SceneManager.LoadScene(sceneName:"result");
    }
}