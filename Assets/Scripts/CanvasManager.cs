using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    
    public GameObject ground;
    public GameObject quad;
    public GameObject target;
    [SerializeField] public int cam = 0;
    public GameObject PauseMenuCanvas;
    public GameObject PauseMenuButton;
    public GameObject ResumeButton;
    [SerializeField]  public GameObject GameOverCanvas;
    public GameObject controlCanvas;
    int focus = 0;
    public GameObject focusButton;

    public void Awake()
    {
        GameOverCanvas.SetActive(false);
    }
    public void Start()
    {
        PauseMenuCanvas.SetActive(false);
        focusButton.SetActive(false);
        target = GameObject.FindWithTag("ground");


        PauseMenuButton.SetActive(true);


    }

    public void PauseGame()
    {
        focusButton.SetActive(true);

        PauseMenuButton.SetActive(false);
        PauseMenuCanvas.SetActive(true);
        Time.timeScale = 0.01f;

        cam = 1;
    }

    public void ResumeGame()
    {
        PauseMenuCanvas.SetActive(false);
        PauseMenuButton.SetActive(true);
        focusButton.SetActive(false);
        cam = 0;
        Time.timeScale = 1f;
        var speed = Manager.Instance.GameSpeed;
        speed = 0.1f;


        controlCanvas.SetActive(true);
        ground.transform.position = new Vector3(26.58f, 40.92f, -41.6f);
        quad.transform.position = new Vector3(-68.9f, -21f, 33.6f);

        ground.transform.rotation = Quaternion.Euler(30.742f, -26.302f, -0.632f);
        quad.transform.rotation = Quaternion.Euler(0f, -23.453f, 0f);
        

    }

    public void Update()
    {
        if (cam == 1)
        {
            ground.transform.RotateAround(target.transform.position, Vector3.up, Time.deltaTime * 3000);
            quad.transform.RotateAround(target.transform.position, Vector3.up, Time.deltaTime * 3000);

        }
    }

    public void focusCam()
    {
        if (focus == 0)
        {
            PauseMenuCanvas.SetActive(false);

            Time.timeScale = 0;
            focus += 1;

        }else if (focus == 1){
            PauseMenuCanvas.SetActive(true);

            Time.timeScale = 0.01f;
            focus -= 1;

        }
    }
}
