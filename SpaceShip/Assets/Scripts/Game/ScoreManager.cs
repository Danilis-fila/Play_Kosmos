using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instanse;

    public Text emeraldsText;
    public Text scoreText;

    private int emeralds;
    private int score;
    private int highscore;

    private void Awake()
    {
        instanse = this;
    }

    public void AddEmerald()
    {
        emeralds += 1;
        emeraldsText.text = emeralds.ToString();
    }

    public void AddPoint()
    {
        score += 1;
        scoreText.text = score.ToString();
        if (score > highscore)
        {
            highscore = score;
        }
    }

    public void SaveScore()
    {
        int playerEmeralds = PlayerPrefs.GetInt("emeralds", 0);
        int playerHighscore = PlayerPrefs.GetInt("highscore", 0);

        playerEmeralds += emeralds;
        if (playerHighscore < highscore)
        {
            playerHighscore = highscore;
        }

        PlayerPrefs.SetInt("emeralds", playerEmeralds);
        PlayerPrefs.SetInt("highscore", playerHighscore);
    }
}
