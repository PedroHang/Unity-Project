using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sphere : MonoBehaviour
{
    public bool onGround;
    public float speed = 6f;
    private Rigidbody rb;

    void Start()
    {
        onGround = true;
        rb = GetComponent<Rigidbody>();
        
    }

    void Update()
    {
        transform.position += Vector3.forward * speed * Time.deltaTime;  // MOVING

        
        if(Input.GetKey(KeyCode.A)){
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.D)){
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        if(onGround){
            if(Input.GetButtonDown("Jump")){
                rb.velocity = new Vector3(0f, 7f, 0f);
                onGround = false;
            }
        }
    }

    public void Replay()
    {
        SceneManager.LoadScene(0);
    }

    void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Ground")){
            onGround = true;
        }

        if(other.collider.tag == "Enemy"){
            Replay();
        }
    }
}
