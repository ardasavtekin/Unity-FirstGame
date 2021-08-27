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

        if (ScoreScript.scoreValue < 100)
        {
            index = Random.Range(0, randomMaterial.Length -3);
        }
        if (ScoreScript.scoreValue > 100 && ScoreScript.scoreValue < 200)
        {
            index = Random.Range(0, randomMaterial.Length - 2);
        }
        if (ScoreScript.scoreValue > 200 && ScoreScript.scoreValue < 300)
        {
            index = Random.Range(0, randomMaterial.Length - 1);
        }
        if (ScoreScript.scoreValue > 300)
        {
            index = Random.Range(0, randomMaterial.Length );
        }
        Debug.Log("" + ScoreScript.scoreValue);
       
        //index = Random.Range(0, randomMaterial.Length);
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
