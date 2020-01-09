using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGyro : MonoBehaviour
{

    private float speed = 30.0f;
    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
         rb = GetComponent<Rigidbody>();
         Input.gyro.enabled = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //加速度センサによるボールの制御
        float moveH = Input.acceleration.x;
        float moveV = Input.acceleration.y;
                     
        var movement = new Vector3 (moveH, 0.0f, moveV);
                     
        rb.AddForce(movement * speed * 0.8f);
        
       
        }

    }