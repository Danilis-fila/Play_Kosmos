using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuRender : MonoBehaviour
{
    public static MainMenuRender instanse;
    public bool resetAllVariables;
    public Text highscoreText;
    private int highscore;


    private void Awake()
    {
        instanse = this;
    }

    
    private void Start()
    {
        if (resetAllVariables)
        {
            PlayerPrefs.SetInt("highscore", 0);
            PlayerPrefs.SetInt("emeralds", 0);
            PlayerPrefs.SetInt("type of ship", 1);
            PlayerPrefs.SetInt("Cage1", 2);
            PlayerPrefs.SetInt("Cage2", 0);
            PlayerPrefs.SetInt("Cage3", -1);
            PlayerPrefs.SetInt("Cage4", -1);
        }
        highscore = PlayerPrefs.GetInt("highscore", 0);
        highscoreText.text = "higest: " + highscore.ToString();
    }
}
