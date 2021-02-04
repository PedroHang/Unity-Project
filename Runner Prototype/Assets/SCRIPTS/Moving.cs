using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Moving : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 4.5f;
    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    public float jumpForce;
    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;

    private bool pressedKey;

    private bool isInArea = false;

    private Animator anim;

    GameObject superBark;

    void Awake(){
        superBark = GameObject.Find("Bark");
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

   
 

// Update is called once per frame
   void Update(){
       isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

       if(isGrounded == true && Input.GetKeyDown(KeyCode.Space)){
           anim.SetBool("isJumping", true);
           isJumping = true;
           jumpTimeCounter = jumpTime;
           rb.velocity = Vector2.up * jumpForce;
           FindObjectOfType<AudioManager>().Play("Jump");
           anim.Play("Jumping");
       }

       if(Input.GetKey(KeyCode.Space) && isJumping == true){
           rb.velocity = Vector2.up * jumpForce;

           if(jumpTimeCounter > 0){
               rb.velocity = Vector2.up * jumpForce;
               jumpTimeCounter -= Time.deltaTime;
           } else{
               isJumping = false;
           }
       }

       if(Input.GetKeyUp(KeyCode.Space)){
           isJumping = false;
           anim.SetBool("isJumping", false);
       }




       transform.position += Vector3.right * speed * Time.deltaTime;      // MOVER

       if(isInArea == true){
           checkClick();  // CHECK
       }

       if(Input.GetKey(KeyCode.E)){
           superBark.SetActive(true);
       } else{
           superBark.SetActive(false);
       }
   }

    public void checkClick(){
            if(Input.GetKey(KeyCode.E)){
                pressedKey = true;
            } else{
            pressedKey = false;
        }
    } 
     public void Replay()
    {
        SceneManager.LoadScene(0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Enemy"){
            FindObjectOfType<AudioManager>().Play("Death");
            Replay();
        }

        if(collision.collider.tag == "Wall" || collision.collider.tag == "Breakable"){
            speed = 0f;
            anim.SetBool("isIdle", true);
        } else{
            speed = 4.5f;
            anim.SetBool("isIdle", false);
        }

        if(collision.collider.tag == "Slope"){
            anim.SetBool("isJumping", true);
        } else{
            anim.SetBool("isJumping", false);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        isInArea = true;
        if(other.gameObject.CompareTag("Coins")){
            Destroy(other.gameObject);
            FindObjectOfType<AudioManager>().Play("Coin");
        }

        if(other.gameObject.CompareTag("Breakable")){
            if(pressedKey == true){
                Destroy(other.gameObject);
            }
        }
    }
    
}