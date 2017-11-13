using UnityEngine;
using System.Collections;

public class CamraFollow : MonoBehaviour
{
	public Transform target;
	private Vector2 velocity;
	public float smoothTimeY;
	public float smoothTimeX;

	// Use this for initialization
	void Start()
	{
		//player = GameObject.FindGameObjectsWithTag ("Player");
	}
	void Update(){
        transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);
    }
}
