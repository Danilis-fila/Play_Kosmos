using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float speed;
    Vector2 vel;
    private Vector3 centre = new Vector3(Screen.width / 2, Screen.height / 2, 0);

    void Start()
    {
        vel = transform.rotation * Vector2.up;
    }

    void FixedUpdate()
    {
        Vector2 a = (Vector2)transform.position;

        if (a.x * a.x + a.y * a.y < 0.2f * 0.2f)
        {
            Destroy(gameObject);
        }
        transform.Translate(speed * vel * Time.deltaTime, Space.World);
    }
}
