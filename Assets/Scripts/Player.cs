using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Player : MonoBehaviour
{
   // CONFIGS
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float climbSpeed = 5f;
    [SerializeField] Vector2 deathKick = new Vector2(15f, 15f);
    [SerializeField] Vector2 deathKick2 = new Vector2(0f, 15f);
    [SerializeField] AudioClip runningClip;
    [SerializeField] AudioClip attackClip;
    [SerializeField] AudioClip jumpClip;
    AudioSource playerAudioSource;
    

    // Health System
    public float Health = 100f;
    public float DamageTaken = 50f;
    public float DamageByFire = 15f;
    public float currentHealth;
    
    

    // State


    // Cache component Refrences
    Vector3 charactorScale;
    float charactorScaleX;
    Animator myanimator;
    BoxCollider2D myBodyCollider2d;
    BoxCollider2D myFeetCollider;
    Rigidbody2D myRigidBody;
    float gravityScaleAtStart;
    bool isAlive;
    Vector2 playerPos;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = Health;
        charactorScale = transform.localScale;
        charactorScaleX = charactorScale.x;
        
        myanimator = GetComponent<Animator>();
        myBodyCollider2d = GetComponent<BoxCollider2D>();
        myFeetCollider = GetComponent<BoxCollider2D>();
        myRigidBody = GetComponent<Rigidbody2D>();
        gravityScaleAtStart = myRigidBody.gravityScale;
        isAlive = true;
        playerAudioSource = GetComponent<AudioSource>();
        playerPos = myRigidBody.transform.position;
        
    }
    
    private void Death()
    {
        if (currentHealth <= 0)
        {

            isAlive = false;
            myanimator.SetTrigger("Death");
            GetComponent<Rigidbody2D>().velocity = deathKick;
            SceneManager.LoadScene("End Menu");
        }
    }
    private void Die()
    {

        if (myBodyCollider2d.IsTouchingLayers(LayerMask.GetMask("Enemy 1")))
        {
            
            
                currentHealth -= DamageTaken;
            Death();
        }
        if (myBodyCollider2d.IsTouchingLayers(LayerMask.GetMask("Enemy 2")))
        {


            currentHealth -= DamageTaken;
            Death();
        }

        if (myBodyCollider2d.IsTouchingLayers(LayerMask.GetMask("Lava")))
        {
            currentHealth = 0;
            Death();
        }
        if (myBodyCollider2d.IsTouchingLayers(LayerMask.GetMask("Fireball")))
        {
            currentHealth -= DamageByFire;
            Death();
        }

    }
    private void Run()
    {

        transform.Translate(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f);
        
        if (Input.GetAxis("Horizontal") < 0)
        {
           
            myanimator.SetBool("Running", true);

            charactorScale.x = -charactorScaleX;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
           
            myanimator.SetBool("Running", true);
            charactorScale.x = charactorScaleX;
        }
        transform.localScale = charactorScale;
        if (Input.GetAxis("Horizontal") == 0)
        {
           
            myanimator.SetBool("Running", false);


        }
    }
    private void Jump()
    {

        if (!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {

            return;

        }

        if (Input.GetButtonDown("Jump"))
        {
            myanimator.SetTrigger("Jump");
            myRigidBody.velocity = new Vector2(0f, jumpSpeed);
           
            


        }
       
    }

    private void ClimbLadder()
    {
        if (!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("ladder")))
        {
            myanimator.SetBool("Climb", false);
            myRigidBody.gravityScale = gravityScaleAtStart;
            return; 
        }
        if (myFeetCollider.IsTouchingLayers(LayerMask.GetMask("ladder")))
        {

            myanimator.SetBool("Climb",true );
            myRigidBody.gravityScale = 0f;

            transform.Translate(0f,Input.GetAxis("Vertical") * climbSpeed * Time.deltaTime, 0f);
            
        }




    }
    
    private void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            myanimator.SetTrigger("Attack");


            
            
        }
    }

    void Update()
    {
        if (!isAlive)
        {
            return;
        }
        Run();
        Die();
        Jump();
        ClimbLadder();
        Attack();
    }
}
















// Update is called once per frame

