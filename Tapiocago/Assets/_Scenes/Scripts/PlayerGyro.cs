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

        //float moveH = Input.gyro.userAcceleration.x;
        //float moveV = Input.gyro.userAcceleration.y;
        float moveH = Input.acceleration.x;
        float moveV = Input.acceleration.y;
                     
        var movement = new Vector3 (moveH, 0.0f, moveV);
                     
        rb.AddForce(movement * speed * 0.8f);
        
        /*
        var dir = Vector3.zero;

        // ターゲット端末の縦横の表示に合わせてremapする
        dir.x = Input.acceleration.x;
        dir.z = Input.acceleration.y;

        // clamp acceleration vector to the unit sphere
        if (dir.sqrMagnitude > 1)
            dir.Normalize();

        // Make it move 10 meters per second instead of 10 meters per frame...
        dir *= Time.deltaTime;

        // Move object
        transform.Translate(dir * speed);
        */
        }

    }