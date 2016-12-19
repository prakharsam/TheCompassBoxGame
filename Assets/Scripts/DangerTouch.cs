using UnityEngine;
using System.Collections;


public class DangerTouch : MonoBehaviour {


	void OnTriggerEnter(Collider collusion) {
		if (collusion.gameObject.tag == "Player")
			GameManager.gm.lose ();

	}

}
