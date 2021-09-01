using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerEx : MonoBehaviour
{
    public int TotalScore;
    public static GameControllerEx instance;
    public Text ScoreText;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;        
    }

    // Update is called once per frame
    public void UpdateScore()
    {
        ScoreText.text = TotalScore.ToString();
    }
}
