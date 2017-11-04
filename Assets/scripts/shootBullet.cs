using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootBullet : MonoBehaviour {
    public GameObject projectile;
    public float shootSpeed = 10f;
    public float bulletXModifier = .7f;
    public float bulletYModifier = .5f;
    [HideInInspector] public Vector3 spawnSpot;
    // Update is called once per frame
    void Update () {
        float x = transform.position.x + bulletXModifier;
        float y = (transform.position.y + bulletYModifier);
        spawnSpot = new Vector3(x, y);
        //spawnSpot = new Vector3(0, 0);
        // Ctrl was pressed, launch a projectile

        if (Input.GetButtonDown("Fire1"))
        {
            x = transform.position.x - bulletXModifier;
            y = (transform.position.y - bulletYModifier);
            spawnSpot = new Vector3(x, y);

            // Instantiate the projectile at the position and rotation of this transform
            GameObject clone = Instantiate(projectile, spawnSpot, transform.rotation) as GameObject;
            clone.GetComponent<Rigidbody2D>().velocity = new Vector2(-shootSpeed, GetComponent<Rigidbody2D>().velocity.y);
            //clone.GetComponent<Rigidbody2D>().AddForce(transform.right * 199);

            Vector3 newScale = clone.transform.localScale;
            newScale.x *= -1;
            clone.transform.localScale = newScale;

        }

        
        if (Input.GetButtonDown("Fire2"))
        { 

            // Instantiate the projectile at the position and rotation of this transform
            GameObject clone = Instantiate(projectile, spawnSpot, transform.rotation) as GameObject;
            clone.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed, GetComponent<Rigidbody2D>().velocity.y);
            //clone.GetComponent<Rigidbody2D>().AddForce(transform.right * 199);

        }

        
       

    }
}
