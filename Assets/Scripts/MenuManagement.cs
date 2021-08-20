﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManagement : MonoBehaviour
{
    public GameObject PauseMenuCanvas;
    public GameObject PauseMenuButton;
    public GameObject ResumeButton;

    public void Start()
    {
        PauseMenuCanvas.SetActive(false);
        PauseMenuButton.SetActive(true);



    }

    public void PauseGame()
    {

        PauseMenuButton.SetActive(false);
        PauseMenuCanvas.SetActive(true);


        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        PauseMenuCanvas.SetActive(false);
        PauseMenuButton.SetActive(true);
        Time.timeScale = 1;
    }
}
