using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takeDamage : MonoBehaviour {
    public Rigidbody2D rb;
    public int health = 5;
    public int fireAndIceBonus = 5;
    [HideInInspector] public bool frozen = false;

    Animator anim;
    int blueGuy = Animator.StringToHash("Frozen");
    int normal = Animator.StringToHash("normal");

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-10, rb.velocity.y);
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        //Ment to make demon move twards you, but dosent work
        //rb.velocity = new Vector2(-10, rb.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "bulletFire" || coll.gameObject.tag == "bulletIce")
        {

            health--;
            if (health <= 0)
            {
                Destroy(this.gameObject);
            }

            if(coll.gameObject.tag == "bulletIce")
            {
                anim.SetBool("isFrozen", true);
                frozen = true;
                
            }
            if((coll.gameObject.tag == "bulletFire") && frozen)
            {
                health -= fireAndIceBonus;
                if (health <= 0)
                {
                    Destroy(this.gameObject);
                }
            }
        }

    }

}
