using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ship : MonoBehaviour
{
    public Sprite Ship1;
    public Sprite Ship2;

    private float r = 1.25f;
    private ScoreManager scoreManager;

    void Start()
    {
        int typeOfShip = PlayerPrefs.GetInt("type of ship", 1);
        if (typeOfShip == 1)
        {
            GetComponent<SpriteRenderer>().sprite = Ship1;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = Ship2;
            transform.localScale = new Vector3(0.08f, 0.08f, 0.08f);
        }
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    
    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                // touch calculate
                Vector3 touch_pos = touch.position;
                Vector3 centre = new Vector3(Screen.width / 2, Screen.height / 2, 0);

                // move
                touch_pos.z = -1;
                touch_pos -= centre;
                touch_pos.Normalize();
                touch_pos *= r;
                gameObject.transform.position = touch_pos;

                // rotation
                float z_rotate;
                if (touch_pos.y >= 0)
                {
                    z_rotate = Vector3.Angle(Vector2.right, touch_pos) + 90;
                }
                else 
                {
                    z_rotate = Vector3.Angle(Vector2.left, touch_pos) - 90;
                }
                gameObject.transform.eulerAngles = Vector3.forward * z_rotate;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Emerald"))
        {
            scoreManager.AddEmerald();
            Destroy(collision.gameObject);
        }
    }


    public void IncreaseAsteroidScore()
    {
        scoreManager.AddPoint();
    }
}
