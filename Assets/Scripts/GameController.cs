using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    public int TotalScore;
    public static GameController instance;
    public Text ScoreText;

    void Start()
    {
        instance = this;
    }

    public void UpdateScore()
    {
        ScoreText.text = TotalScore.ToString();
    }
}
