using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   [SerializeField] float moveSpeed;

    Rigidbody2D myRigidbody;
    BoxCollider2D myBodyCollider;
   

     void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(myRigidbody.velocity.x)), transform.localScale.y);
        if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            Destroy(gameObject);

        }
    }
    private bool IsfacingRight() { return transform.localScale.x > Mathf.Epsilon; }
  
    
    void Update()
    {
        if (IsfacingRight())
        {
            myRigidbody.velocity = new Vector2(-moveSpeed, 0f);
        }
        else
        {
            myRigidbody.velocity = new Vector2(moveSpeed, 0f);
        }
        
    }
}
