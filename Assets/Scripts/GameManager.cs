using UnityEngine;
using System.Collections;

//this script manages the game of a particular scene

public class GameManager : MonoBehaviour {

	public static GameManager gm;

	public GameObject player;
	public enum GameState
	{
		Playing,
		Menu,
		Lose
	};

	public float obstacleSpeed = 5.0f;

	public GameState gamestate = GameState.Playing;		//gamestate is set to playing by default
	public GameObject gameOverCanvas;


	// Use this for initialization
	void Start () {
		
		if (gm == null)
			gm = gameObject.GetComponent<GameManager> ();
		
		if (player == null)
			player = GameObject.FindWithTag ("Player");
		
		gameOverCanvas.SetActive (false);
	
	}
	
	// Update is called once per frame
	void Update () {
		switch (gamestate) {


		case GameState.Playing:
			break;

		
		case GameState.Lose:
			player.transform.DetachChildren();     //all the gameobjects attached with the player gets detached like camera
			player.SetActive (false);				//player is deactivated
			gameOverCanvas.SetActive (true);		//the gameover canvas is activated
			break;
			
		}
	
	}

	//if the player dies, the gamestate is set to Lose wiht this function
	public void lose(){
		gm.gamestate = GameState.Lose;
	}

}
