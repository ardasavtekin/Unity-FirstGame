using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RCloudGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] clouds;
    [SerializeField] GameObject endPoint;
    [SerializeField] float spawnInterval;
    
    Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        Invoke("AttemptSpawn", spawnInterval);
    }

    // Update is called once per frame
    void SpawnCloud()
    {
        int randomIndex = Random.Range(0, 3);
        GameObject cloud = Instantiate(clouds[randomIndex]);

        startPos.y = Random.Range(20f, 27f);
        cloud.transform.position = startPos;

        float scale = Random.Range(2f, 5f);
        cloud.transform.localScale = new Vector2(scale, scale);

        float speed = Random.Range(1f, 3f);
        cloud.GetComponent<CloudScript>().StartFloating(speed, endPoint.transform.position.x);


    }
    void AttemptSpawn()
    {
        SpawnCloud();
        Invoke("AttemptSpawn", spawnInterval);
    }
}
