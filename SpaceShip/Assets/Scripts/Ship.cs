using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ship : MonoBehaviour
{
    public bool move_type = true;
    public float move_var_1; 
    public float move_var_2;
    //public Transform rim;
    public GameObject scoreText;
    public Animator animator;

    //private Camera mCamera;
    private int score;
    private int type_of_ship;
    private Vector3 lerp_pos;
    private float r = 1.25f;


    void Start()
    {
        try
        {
            type_of_ship = TypeOfShipSaver.control.type_of_ship;
        }
        catch
        {
            type_of_ship = 1;
        }
            animator = GetComponent<Animator>();
            animator.SetInteger("Type of Ship", type_of_ship);
        lerp_pos.z = -1;
        //gameObject.AddComponent<Camera>();
        //mCamera = Camera.main;
    }

    
    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                // touch calculate
                Vector3 touch_pos = touch.position;
                //Vector3 camera_pos = mCamera.GetComponent<Transform>().position;
                //Vector3 rim_pos = rim.position;
                Vector3 centre = new Vector3(Screen.width / 2, Screen.height / 2, 0);

                
                //float halfHeight = mCamera.orthographicSize;
                //float halfWidth = mCamera.aspect * halfHeight;
                //float horizontalMin = -halfWidth;
                //float horizontalMax = halfWidth;

                touch_pos -= centre;
                //touch_pos -= rim_pos;
                //touch_pos += new Vector3(halfWidth, halfHeight, 0);



                // move
                if (move_type)
                {
                    lerp_pos = Vector3.MoveTowards(lerp_pos, Vector2.Lerp(lerp_pos, touch_pos, move_var_1), move_var_2);
                }
                else 
                {
                    lerp_pos = Vector3.Lerp(lerp_pos, Vector2.MoveTowards(lerp_pos, touch_pos, move_var_2), move_var_1);
                }
                lerp_pos.Normalize();
                lerp_pos *= r;
                gameObject.transform.position = lerp_pos;

                
                
                // rotation
                float z_rotate;
                if (lerp_pos.y >= 0)
                {
                    z_rotate = Vector3.Angle(Vector2.right, lerp_pos) + 90;
                }
                else 
                {
                    z_rotate = Vector3.Angle(Vector2.left, lerp_pos) - 90;
                }
                gameObject.transform.eulerAngles = Vector3.forward * z_rotate;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Emerald"))
        {
            score++;
            scoreText.GetComponent<Text>().text = score.ToString();
            Destroy(collision.gameObject);
        }
    }
}
