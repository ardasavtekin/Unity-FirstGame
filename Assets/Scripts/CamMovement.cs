using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    public GameObject target;
    public static  bool rotateCam = false;

    public GameObject ground;
    public GameObject quad;
    public GameObject target2;
    public GameObject rawImage;
    

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("ground");
        target2 = GameObject.FindWithTag("MainCam");
        rawImage = GameObject.FindWithTag("RawImage");


    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (rotateCam == false)
            {
                camTurn();
                rotateCam = true;

            }else if (rotateCam == true){

                camNegativeTurn();
                rotateCam = false;
            }
            
        }

    }

    public void camTurn()
    {   
            
            ground.transform.RotateAround(target.transform.position, Vector3.up, 90) ;
            quad.transform.RotateAround(target.transform.position, Vector3.up , 90);
            target2.SetActive(false);
            rawImage.SetActive(false);
            
    }

    public void camNegativeTurn()
    {
        ground.transform.RotateAround(target.transform.position, Vector3.up, -90);
        quad.transform.RotateAround(target.transform.position, Vector3.up, -90);
        target2.SetActive(true);
        rawImage.SetActive(true);
        
    }

}
