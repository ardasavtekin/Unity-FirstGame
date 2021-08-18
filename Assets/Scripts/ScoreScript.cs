using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static int perscore= 5;
    public static int scoreValue = 0;
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

    }
}
