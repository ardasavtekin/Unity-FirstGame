using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInput : MonoBehaviour
{

    

    //public bool IsPressLeft => Input.GetKeyDown(KeyCode.LeftArrow);
    //public bool IsPressRight => Input.GetKeyDown(KeyCode.RightArrow);
    //public bool IsPressUp => Input.GetKeyDown(KeyCode.UpArrow);
    //public bool IsPressDown => Input.GetKeyDown(KeyCode.DownArrow);

    //public bool IsPressRotateZ => Input.GetKeyDown(KeyCode.D);
    public bool IsPressRotateY => Input.GetKeyDown(KeyCode.S);
    //public bool IsPressRotateX => Input.GetKeyDown(KeyCode.A);
    public bool IsPressG => Input.GetKeyDown(KeyCode.G);

    public bool IsPressRight= false;
    public bool IsPressLeft = false;
    public bool IsPressUp = false;
    public bool IsPressDown = false;
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

        if (Input.touchCount > 0)
        {
            Touch finger = Input.GetTouch(0);
            int x = Mathf.RoundToInt(finger.deltaPosition.x);
            int y = Mathf.RoundToInt(finger.deltaPosition.y);

            if (x > 35)
            {
                IsPressRight = true;
            }
            if(x < -35)
            {
                IsPressLeft = true;
            }
            if (y > 35)
            {
                IsPressUp = true;
            }
            if (y < -35)
            {
                IsPressDown = true;
            }
        }
        
            if (CamMovement.rotateCam == false)
        {
            if (IsPressLeft)
            {
                var current = Manager.Instance.Current.transform;
                var position = current.position;
                var value = -1;
                var isMovable = Manager.Instance.IsInside(GetPreviewPosition(value));
                if (isMovable)
                {
                 var NewXPos = Mathf.Clamp(position.x + value, -0.1f, 8.1f);
                    //position.x += value;
                    //position += new Vector3(-1, 0, 0);
                    current.position = new Vector3(NewXPos, current.position.y, current.position.z);
                    IsPressLeft = false;
                }
            }
            if (IsPressRight)
            {
                var current = Manager.Instance.Current.transform;
                var position = current.position;

                var value = 1;
                var isMovable = Manager.Instance.IsInside(GetPreviewPosition(value));
                if (isMovable )
                {
                    var NewXPos = Mathf.Clamp(position.x + value, -0.1f, 8.1f);
                    //position.x += value;
                    //position += new Vector3(+1, 0, 0);
                    current.position = new Vector3(NewXPos, current.position.y, current.position.z);
                    IsPressRight = false;
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
                    var NewZPos = Mathf.Clamp(position.z + value, -0.1f, 8.1f);

                    // position.z += value;
                    //position += new Vector3(0, 0, +1);
                    current.position = new Vector3(current.position.x, current.position.y, NewZPos);
                    IsPressUp = false;
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
                    var NewZPos = Mathf.Clamp(position.z + value, -0.1f, 8.1f);

                    //position.z += value;
                    //position += new Vector3(0, 0, -1);
                    current.position = new Vector3(current.position.x, current.position.y, NewZPos);
                    IsPressDown = false;
                }
            } 

         } else if (CamMovement.rotateCam == true)
        {
            if (IsPressDown)
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
            if (IsPressUp)
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
            if (IsPressLeft)
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
            if (IsPressRight)
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
        if (CamMovement.rotateCam == false)
        {
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
        }
        if(CamMovement.rotateCam == true)
        {
            if (IsPressLeft)
            {
                foreach (var piece in listPiece)

                {
                    var position = piece.position;
                    position.z += 1;
                    result.Add(position);

                }
            }
            if (IsPressRight)
            {
                foreach (var piece in listPiece)

                {
                    var position = piece.position;
                    position.z += -1;
                    result.Add(position);

                }
            }
            if (IsPressUp)
            {
                foreach (var piece in listPiece)

                {
                    var position = piece.position;
                    position.x += 1;
                    result.Add(position);

                }
            }
            if (IsPressDown)
            {
                foreach (var piece in listPiece)

                {
                    var position = piece.position;
                    position.x += -1;
                    result.Add(position);

                }
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

