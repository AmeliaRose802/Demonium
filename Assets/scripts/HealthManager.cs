using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class HealthManager : MonoBehaviour
{

    //Declare varibles
    public int healthCounter = 5;
    public float heartX = -22f;
    public float heartY = 3f;
    public GameObject heart;
    [HideInInspector] public Vector3 heartSpot;
    public float heartWidth = 1000f;
    public GameObject canvas;
    public Vector2 spawnPoint;
    public float threshold = -150f;

    Vector2 innitalPosition;

    //Holds the heart game objects so they can be messed with
    public List<GameObject> hearts;


    // Use this for initialization
    void Start()
    {
        //Draw a full amount of health
        drawHearts();
        innitalPosition = gameObject.transform.position;
    }

    private void Update()
    {
        if(threshold > gameObject.transform.position.y)
        {
            takeHealth();
            healthCounter--;
            gameObject.transform.position = innitalPosition;
            Debug.Log("Threshold Exceeded");
            Debug.Log(gameObject.transform.position.y);
            Debug.Log(threshold);


            //If player is out of health then kill player and reload scene
            if (healthCounter <= 0)
            {
                Destroy(this.gameObject);
                // get the current scene name 
                string sceneName = SceneManager.GetActiveScene().name;

                // load the same scene
                SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
            }
        }

    }

    //Draw the health number, probly going to take this out later
    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), ("Health: " + healthCounter));
    }



    //Checks for collisons with enimy and manages health
    void OnCollisionEnter2D(Collision2D coll)
    {
        //Check if player collided with enimy
        if (coll.gameObject.tag == "evil")
        {
            //Remove a heart
            takeHealth();
            //Decrement health counter
            healthCounter--;

            //If player is out of health then kill player and reload scene
            if (healthCounter <= 0)
            {
                Destroy(this.gameObject);
                // get the current scene name 
                string sceneName = SceneManager.GetActiveScene().name;

                // load the same scene
                SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
            }
        }

    }

    //Draws the hearts and insert into array
    void drawHearts()
    {

        for (int i = 0; i < healthCounter; i++)
        {
            //Calcuate positions for hearts

            //Innital positions plus i*width modifier to offset next heart
            float x = heartX + (heartWidth * i);
            float y = heartY;
            heartSpot = new Vector3(x, y);

            //Make the heart 
            GameObject clone = Instantiate(heart, heartSpot, transform.rotation, canvas.transform) as GameObject;

            //Add the heart to the list
            hearts.Add(clone);
        }
    }

    //Take away a heart from player 
    void takeHealth()
    {
        //Make sure there is still health
        if (healthCounter > 0)
        {
            //Kill the last heart in the array
            Destroy(hearts[healthCounter - 1]);
        }


    }

    void takeHealth(int health)
    {
        healthCounter=healthCounter-health;
        takeHealth();
    }
}
