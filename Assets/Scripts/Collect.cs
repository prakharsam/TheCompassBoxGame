using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour {

	void OnTriggerEnter(Collider collision) {
		if (collision.gameObject.tag == "Player") {
			gameObject.SetActive (false);
		}

	}
}
