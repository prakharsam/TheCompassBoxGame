using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager gm;
	public GameObject player;
	public enum GameState
	{
		Start,
		Playing,
		Lose
	};

	public GameState gamestate = GameState.Playing;
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
			
			player.transform.DetachChildren();
			player.SetActive (false);
			gameOverCanvas.SetActive (true);
			break;
			
		}
	
	}

	public void lose(){
		gm.gamestate = GameState.Lose;
	}
}
