using UnityEngine;
using System.Collections;

//This script is used on gameobjects where players die when touched by it
public class DangerTouch : MonoBehaviour {

	//when a gameobject with tag "Player" collide with the gameobject of this script, it calls the func lose() in GameManager class 
	void OnTriggerEnter(Collider collusion) {
		if (collusion.gameObject.tag == "Player")
			GameManager.gm.lose ();

        //takes the child of Erasers and stop its movement 
		ObstacleMovement[] erasers = GameObject.Find("Erasers").GetComponentsInChildren<ObstacleMovement>();
        foreach(ObstacleMovement eraser in erasers)
        {
            eraser.Stop();
        }

	}

}
