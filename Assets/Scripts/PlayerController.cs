using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed   = 3.0f;	//speed of player
	public float gravity = 9.8f;	//gravity to affect the player to fall
	public float jumpHeight = 17.0f; //how high the player

	private bool jump = false;		//jump is set to false by default

	/*CharacterController is a class in unity engine that makes the user easily move.
	  you have to add component to the gameobject to use this.*/
	private CharacterController myController;	

	// Use this for initialization
	void Start () {
		
		//getting the value of Character controller component
		myController = gameObject.GetComponent<CharacterController> ();

	}

	// Update is called once per frame
	void Update () {

		//storing (x,y,z) coordinates when inputs are given
		Vector3 movement = Input.GetAxis ("Horizontal") * Vector3.right * speed * Time.deltaTime;

		//when jump key is pressed
		if (Input.GetButtonDown ("Jump")) {
			jump = true;
		}

		if (jump == false) {
			//affect of gravity to the player
			movement.y -= gravity * Time.deltaTime;
		}

		if (jump == true) {
			movement.y += jumpHeight * Time.deltaTime;	//the y axis of the player is increased
			jumpHeight--;								//and the jump height is gradually decreased
			if (jumpHeight == 0) {						//when the jump height is 0,the player is in the ground and jump is set false
				jump = false;
				jumpHeight = 17.0f;						//jump is set to it's previous value for the next
			}
		}

		//this is to move the player using the coordinates movement
		myController.Move (movement);

	}

}
