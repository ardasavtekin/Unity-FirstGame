using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneManagement : MonoBehaviour
{
    public void changeScene(int sceneId)
    {
        SceneManager.LoadScene(sceneId);
        Time.timeScale = 1;
    }
}
