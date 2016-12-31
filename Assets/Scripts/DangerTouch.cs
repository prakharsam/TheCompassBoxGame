using UnityEngine;
using System.Collections;


public class DangerTouch : MonoBehaviour {


	void OnTriggerEnter(Collider collusion) {
		if (collusion.gameObject.tag == "Player")
			GameManager.gm.lose ();

        ObstacleMovement[] erasers = GameObject.Find("Erasers").GetComponentsInChildren<ObstacleMovement>();
        foreach(ObstacleMovement eraser in erasers)
        {
            eraser.Stop();
        }

	}

}
