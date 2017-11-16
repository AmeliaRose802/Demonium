using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class endState : MonoBehaviour {
    public int health = 5;
    public GameObject canvas;
    public GameObject endLevel;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(health <= 0)
        {
            Destroy(this.gameObject);
            Vector3 winSpot = new Vector3(-40, -5);
            SceneManager.LoadScene("winScene", LoadSceneMode.Single);
           // GameObject clone = Instantiate(endLevel, winSpot, transform.rotation, canvas.transform) as GameObject;

            /*
            // get the current scene name 
            string sceneName = SceneManager.GetActiveScene().name;

            // load the same scene
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
            */
        }
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "bulletFire" || coll.gameObject.tag == "bulletIce")
        {
            health--;
        }
    }


}
