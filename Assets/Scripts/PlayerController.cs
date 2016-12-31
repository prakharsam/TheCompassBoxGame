using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed   = 3.0f;
	public float gravity = 9.8f;

	private CharacterController myController;

	// Use this for initialization
	void Start () {
		myController = gameObject.GetComponent<CharacterController> ();

	}

	// Update is called once per frame
	void Update () {


		Vector3 movement = Input.GetAxis ("Horizontal") * Vector3.right * speed * Time.deltaTime;
		movement.y -= gravity * Time.deltaTime;

		myController.Move (movement);

	}
}
