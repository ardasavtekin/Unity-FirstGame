using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RCloudScript : MonoBehaviour
{
    private float _speed = 3;
    private float _endPosZ;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void StartFloating(float speed, float endPosZ)
    {
        _speed = speed;
        _endPosZ = endPosZ;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * (Time.deltaTime * _speed));
        if (transform.position.z < _endPosZ)
        {
            Destroy(gameObject);
        }
    }
}
