using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuManager : MonoBehaviour
{
    public string GameScreen;
    public string Settings;
    public void GameScene()
    {
        SceneManager.LoadScene(GameScreen);
        
    }
    public void SettingsScene()
    {
        SceneManager.LoadScene(Settings);
    }
}
