using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{

    public float speed = 3.0f;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }
}
