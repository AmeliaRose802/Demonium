using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {
    public Rigidbody2D rb;
    public float jumpHeight = 365f;
    //public float moveForce = 365f;
    public float moveSpeed = 10;
    public int jumpsAllowed = 2;
    //private bool grounded = true;
    [HideInInspector] public int jumpCount = 0;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        float amountToMove = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;

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
        /*
        if (Input.GetButton("RIGHT"))
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)){
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
        if(Input.GetKeyDown(KeyCode.RightArrow)){
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }*/


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