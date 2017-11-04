using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reloadOnFallOffScreen : MonoBehaviour {
    public float threshold;
    public Vector2 spawnPoint;
    //public GameObject player;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (this.transform.position.y < threshold){
            this.transform.position = spawnPoint;
        }
	}
}
