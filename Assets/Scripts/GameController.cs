using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    public int TotalScore;
    public int Life;
    public static GameController instance;
    public Text ScoreText;
    public Text LifeText;

    void Start()
    {
        instance = this;
        UpdateScoreText();
        UpdateLifeText();
    }

    public void UpdateScoreText()
    {
        ScoreText.text = TotalScore.ToString();
    }

    public void UpdateLifeText()
    {
        LifeText.text = Life.ToString();
    }
}
