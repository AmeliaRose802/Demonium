
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {
    public Rigidbody2D rb;
    public float jumpHeight = 365f;
    //public float moveForce = 365f;
    public float moveSpeed = 10;
    public int jumpsAllowed = 2;
    [HideInInspector] public bool facingLeft = false;
    //private bool grounded = true;
    [HideInInspector] public int jumpCount = 0;
    [HideInInspector] public static bool playerFacingLeft = false;
    Animator anim;


    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        float amountToMove = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;

        
   
        if ((amountToMove < 0))
        {
            anim.SetBool("walkLeft", true);
            
            /*
            Vector3 flip = gameObject.transform.localScale;
            flip.x *= -1;
            gameObject.transform.localScale = flip;
            playerFacingLeft = true;
            */
        }
        else if(amountToMove > 0)
        {
            anim.SetBool("isWalking", true);
            /*
            Vector3 flip = gameObject.transform.localScale;
            flip.x *= -1;
            gameObject.transform.localScale = flip;
            playerFacingLeft = false;
            */
        }
        else
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("walkLeft", false);
        }

        transform.Translate(Vector3.right * amountToMove);

        //grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //You can jump in air twice before you must return to ground
            //Currently broken so you can only jump twice
            if (jumpCount < (jumpsAllowed-1))
            {
                rb.AddForce(new Vector2(0f, jumpHeight));
                jumpCount++;
            }
        }


    }

    //This should dect collisoons with ground and reset jump count to prevent double jumping
    void OnCollisionEnter2D(Collision2D coll)
        {
        if(coll.gameObject.tag == "platform")
        {
            jumpCount=0;
        }
        
    }
}