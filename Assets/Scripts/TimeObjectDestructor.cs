using UnityEngine;
using System.Collections;

public class TimeObjectDestructor : MonoBehaviour {

	public float timeOut = 20.0f;

	// Use this for initialization
	void Start () {
		Invoke ("DestroyNow", timeOut);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void DestroyNow(){

		if (GameManager.gm.gamestate != GameManager.GameState.Lose)
			Destroy (gameObject);
	}
}
