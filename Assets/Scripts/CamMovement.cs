using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    public GameObject target;
    public static bool rotateCam = false;

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
            }
            else if (rotateCam == true)
            {
                camNegativeTurn();
                rotateCam = false;
            }
        }
    }

    public void camTurn()
    {
        ground.transform.RotateAround(target.transform.position, Vector3.up, 90);
        quad.transform.RotateAround(target.transform.position, Vector3.up, 90);
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

    public void clickButton()
    {
        if (rotateCam == false)
        {
            camTurn();
            rotateCam = true;
        }
        else if (rotateCam == true)
        {
            camNegativeTurn();
            rotateCam = false;
        }
    }
    public void speed()
    {
        Time.timeScale = 10f;
    }

    /*public void rotateY()
    {
        var isRotatable = Manager.Instance.IsInside(GetPreviewRotationYPosition());
        if (isRotatable)
        {
            var current = Manager.Instance.Current.transform;
            var angles = current.eulerAngles;
            angles.y += -90;
            current.eulerAngles = angles;
        }
    }
    public List<Vector3> GetPreviewRotationYPosition()
    {
        var result = new List<Vector3>();
        var listPiece = Manager.Instance.Current.ListPiece;
        var pivot = Manager.Instance.Current.transform.position;

        foreach (var piece in listPiece)

        {
            var position = piece.position;
            position -= pivot;

            position = new Vector3(-position.z, 0, position.x);
            position += pivot;

            result.Add(position);

        }

        return result;
    }*/
}