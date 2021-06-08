using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    public bool onGround;
    public float speed = 6f;
    private Rigidbody rb;
    public int MAX_JUMP = 1;
    private int currentJump = 0;

    private bool isInArea = false;
    private bool repulsionOrb = false;
    private bool doubleJump = false;
    private bool boosted = false;
    public TextMeshProUGUI textPowerUp;
    public GameObject gameMenu;
 
    Animator animator;


    void Awake(){
        Time.timeScale = 0;
    }

    void Start()
    {
        onGround = true;
        rb = GetComponent<Rigidbody>();

        animator = GetComponent<Animator>();
        
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

        if(Input.GetKey(KeyCode.E)){
            displayMenu();
        }


        if(onGround || MAX_JUMP > currentJump){

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.position.y > Screen.height / 3)
                {
                    rb.velocity = new Vector3(0f, 6f, 2f);
                    animator.SetBool("isJumping", true);
                    currentJump++;
                    onGround = false;
                }
            }
        }
    }

    public void Replay()
    {
        SceneManager.LoadScene(0);
    }

    public void displayMenu()
    {
        SceneManager.LoadScene(1);
    }

    void OnCollisionEnter(Collision other) {

        // SETTING REPULSION ORB = TRUE

        if(other.gameObject.CompareTag("RepulsionPowerUp")){
            repulsionOrb = true;
            Destroy(other.gameObject);
            Debug.Log("FOI");
            textPowerUp.gameObject.SetActive(true);
            MAX_JUMP = 2;
        }

        // ---------------------------


        // SETTING GROUND

        if(other.gameObject.CompareTag("Ground")){
            speed = 6f;
            onGround = true;
            currentJump = 0;
            animator.SetBool("isJumping", false);
        }

        // ----------------------------


        // SETTING MUD

        if(other.gameObject.CompareTag("Mud")){
            speed = 3f;
            onGround = true;
            animator.SetBool("isJumping", false);
            animator.speed = 0.8f;
        }

        // ----------------------------



        if(other.collider.tag == "Enemy"){
            Replay();
        }

        if(other.collider.tag == "End"){
            gameMenu.gameObject.SetActive(true);
            this.gameObject.GetComponent<TouchMove>().disableMoving();
            Time.timeScale = 0;
        }
    }

    IEnumerator waitSeconds2(){
        yield return new WaitForSeconds(2);          // BOOST FOR 2 SECONDS
        speed = 7f;
    }


    private void OnTriggerEnter(Collider other) {
        isInArea = true;
        if(other.gameObject.CompareTag("Coins")){
            Destroy(other.gameObject);
            FindObjectOfType<AudioManager>().Play("Coin");
        }

        if(other.gameObject.CompareTag("BoostCoin")){
            Destroy(other.gameObject);
            FindObjectOfType<AudioManager>().Play("BoostCoin");
            speed = 10f;
            StartCoroutine(waitSeconds2());

        }
    }
    
}
