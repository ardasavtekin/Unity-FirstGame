using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//selam hakanaaa
public class  BlockController: MonoBehaviour
{
    public MeshRenderer mr;
    public List<Transform> ListPiece => listPiece;
    [SerializeField] private List<Transform> listPiece = new List<Transform>();
    //public List<GameObject> ListBlocks => listBlocks;
    //[SerializeField] private List<GameObject> listBlocks = new List<GameObject>();

    public List<GameObject> xEksenindekiler;
    public List<GameObject> yEksenindekiler;
    public List<GameObject> zEksenindekiler;

    void Start()
    {
        StartCoroutine( MoveY());
    }
    void Update()
    {
        //MoveXZ(); 
    }
    IEnumerator MoveY()
    {
        while (true)
        {
            var delay = Manager.Instance.GameSpeed;
            yield return new WaitForSeconds(delay);

            var isMovable = Manager.Instance.IsInside(GetPreviewPosition());
            if (isMovable)
            {
                Move();
            }
            else
            {
                foreach(var piece in listPiece)
                {
                    int x = Mathf.RoundToInt(piece.position.x);
                    int y = Mathf.RoundToInt(piece.position.y);
                    int z = Mathf.RoundToInt(piece.position.z);
                    Manager.Instance.Grid[x, y, z] = true;
                    
                    if (listPiece.IndexOf(piece) == 0)
                    {
                        Manager.Instance.gameobjectGrid[x, y, z] = piece.gameObject;


                        Manager.Instance.ColorGrid[x, y, z] = "red";
                        for (int i = x + 1; i <= Manager.GridSizeX; i++)
                        {
                            var upBlock = Manager.Instance.gameobjectGrid[i, y, z];
                            if (Manager.Instance.ColorGrid[i, y, z] == "red")
                            {
                                xEksenindekiler.Add(upBlock);
                            }
                            else
                            {
                                break;
                            }
                        }
                        for (int i = x - 1; i >= 0; i--)
                        {
                            var downBlock = Manager.Instance.gameobjectGrid[i, y, z];
                            if (Manager.Instance.ColorGrid[i, y, z] == "red")
                            {
                                xEksenindekiler.Add(downBlock);
                            }
                            else
                            {
                                break;
                            }
                        }
                        for (int i = y+1 ; i <= Manager.GridSizeY; i++)
                        {
                            var upBlock = Manager.Instance.gameobjectGrid[x, i, z];
                            if (Manager.Instance.ColorGrid[x, i, z] == "red")
                            {
                                yEksenindekiler.Add(upBlock);
                            }
                            else
                            {
                                break;
                            }
                        }
                        for (int i = y-1 ; i >= 0; i--)
                        {
                            var downBlock = Manager.Instance.gameobjectGrid[x, i, z];
                            if (Manager.Instance.ColorGrid[x, i, z] == "red")
                            {
                                yEksenindekiler.Add(downBlock);
                            }
                            else
                            {
                                break;
                            }
                        }
                        for (int i = z+1 ; i <= Manager.GridSizeZ; i++)
                        {
                            var frontBlock = Manager.Instance.gameobjectGrid[x, y, i];
                            if (Manager.Instance.ColorGrid[x, y, i] == "red")
                            {
                                zEksenindekiler.Add(frontBlock);
                            }
                            else
                            {
                                break;
                            }
                        }
                        for (int i = z-1 ; i >= 0; i--)
                        {
                            var behindBlock = Manager.Instance.gameobjectGrid[x, y, i];
                            if (Manager.Instance.ColorGrid[x, y, i] == "red")
                            {
                                zEksenindekiler.Add(behindBlock);
                            }
                            else
                            {
                                break;
                            }
                            
                        }
                        if(xEksenindekiler.Count >=3)
                        {
                            xEksenindekiler.Add(piece.gameObject);
                            
                            foreach(var item in xEksenindekiler)
                            {
                               

                                
                                ScoreScript.scoreValue += ScoreScript.perscore;
                                GameObject.Destroy(item.gameObject);
                                var j = Mathf.RoundToInt(item.transform.position.x);
                                var k = Mathf.RoundToInt(item.transform.position.y);
                                var l = Mathf.RoundToInt(item.transform.position.z);
                                
                                Manager.Instance.ColorGrid[j, k, l] = "";
                                Manager.Instance.Grid[j, k, l] = false;

                            }
                            xEksenindekiler.Clear();
                        }
                        if (yEksenindekiler.Count >= 3)
                        {
                            yEksenindekiler.Add(piece.gameObject);
                            foreach (var item in yEksenindekiler)
                            {
                                
                                ScoreScript.scoreValue += ScoreScript.perscore;
                                GameObject.Destroy(item.gameObject);
                                var j = Mathf.RoundToInt(item.transform.position.x);
                                var k = Mathf.RoundToInt(item.transform.position.y);
                                var l = Mathf.RoundToInt(item.transform.position.z);

                                Manager.Instance.ColorGrid[j, k, l] = "";
                                Manager.Instance.Grid[j, k, l] = false;

                            }
                            yEksenindekiler.Clear();
                        }
                        if (zEksenindekiler.Count >= 3)
                        {
                            zEksenindekiler.Add(piece.gameObject);
                            foreach (var item in zEksenindekiler)
                            {
                                
                                ScoreScript.scoreValue += ScoreScript.perscore;
                                GameObject.Destroy(item.gameObject);
                                var j = Mathf.RoundToInt(item.transform.position.x);
                                var k = Mathf.RoundToInt(item.transform.position.y);
                                var l = Mathf.RoundToInt(item.transform.position.z);

                                Manager.Instance.ColorGrid[j, k, l] = "";
                                Manager.Instance.Grid[j, k, l] = false;

                            }
                            zEksenindekiler.Clear();
                        }
                        xEksenindekiler.Clear();
                        yEksenindekiler.Clear();
                        zEksenindekiler.Clear();


                    }
                    if (listPiece.IndexOf(piece) == 1)
                    {
                        Manager.Instance.gameobjectGrid[x, y, z] = piece.gameObject;
                        Manager.Instance.ColorGrid[x, y, z] = "green";
                        for (int i = x + 1; i <= Manager.GridSizeX; i++)
                        {
                            var upBlock = Manager.Instance.gameobjectGrid[i, y, z];
                            if (Manager.Instance.ColorGrid[i, y, z] == "green")
                            {
                                xEksenindekiler.Add(upBlock);
                            }
                            else
                            {
                                break;
                            }
                        }
                        for (int i = x - 1; i >= 0; i--)
                        {
                            var downBlock = Manager.Instance.gameobjectGrid[i, y, z];
                            if (Manager.Instance.ColorGrid[i, y, z] == "green")
                            {
                                xEksenindekiler.Add(downBlock);
                            }
                            else
                            {
                                break;
                            }
                        }
                        for (int i = y + 1; i <= Manager.GridSizeY; i++)
                        {
                            var upBlock = Manager.Instance.gameobjectGrid[x, i, z];
                            if (Manager.Instance.ColorGrid[x, i, z] == "green")
                            {
                                yEksenindekiler.Add(upBlock);
                            }
                            else
                            {
                                break;
                            }
                        }
                        for (int i = y - 1; i >= 0; i--)
                        {
                            var downBlock = Manager.Instance.gameobjectGrid[x, i, z];
                            if (Manager.Instance.ColorGrid[x, i, z] == "green")
                            {
                                yEksenindekiler.Add(downBlock);
                            }
                            else
                            {
                                break;
                            }
                        }
                        for (int i = z + 1; i <= Manager.GridSizeZ; i++)
                        {
                            var frontBlock = Manager.Instance.gameobjectGrid[x, y, i];
                            if (Manager.Instance.ColorGrid[x, y, i] == "green")
                            {
                                zEksenindekiler.Add(frontBlock);
                            }
                            else
                            {
                                break;
                            }
                        }
                        for (int i = z - 1; i >= 0; i--)
                        {
                            var behindBlock = Manager.Instance.gameobjectGrid[x, y, i];
                            if (Manager.Instance.ColorGrid[x, y, i] == "green")
                            {
                                zEksenindekiler.Add(behindBlock);
                            }
                            else
                            {
                                break;
                            }

                        }
                        if (xEksenindekiler.Count >= 3)
                        {
                            xEksenindekiler.Add(piece.gameObject);
                            foreach (var item in xEksenindekiler)
                            {
                                ScoreScript.scoreValue += ScoreScript.perscore;
                                GameObject.Destroy(item.gameObject);
                                var j = Mathf.RoundToInt(item.transform.position.x);
                                var k = Mathf.RoundToInt(item.transform.position.y);
                                var l = Mathf.RoundToInt(item.transform.position.z);

                                Manager.Instance.ColorGrid[j, k, l] = "";
                                Manager.Instance.Grid[j, k, l] = false;

                            }
                            xEksenindekiler.Clear();
                        }
                        if (yEksenindekiler.Count >= 3)
                        {
                            yEksenindekiler.Add(piece.gameObject);
                            foreach (var item in yEksenindekiler)
                            {
                                ScoreScript.scoreValue += ScoreScript.perscore;
                                GameObject.Destroy(item.gameObject);
                                var j = Mathf.RoundToInt(item.transform.position.x);
                                var k = Mathf.RoundToInt(item.transform.position.y);
                                var l = Mathf.RoundToInt(item.transform.position.z);

                                Manager.Instance.ColorGrid[j, k, l] = "";
                                Manager.Instance.Grid[j, k, l] = false;

                            }
                            yEksenindekiler.Clear();
                        }
                        if (zEksenindekiler.Count >= 3)
                        {
                            zEksenindekiler.Add(piece.gameObject);
                            foreach (var item in zEksenindekiler)
                            {
                                ScoreScript.scoreValue += ScoreScript.perscore;
                                GameObject.Destroy(item.gameObject);
                                var j = Mathf.RoundToInt(item.transform.position.x);
                                var k = Mathf.RoundToInt(item.transform.position.y);
                                var l = Mathf.RoundToInt(item.transform.position.z);

                                Manager.Instance.ColorGrid[j, k, l] = "";
                                Manager.Instance.Grid[j, k, l] = false;

                            }
                            zEksenindekiler.Clear();
                        }
                        xEksenindekiler.Clear();
                        yEksenindekiler.Clear();
                        zEksenindekiler.Clear();
                    }
                    if (listPiece.IndexOf(piece) == 2)
                    {
                        Manager.Instance.gameobjectGrid[x, y, z] = piece.gameObject;
                        Manager.Instance.ColorGrid[x, y, z] = "yellow";
                        for (int i = x + 1; i <= Manager.GridSizeX; i++)
                        {
                            var upBlock = Manager.Instance.gameobjectGrid[i, y, z];
                            if (Manager.Instance.ColorGrid[i, y, z] == "yellow")
                            {
                                xEksenindekiler.Add(upBlock);
                            }
                            else
                            {
                                break;
                            }
                        }
                        for (int i = x - 1; i >= 0; i--)
                        {
                            var downBlock = Manager.Instance.gameobjectGrid[i, y, z];
                            if (Manager.Instance.ColorGrid[i, y, z] == "yellow")
                            {
                                xEksenindekiler.Add(downBlock);
                            }
                            else
                            {
                                break;
                            }
                        }
                        for (int i = y + 1; i <= Manager.GridSizeY; i++)
                        {
                            var upBlock = Manager.Instance.gameobjectGrid[x, i, z];
                            if (Manager.Instance.ColorGrid[x, i, z] == "yellow")
                            {
                                yEksenindekiler.Add(upBlock);
                            }
                            else
                            {
                                break;
                            }
                        }
                        for (int i = y - 1; i >= 0; i--)
                        {
                            var downBlock = Manager.Instance.gameobjectGrid[x, i, z];
                            if (Manager.Instance.ColorGrid[x, i, z] == "yellow")
                            {
                                yEksenindekiler.Add(downBlock);
                            }
                            else
                            {
                                break;
                            }
                        }
                        for (int i = z + 1; i <= Manager.GridSizeZ; i++)
                        {
                            var frontBlock = Manager.Instance.gameobjectGrid[x, y, i];
                            if (Manager.Instance.ColorGrid[x, y, i] == "yellow")
                            {
                                zEksenindekiler.Add(frontBlock);
                            }
                            else
                            {
                                break;
                            }
                        }
                        for (int i = z - 1; i >= 0; i--)
                        {
                            var behindBlock = Manager.Instance.gameobjectGrid[x, y, i];
                            if (Manager.Instance.ColorGrid[x, y, i] == "yellow")
                            {
                                zEksenindekiler.Add(behindBlock);
                            }
                            else
                            {
                                break;
                            }

                        }
                        if (xEksenindekiler.Count >= 3)
                        {
                            xEksenindekiler.Add(piece.gameObject);
                            foreach (var item in xEksenindekiler)
                            {
                                ScoreScript.scoreValue += ScoreScript.perscore;
                                GameObject.Destroy(item.gameObject);
                                var j = Mathf.RoundToInt(item.transform.position.x);
                                var k = Mathf.RoundToInt(item.transform.position.y);
                                var l = Mathf.RoundToInt(item.transform.position.z);

                                Manager.Instance.ColorGrid[j, k, l] = "";
                                Manager.Instance.Grid[j, k, l] = false;

                            }
                            xEksenindekiler.Clear();
                        }
                        if (yEksenindekiler.Count >= 3)
                        {
                            yEksenindekiler.Add(piece.gameObject);
                            foreach (var item in yEksenindekiler)
                            {
                                ScoreScript.scoreValue += ScoreScript.perscore;
                                GameObject.Destroy(item.gameObject);
                                var j = Mathf.RoundToInt(item.transform.position.x);
                                var k = Mathf.RoundToInt(item.transform.position.y);
                                var l = Mathf.RoundToInt(item.transform.position.z);

                                Manager.Instance.ColorGrid[j, k, l] = "";
                                Manager.Instance.Grid[j, k, l] = false;

                            }
                            yEksenindekiler.Clear();
                        }
                        if (zEksenindekiler.Count >= 3)
                        {
                            zEksenindekiler.Add(piece.gameObject);
                            foreach (var item in zEksenindekiler)
                            {
                                ScoreScript.scoreValue += ScoreScript.perscore;
                                GameObject.Destroy(item.gameObject);
                                var j = Mathf.RoundToInt(item.transform.position.x);
                                var k = Mathf.RoundToInt(item.transform.position.y);
                                var l = Mathf.RoundToInt(item.transform.position.z);

                                Manager.Instance.ColorGrid[j, k, l] = "";
                                Manager.Instance.Grid[j, k, l] = false;

                            }
                            zEksenindekiler.Clear();
                        }
                        xEksenindekiler.Clear();
                        yEksenindekiler.Clear();
                        zEksenindekiler.Clear();
                    }
                    if (listPiece.IndexOf(piece) == 3)
                    {
                        Manager.Instance.gameobjectGrid[x, y, z] = piece.gameObject;
                        Manager.Instance.ColorGrid[x, y, z] = "blue";
                        for (int i = x + 1; i <= Manager.GridSizeX; i++)
                        {
                            var upBlock = Manager.Instance.gameobjectGrid[i, y, z];
                            if (Manager.Instance.ColorGrid[i, y, z] == "blue")
                            {
                                xEksenindekiler.Add(upBlock);
                            }
                            else
                            {
                                break;
                            }
                        }
                        for (int i = x - 1; i >= 0; i--)
                        {
                            var downBlock = Manager.Instance.gameobjectGrid[i, y, z];
                            if (Manager.Instance.ColorGrid[i, y, z] == "blue")
                            {
                                xEksenindekiler.Add(downBlock);
                            }
                            else
                            {
                                break;
                            }
                        }
                        for (int i = y + 1; i <= Manager.GridSizeY; i++)
                        {
                            var upBlock = Manager.Instance.gameobjectGrid[x, i, z];
                            if (Manager.Instance.ColorGrid[x, i, z] == "blue")
                            {
                                yEksenindekiler.Add(upBlock);
                            }
                            else
                            {
                                break;
                            }
                        }
                        for (int i = y - 1; i >= 0; i--)
                        {
                            var downBlock = Manager.Instance.gameobjectGrid[x, i, z];
                            if (Manager.Instance.ColorGrid[x, i, z] == "blue")
                            {
                                yEksenindekiler.Add(downBlock);
                            }
                            else
                            {
                                break;
                            }
                        }
                        for (int i = z + 1; i <= Manager.GridSizeZ; i++)
                        {
                            var frontBlock = Manager.Instance.gameobjectGrid[x, y, i];
                            if (Manager.Instance.ColorGrid[x, y, i] == "blue")
                            {
                                zEksenindekiler.Add(frontBlock);
                            }
                            else
                            {
                                break;
                            }
                        }
                        for (int i = z - 1; i >= 0; i--)
                        {
                            var behindBlock = Manager.Instance.gameobjectGrid[x, y, i];
                            if (Manager.Instance.ColorGrid[x, y, i] == "blue")
                            {
                                zEksenindekiler.Add(behindBlock);
                            }
                            else
                            {
                                break;
                            }

                        }
                        if (xEksenindekiler.Count >= 3)
                        {
                            xEksenindekiler.Add(piece.gameObject);
                            foreach (var item in xEksenindekiler)
                            {
                                ScoreScript.scoreValue += ScoreScript.perscore;
                                GameObject.Destroy(item.gameObject);
                                var j = Mathf.RoundToInt(item.transform.position.x);
                                var k = Mathf.RoundToInt(item.transform.position.y);
                                var l = Mathf.RoundToInt(item.transform.position.z);

                                Manager.Instance.ColorGrid[j, k, l] = "";
                                Manager.Instance.Grid[j, k, l] = false;

                            }
                            xEksenindekiler.Clear();
                        }
                        if (yEksenindekiler.Count >= 3)
                        {
                            yEksenindekiler.Add(piece.gameObject);
                            foreach (var item in yEksenindekiler)
                            {
                                ScoreScript.scoreValue += ScoreScript.perscore;
                                GameObject.Destroy(item.gameObject);
                                var j = Mathf.RoundToInt(item.transform.position.x);
                                var k = Mathf.RoundToInt(item.transform.position.y);
                                var l = Mathf.RoundToInt(item.transform.position.z);

                                Manager.Instance.ColorGrid[j, k, l] = "";
                                Manager.Instance.Grid[j, k, l] = false;

                            }
                            yEksenindekiler.Clear();
                        }
                        if (zEksenindekiler.Count >= 3)
                        {
                            zEksenindekiler.Add(piece.gameObject);
                            foreach (var item in zEksenindekiler)
                            {
                                ScoreScript.scoreValue += ScoreScript.perscore;
                                GameObject.Destroy(item.gameObject);
                                var j = Mathf.RoundToInt(item.transform.position.x);
                                var k = Mathf.RoundToInt(item.transform.position.y);
                                var l = Mathf.RoundToInt(item.transform.position.z);

                                Manager.Instance.ColorGrid[j, k, l] = "";
                                Manager.Instance.Grid[j, k, l] = false;

                            }
                            zEksenindekiler.Clear();
                        }
                        xEksenindekiler.Clear();
                        yEksenindekiler.Clear();
                        zEksenindekiler.Clear();

                    }
                    



                }
                Manager.Instance.Spawn();
                break;
            }
        }
    }

    private List<Vector3> GetPreviewPosition()
    {
        var result = new List<Vector3>();
        foreach(var piece in listPiece)
        {
            var position = piece.position;
            
            position.y--;
            result.Add(position);
        }
        return result;
    }

    private void Move()
    {
        var position = transform.position;
        position.y--;
        transform.position = position;
    }
    /*public void MoveXZ()
    {
        
        if (transform.position.x < 4)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {

                transform.position += new Vector3(1, 0, 0);
                
                //transform.position = new Vector3(transform.position.x + 1, transform.position.y,transform.position.z);              
            }
        }

        if (transform.position.x > -4)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.position += new Vector3(-1, 0, 0);
                //transform.position = new Vector3(transform.position.x - 1, transform.position.y,transform.position.z);
            }
        }
        if (transform.position.z < 4)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                transform.position += new Vector3(0, 0, +1);
                //transform.position = new Vector3(transform.position.x , transform.position.y, transform.position.z+1);
            }
        }
        if (transform.position.z > -4)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                transform.position += new Vector3(0, 0, -1);
                
                //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1 );
            }
        }

    }*/
    /*private void OnTriggerEnter(Collider collison)
    {
        placed = true;
       
    }*/
}
