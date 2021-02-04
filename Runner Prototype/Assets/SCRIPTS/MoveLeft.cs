using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 0f;
    void Start()
    {
    }

    void Update()
    {
             transform.position += Vector3.left * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collision2D other) {
         if(other.gameObject.CompareTag("Bark")){
             
            Destroy(this);
        }
    }

}
