using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour {
    public int healthCounter = 5;
    public float heartX = -22f;
    public float heartY = 3f;
    public GameObject heart;
    [HideInInspector] public Vector3 heartSpot;
    
    // Use this for initialization
    void Start () {
        GameObject clone = Instantiate(heart, transform.position, transform.rotation) as GameObject;
    }
	
	// Update is called once per frame
	void Update () {
        
        /*
        float x = transform.position.x;
        float y = transform.position.y;
        heartSpot = new Vector3(x, y);

        float heartWidth = 84f;
        heartSpot = new Vector3(heartX, heartY);
            //float x = heartX + (heartWidth * i);
            heartSpot = new Vector3(x, heartY);
            */
        GameObject clone = Instantiate(heart, transform.position, transform.rotation) as GameObject;

    }
    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), ("Health: "+ healthCounter));
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "evil")
        {
            healthCounter--;
        }

    }
}
