using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManagement : MonoBehaviour
{
    public GameObject PauseMenuCanvas;
    public GameObject PauseMenuButton;
    public GameObject ResumeButton;
   
    public GameObject controlCanvas;

    public void Start()
    {
        PauseMenuCanvas.SetActive(false);
        PauseMenuButton.SetActive(true);
        controlCanvas.SetActive(true);


    }

    public void PauseGame()
    {

        PauseMenuButton.SetActive(false);
        
        controlCanvas.SetActive(false);

        PauseMenuCanvas.SetActive(true);


        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        PauseMenuCanvas.SetActive(false);
        PauseMenuButton.SetActive(true);
        Time.timeScale = 1;
        controlCanvas.SetActive(true);

    }
}
