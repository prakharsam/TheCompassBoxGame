using UnityEngine;
using System.Collections;

//this scriptis used on the gameobject where you want to destroy after certain time to reduce memory 

public class TimeObjectDestructor : MonoBehaviour {


	private float timeOut = 80.0f/GameManager.gm.obstacleSpeed ; //period of time alive in the game.
	//70 is the floor length. so it gets destroyed after covering 80 distance 

	// Use this for initialization
	void Start () {
		Invoke ("DestroyNow", timeOut);	//invoking funtion DestroyNow after timeOut seconds
	}

	void DestroyNow(){

		/*when the player is not dead and the gameobject time is out,the object gets destroyed.
		we use this condition since it will look odd if the game objects (eg: erasers) disappear when the player dies*/
		if (GameManager.gm.gamestate != GameManager.GameState.Lose)	 
			Destroy (this.gameObject);	//this funtion destroys the gameobject
	}
}
