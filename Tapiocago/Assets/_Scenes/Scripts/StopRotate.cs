﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopRotate : MonoBehaviour
{
    int i = 0;
    bool flag = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (flag)
        {
            if (i < 40)
            {
                transform.Rotate(new Vector3(0, 0, 35));
            }
            if (40 <= i && i < 80)
            {
                transform.Rotate(new Vector3(0, 0, 20));
            }
            if (80<=i && i < 110)
            {
                transform.Rotate(new Vector3(0, 0, 10));
            }
            if (110 <= i)
            {
                transform.Rotate(new Vector3(0, 0, 5));
            }
            i += 1;
        }
        if (i >= 160)
        {
            i = 0;
            flag = false;
        }
    }

    public void onClickAct()
    {

        Debug.Log("タッチされたにゃー");
        flag = true;

    }
}
