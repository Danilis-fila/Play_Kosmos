using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmeraldPickUpCounter : MonoBehaviour
{
    public int score = 0;
    public GameObject scoreText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ship"))
        {
            score++;
            scoreText.GetComponent<UnityEngine.UI.Text>().text = score.ToString();
            Destroy(gameObject); 
        }
    }
}
