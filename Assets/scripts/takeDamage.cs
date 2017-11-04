using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takeDamage : MonoBehaviour {
    public Rigidbody2D rb;
    public int health = 5;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-10, rb.velocity.y);
    }
	
	// Update is called once per frame
	void Update () {
        //Ment to make demon move twards you, but dosent work
        rb.velocity = new Vector2(-10, rb.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "bullet")
        {
            health--;
            if (health <= 0)
            {
                Destroy(this.gameObject);
            }
        }

    }

}
