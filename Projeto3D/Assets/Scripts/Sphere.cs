using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sphere : MonoBehaviour
{
    public bool onGround;
    public float speed = 6f;
    private Rigidbody rb;

    private bool isInArea = false;

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
            speed = 6f;
            onGround = true;
        }

        if(other.gameObject.CompareTag("Mud")){
            speed = 3f;
            onGround = true;
        }

        if(other.collider.tag == "Enemy"){
            Replay();
        }

        if(other.collider.tag == "End"){
            Replay();
        }
    }

    private void OnTriggerEnter(Collider other) {
        isInArea = true;
        if(other.gameObject.CompareTag("Coins")){
            Destroy(other.gameObject);
            FindObjectOfType<AudioManager>().Play("Coin");
        }
    }
    
}
