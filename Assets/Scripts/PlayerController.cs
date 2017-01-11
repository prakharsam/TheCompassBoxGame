using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float speed = 20.0f;					//speed of player
	public float jumpForce = 250.0f;			//force applied to the player when jump is initiated

	private Rigidbody rb; 						//a component in unity which enables us to use physics property to the player

	private bool jump = false;
	private bool isGrounded = true;

	private void Start(){
		rb = GetComponent<Rigidbody> ();	//getting the rigidbody component from the player

	}

	//called every framerate
	private void Update(){
		//when jump button is presesd, checked if it's in midair and grounded
		if (Input.GetButtonDown ("Jump") ) {
			if (!jump && isGrounded) {
				jump = true;
			}
		}

	}

	//function is called every fixed framerate. Used when we deal with rigidbody.
	private void FixedUpdate(){
		
		Vector3 force = new Vector3();			//(x,y,z) coordinates for the player movement		
		force.x = Input.GetAxis ("Horizontal");		//when left/right button is pressed, it gives value to the x value
		rb.AddForce (force * speed);				//adds force to the player with speed to move

		//for jumping
		if (jump) {									
			force.y = jumpForce;				//jumpForce value is added to the y axis				
			rb.AddForce (force);				
			isGrounded = false;
			jump = false;
		}
	}

	//functon called as soon as the player collide with the floor 
	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag == "Floor") {
			isGrounded = true;
		}
	}



}
