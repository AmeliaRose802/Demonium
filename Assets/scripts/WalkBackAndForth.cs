using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkBackAndForth : MonoBehaviour {
    public float speed = 10f;
    public float maxRange = 10f;
    [HideInInspector] public float max;
    [HideInInspector] public float min;
    // Use this for initialization
    void Start () {
        speed = speed * -1;
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        Vector3 flip = gameObject.transform.localScale;
        flip.x *= -1;
        max = gameObject.transform.position.x + maxRange;
        min = gameObject.transform.position.x - maxRange;
    }
	
	// Update is called once per frame
	void Update () {
        if(gameObject.transform.position.x > min && gameObject.transform.position.x < max) { 
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }else{
            speed = speed*-1;
            transform.Translate(Vector2.right* speed * Time.deltaTime);
            Vector3 flip = gameObject.transform.localScale;
            flip.x *= -1;
            gameObject.transform.localScale = flip;
        }
}

    void OnCollisionEnter2D(Collision2D coll)
    {
        speed = speed * -1;
        Vector3 flip = gameObject.transform.localScale;
        flip.x *= -1;
        gameObject.transform.localScale = flip;
    }
}

