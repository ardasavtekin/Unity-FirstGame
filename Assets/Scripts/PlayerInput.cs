using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInput : MonoBehaviour
{

    

    public bool IsPressLeft => Input.GetKeyDown(KeyCode.LeftArrow);
    public bool IsPressRight => Input.GetKeyDown(KeyCode.RightArrow);
    public bool IsPressUp => Input.GetKeyDown(KeyCode.UpArrow);
    public bool IsPressDown => Input.GetKeyDown(KeyCode.DownArrow);

    //public bool IsPressRotateZ => Input.GetKeyDown(KeyCode.D);
    public bool IsPressRotateY => Input.GetKeyDown(KeyCode.S);
    //public bool IsPressRotateX => Input.GetKeyDown(KeyCode.A);

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            Time.timeScale = 10f;
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            Time.timeScale = 1;
        }
        if (IsPressLeft)
        {
            var current = Manager.Instance.Current.transform;
            var position = current.position;
            var value = -1;
            var isMovable = Manager.Instance.IsInside(GetPreviewPosition(value));
            if (isMovable)
            {
                position.x += value;
                //position += new Vector3(-1, 0, 0);
                current.position = position;
            }
        }
        if (IsPressRight)
        {
            var current = Manager.Instance.Current.transform;
            var position = current.position;
            var value = 1;
            var isMovable = Manager.Instance.IsInside(GetPreviewPosition(value));
            if (isMovable)
            {
                position.x += value;
                //position += new Vector3(+1, 0, 0);
                current.position = position;
            }
        }
        if (IsPressUp)
        {
            var current = Manager.Instance.Current.transform;
            var position = current.position;
            var value = 1;
            var isMovable = Manager.Instance.IsInside(GetPreviewPosition(value));
            if (isMovable)
            {
                position.z += value;
                //position += new Vector3(0, 0, +1);
                current.position = position;
            }
        }
        if (IsPressDown)
        {
            var current = Manager.Instance.Current.transform;
            var position = current.position;
            var value = -1;
            var isMovable = Manager.Instance.IsInside(GetPreviewPosition(value));
            if (isMovable)
            {
                position.z += value;
                //position += new Vector3(0, 0, -1);
                current.position = position;
            }
        }
        
        //ROTATE
        /*if (IsPressRotateZ) 
        {
            var isRotatable = Manager.Instance.IsInside(GetPreviewRotationZPosition());
            if (isRotatable)
            {
                RotateZ();
            }
        }*/
        if (IsPressRotateY) 
        {
            var isRotatable = Manager.Instance.IsInside(GetPreviewRotationYPosition());
            if (isRotatable)
            {
                RotateY();
            }
        }
        /*if (IsPressRotateX) 
        {
            var isRotatable = Manager.Instance.IsInside(GetPreviewRotationXPosition());
            if (isRotatable)
            {
                RotateX();
            }
        }*/

    }
    /*private List<Vector3> GetPreviewRotationXPosition()
    {
        var result = new List<Vector3>();
        var listPiece = Manager.Instance.Current.ListPiece;
        var pivot = Manager.Instance.Current.transform.position;
        if (IsPressRotateX)
        {
            foreach (var piece in listPiece)

            {
                var position = piece.position;
                position -= pivot;

                position = new Vector3(0, position.z, -position.y);
                position += pivot;

                result.Add(position);

            }
        }
        return result;

    }*/
    private List<Vector3> GetPreviewRotationYPosition()
    {
        var result = new List<Vector3>();
        var listPiece = Manager.Instance.Current.ListPiece;
        var pivot = Manager.Instance.Current.transform.position;
        
        if (IsPressRotateY)
        {
            foreach (var piece in listPiece)

            {
                var position = piece.position;
                position -= pivot;

                position = new Vector3(-position.z, 0, position.x);
                position += pivot;

                result.Add(position);

            }
        }
        return result;

    }
    /*private List<Vector3> GetPreviewRotationZPosition()
    {
        var result = new List<Vector3>();
        var listPiece = Manager.Instance.Current.ListPiece;
        var pivot = Manager.Instance.Current.transform.position;
        if (IsPressRotateZ)
        {
            foreach (var piece in listPiece)

            {
                var position = piece.position;
                position -= pivot;

                position = new Vector3(-position.y, position.x, 0);
                position += pivot;

                result.Add(position);

            }
        }
        return result;

    }*/
   
    private List<Vector3> GetPreviewPosition(int value)
    {
        var result = new List<Vector3>();
        var listPiece = Manager.Instance.Current.ListPiece;
        if (IsPressLeft || IsPressRight)
        {
            foreach (var piece in listPiece)

            {
                var position = piece.position;
                position.x += value;
                result.Add(position);

            }
        }
        else
        {
            foreach (var piece in listPiece)
            {
                var position = piece.position;
                position.z += value;
                result.Add(position);

            }
        }

        return result;
    }
    /*private void RotateZ()
    {
        var current = Manager.Instance.Current.transform;
        var angles = current.eulerAngles;
        angles.z += -90;
        current.eulerAngles = angles;
    }*/
    private void RotateY()
    {
        var current = Manager.Instance.Current.transform;
        var angles = current.eulerAngles;
        angles.y += -90;
        current.eulerAngles = angles;
    }
    /*private void RotateX()
    {
        var current = Manager.Instance.Current.transform;
        var angles = current.eulerAngles;
        angles.x += -90;
        current.eulerAngles = angles;
    }*/
}

