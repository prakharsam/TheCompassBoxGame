using UnityEngine;
using System.Collections;

//script to spawn the enemies
//this script is attached to the parent of the enemy gameobject

public class CollectSpawn : MonoBehaviour {

	public float secondsBetweenSpawning = 1.0f;		//time between the spawn of 2 enemies

	public GameObject[] objectsToSpawn;	//the objects to be spawned are stored in this array given by us.

	private float nextSpawnTime;	//the time when the next spawing will happen

	private float xNoiseCoord;	   //xNoiseCoord is the primary paramter used to generate a 1D noise
	private float yNoiseCoord;     //yNoiseCoord will serve as the random parameter to yield new paths during each run

	// Use this for initialization
	void Start () {
		nextSpawnTime = Time.time + secondsBetweenSpawning;	//assigning the next spawing time for the next enemy

		xNoiseCoord = Random.Range (0, 1000); //Random offset per run
		yNoiseCoord = Random.Range (0, 1000); //Random y-parameter per run

	}

	// Update is called once per frame
	void Update () {

		if (GameManager.gm) {
			//if the GameManager is in the state Lose, the spawning will stop as the player is dead
			if (GameManager.gm.gamestate == GameManager.GameState.Lose)
				return;
		}

		//if time is greater or equal to the next spawn time, the enemy will spawn
		if (Time.time >= nextSpawnTime) {
			Spawn ();
			nextSpawnTime = Time.time + secondsBetweenSpawning;		//assigning the next spawing time for the next enemy
		}

	}

	//the function to spawn the enemies
	void Spawn(){

		//Mathf.PerlinNoise returns in [0,1] in a random but coherent manner, multiply by 6f to get in range [0,6) (
		//Then, clamp with 5f again just to be sure since Unity Reference says this function *may* return values slightly above 1.0f
		//This lane is the path for the player
		//Range : {0, 1, 2, 3, 4, 5} for the six lanes
		int path_lane = (int) Mathf.Clamp(Mathf.PerlinNoise(xNoiseCoord, yNoiseCoord) * 10f, 0f, 10f);
		Debug.Log (path_lane.ToString ());
		// Debug.Log ((Mathf.PerlinNoise (xNoiseCoord, yNoiseCoord)).ToString ());

		// TEMP: Simply spawn erasers in the path, actual generation should literally do the opposite
		int objectIndex = Random.Range (0, objectsToSpawn.Length);
		Vector3 spawnPosition;

		spawnPosition.x = path_lane - 10f / 2f;
		spawnPosition.y = 0.25f + objectsToSpawn[objectIndex].GetComponent<Renderer>().bounds.size.y / 2; //height(Land) / 2 + height(Eraser) / 2
		spawnPosition.z = 50f;  //Land length / 2
		Quaternion rotation = objectsToSpawn[objectIndex].GetComponent<Transform>().rotation;
		GameObject spawnedObject = Instantiate (objectsToSpawn [objectIndex], spawnPosition, rotation) as GameObject;
		spawnedObject.transform.parent = gameObject.transform;
		spawnedObject.GetComponent<ObstacleMovement> ();

		//Increment x coord for the next spawn
		xNoiseCoord += (GameManager.gm.obstacleSpeed * secondsBetweenSpawning) / 11f;

	}
}
