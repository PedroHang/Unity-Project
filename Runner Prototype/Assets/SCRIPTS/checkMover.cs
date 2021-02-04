using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkMover : MonoBehaviour
{

    public float speed = 2.0f;

    void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }
}
