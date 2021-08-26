using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmeraldMove : MonoBehaviour
{
    public float dt;
    public float k;
    private float x;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - (float)Math.Sin(x * k), transform.position.z);
        x += dt;
    }
}
