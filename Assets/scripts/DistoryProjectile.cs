using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistoryProjectile : MonoBehaviour {

    private void Start()
    {
        //set a maximum lifetime for object, otherwise bullets fall off edges and eat resources forever
        Destroy(gameObject, 3);
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag != "Player")
        Destroy(this.gameObject);

    }


}

