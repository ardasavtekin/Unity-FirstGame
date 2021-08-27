using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandColor : MonoBehaviour
{
    public Material[] randomMaterial;
    public static int index;
    // Start is called before the first frame update
    void Start()
    {
        index = Random.Range(0, randomMaterial.Length);
        gameObject.GetComponent<Renderer>().material = randomMaterial[index];
        if (index == 0)
        {
            gameObject.name = "red";
        }
        if (index == 1)
        {
            gameObject.name = "green";
        }
        if (index == 2)
        {
            gameObject.name = "yellow";
        }
        if (index == 3)
        {
            gameObject.name = "blue";
        }

    }
    

  
}
