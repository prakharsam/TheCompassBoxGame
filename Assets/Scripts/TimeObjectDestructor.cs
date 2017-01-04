using UnityEngine;
using System.Collections;

//this scriptis used on the gameobject where you want to destroy after certain time to reduce memory 

public class TimeObjectDestructor : MonoBehaviour {

	public float timeOut = 20.0f; //period of time alive in the game

	// Use this for initialization
	void Start () {
		Invoke ("DestroyNow", timeOut);	//invoking funtion DestroyNow after timeOut seconds
	}
	

	void DestroyNow(){

		/*when the player is not dead and the gameobject time is out,the object gets destroyed.
		we use this condition since it will look odd if the game objects (eg: erasers) disappear when the player dies*/
		if (GameManager.gm.gamestate != GameManager.GameState.Lose)	 
			Destroy (gameObject);	//this funtion destroys the gameobject
	}
}
