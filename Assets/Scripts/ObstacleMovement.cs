using UnityEngine;
using System.Collections;


//movement of the enemy(erasers)
//script attached to the enemy
public class ObstacleMovement : MonoBehaviour {


	private float speed = GameManager.gm.obstacleSpeed;	//speed of enemy

	public Transform target;	//position of target(player)

	// Use this for initialization
	void Start () {

		//if target is not assigned, it finds the gameobject with tag "Player" anda assigns it
		if (target == null) {

			if (GameObject.FindWithTag ("Player") != null)
				target = GameObject.FindWithTag ("Player").GetComponent<Transform> ();

		}

	}

	// Update is called once per frame
	void Update () {

		//if there is no gameobject with tag "Player" nothing happens 
		if (target != null) {
			
			transform.position -= transform.forward * speed * Time.deltaTime;
		}
		

	}


}
