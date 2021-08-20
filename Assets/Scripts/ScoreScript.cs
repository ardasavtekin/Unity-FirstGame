using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public static int perscore= 5;
    public static int scoreValue = 0;
    private int highestScore = 0;
    public TextMeshProUGUI highestScoreText;
    

    Text scoreText;
    // Start is called before the first frame update
    private void Start()
    {
        scoreText = GetComponent<Text>();
    }
    // Update is called once per frame
    void Update()
    {
        scoreText.text = ""+scoreValue;
        
        if (highestScore < scoreValue)
        {
            highestScore = scoreValue;
            highestScoreText.text = "" + highestScore;
                    
        }
        
    }
}
