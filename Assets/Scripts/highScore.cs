using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class highScore : MonoBehaviour
{
    private static int highestScore;
    Text highScoreText;
    // Start is called before the first frame update
    void Start()
    {
        highScoreText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        highScoreText.text = "Your Score= " + highestScore;
        
        
        if (highestScore < ScoreScript.scoreValue)
        {
            highestScore = ScoreScript.scoreValue;

            //PlayerPrefs.SetInt("totalScoreKey", highestScore);
            //highestScore.text = "" + PlayerPrefs.GetInt("totalScoreKey");
        }

    }
}
