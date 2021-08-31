using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AsteroidMove : MonoBehaviour
{
    private Vector2 velocity;
    private Animator animator;
    private float r = 1.25f;
    private float speed = 1f;


    void Start()
    {
        velocity = UnityEngine.Random.insideUnitCircle.normalized;
        animator = GetComponent<Animator>();
    }


    void FixedUpdate()
    {
        Vector3 a = transform.position;
        
        // if asteroid not in circle
        if (a.x * a.x + a.y * a.y > r * r)
        {
            GameObject.Find("ScoreManager").GetComponent<ScoreManager>().SaveScore();
            SceneManager.LoadScene(0);
        }
        transform.Translate(speed * Time.deltaTime * velocity, Space.World);
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        // if asteroid collision with bullet
        if (collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
        }
    }


    private void OnDestroy()
    {
        velocity = Vector2.zero;
        animator.SetTrigger("Break");
    }
}
