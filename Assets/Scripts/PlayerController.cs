using UnityEngine;
using System.Collections;


public class PlayerController : MonoBehaviour {
	
	public float speed = 5;
	public float jumpSpeed = 5;

	private CharacterController player;
	private Vector3 gravity = Vector3.zero;

	void Start(){
		
		player = GetComponent<CharacterController> ();
	
	}

	void Update(){

		Vector3 movement = Input.GetAxis ("Horizontal") * Vector3.right * speed;

		if (player.isGrounded == true && Input.GetButtonDown ("Jump")) {
			gravity = Vector3.zero;
			gravity.y = jumpSpeed;
		} else {
			gravity += Physics.gravity * Time.deltaTime;
		}

		movement += gravity;
		player.Move (movement * Time.deltaTime);

	}

}
