using UnityEngine;
using System.Collections;

//script to spawn the enemies
//this script is attached to the parent of the enemy gameobject

public class ObstacleSpawn : MonoBehaviour {

	public float secondsBetweenSpawning = 4.0f;		//time between the spawn of 2 enemies

	//the variables below is the min and max coordinates (x,y,z) where the enemies will spawn 
	public float xMinRange = 0f;
	public float xMaxRange = 0f;
	public float yMinRange = 0f;
	public float yMaxRange = 0f;
	public float zMinRange = 0f;
	public float zMaxRange = 0f;

	public GameObject[] objectsToSpawn;	//the objects to be spawned are stored in this array given by us.

	private float nextSpawnTime;	//the time when the next spawing will happen

	// Use this for initialization
	void Start () {
		nextSpawnTime = Time.time + secondsBetweenSpawning;	//assigning the next spawing time for the next enemy
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

		Vector3 spawnPosition;	//(x,y,z) position of where the enemy will be spawn

		//generating random (x,y,z) coordinates from the min and max values assigned
		spawnPosition.x = Random.Range (xMinRange, xMaxRange);
		spawnPosition.y = Random.Range (yMinRange, yMaxRange);
		spawnPosition.z = Random.Range (zMinRange, zMaxRange);

		int objectIndex = Random.Range (0, objectsToSpawn.Length);	//chosing a random index from the array where objects to be spawn are stored

		GameObject spawnedObject = Instantiate (objectsToSpawn [objectIndex], spawnPosition, transform.rotation)as GameObject;	//creating/cloning the gameObject by cloning objectsToSpawn[] in the position spawnPosition and rotation transform.rotation.

		spawnedObject.transform.parent = gameObject.transform;	//this is used so that the enemies are created as a child of Erasers to look neat

	}
}
