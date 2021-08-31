using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletMove : MonoBehaviour
{
    public float speed;
    Vector2 vel;


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

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Asteroid"))
        {
            GameObject.Find("Ship").GetComponent<Ship>().IncreaseAsteroidScore();
            Destroy(collision.gameObject);
        }
    }
}
