using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AsteroidMove : MonoBehaviour
{
    public float speed;
    public Animator animator;
    public GameObject aster_text;

    Vector2 vel;
    private float r = 1.25f;

    void Start()
    {
        vel = UnityEngine.Random.insideUnitCircle.normalized;
        animator = GetComponent<Animator>();
        aster_text = GameObject.Find("AsteroidScoreText");
    }

    void FixedUpdate()
    {
        Vector3 a = transform.position;
            
        if (a.x * a.x + a.y * a.y > r * r)
        {
            Break();
            SceneManager.LoadScene(0);
        }
        transform.Translate(speed * Time.deltaTime * vel, Space.World);
    }

    void Break()
    {
        vel = Vector2.zero;
        animator.SetBool("Break", true);
    }

    void DestroyAsteroid()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            int curr_score = Convert.ToInt32(aster_text.GetComponent<Text>().text);
            aster_text.GetComponent<Text>().text = curr_score++.ToString();
            Break();
        }
    }
}
