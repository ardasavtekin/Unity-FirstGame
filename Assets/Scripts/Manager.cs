using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    
    public static Manager Instance { get; private set; }
    public BlockController Current { get; set; }

    public Material material1;
    public Material material2;
    public Material material3;
    public Material material4;

    public List<GameObject> ListHistory;

    public List<GameObject> yFalling;

    public const int GridSizeX = 9;
    public const int GridSizeY = 35;
    public const int GridSizeZ = 9;
    
    public bool[, , ] Grid = new bool[GridSizeX,GridSizeY,GridSizeZ];
    

    public string[,,] ColorGrid = new string[GridSizeX + 1, GridSizeY, GridSizeZ + 1];
    public GameObject[,,] gameobjectGrid = new GameObject[GridSizeX + 1, GridSizeY, GridSizeZ + 1];

    private GameObject[,,] previewDisplay = new GameObject[GridSizeX, GridSizeY, GridSizeZ];

    [SerializeField, Range(.1f, 1f)] private float gameSpeed = 0.7f;

    [SerializeField] public List<BlockController> listPrefabs;

    
    public float GameSpeed => gameSpeed;

    
    public bool IsOpenTest;
    
    [SerializeField] GameObject displayDataPrefabs;

    private void Start()
    {
        /*var redposition = redBlock.transform.position;
        var blueposition = blueBlock.transform.position;
        var greenposition = greenBlock.transform.position;
        var yellowposition = yellowBlock.transform.position;*/
        
        Spawn();
    }
    private void Awake()
    {
        Instance = this;
        if (IsOpenTest)
        {
            for( int i = 0; i<GridSizeX; i++)
            {
                for(int j=0; j<GridSizeY; j++)
                {
                    for( int k=0; k<GridSizeZ; k++)
                    {
                        var sprite = Instantiate(displayDataPrefabs);
                        sprite.transform.position = new Vector3(i, j, k);
                        previewDisplay[i, j, k] = sprite;
                    }
                }
            }
        }

    }

    
    public bool IsInside(List<Vector3> listCoordinate)
    {
        foreach(var coordinate in listCoordinate)
        {
            int x = Mathf.RoundToInt(coordinate.x);
            int y = Mathf.RoundToInt(coordinate.y);
            int z = Mathf.RoundToInt(coordinate.z);

            if (x < 0 || x >GridSizeX)
            {
                //Debug.Log("x");
                return false;
            }
            if (z < 0 || z > GridSizeZ)
            {
                //Debug.Log("z");
                return false;
            }
            if(y <1.5f)
            {
                //Debug.Log("y");
                return false;
            }
            if (Grid[x, y, z ] )
            {
                //Debug.Log("xyz");
                return false;
            }
        }
        return true;
    }
    public void Spawn()
    {
        
        
        var index = Random.Range(0, listPrefabs.Count);
        var blockController = listPrefabs[index];
       
        //Instantiate(blockController);

        var newBlock = Instantiate(blockController);
        
        Current = newBlock;
    }
   
   
}
