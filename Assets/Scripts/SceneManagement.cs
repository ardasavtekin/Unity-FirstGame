using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{ //arda
    public GameObject PauseMenuCanvas;
    public GameObject PauseMenuButton;
    public GameObject ResumeButton;

    public void Start()
    {
        PauseMenuCanvas.SetActive(false);

    }

    
    public void changeScene(int sceneId)
    {
        SceneManager.LoadScene(sceneId);
    }

    public void PauseGame()
    {
        PauseMenuCanvas.SetActive(true);
        PauseMenuButton.SetActive(false);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        PauseMenuCanvas.SetActive(false);
        PauseMenuButton.SetActive(true);
        Time.timeScale = 1;
    }
}
