using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{

    bool Test = false;
    void Start(){
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Breakable") && Test){
             Destroy(other.gameObject);
        }
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            Test = true;
        }
    }

    
}
