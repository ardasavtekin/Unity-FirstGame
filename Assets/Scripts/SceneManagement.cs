using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneManagement : MonoBehaviour
{
    public void changeScene(int sceneId)
    {
        SceneManager.LoadScene(sceneId);
        ScoreScript.scoreValue = 0;
        Time.timeScale = 1;
    }
}
