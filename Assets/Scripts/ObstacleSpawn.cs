using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour {

	public float secondsBetweenSpawning = 0.5f;
	public GameObject[] enemies;
	private float nextSpawnTime;
	private Vector3 spawnPosition;

	// Use this for initialization
	void Start () {
		nextSpawnTime = secondsBetweenSpawning + Time.time;
		
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

	void Spawn(){
		
		int objectIndex = Random.Range (0, enemies.Length);


		spawnPosition.x = Random.Range (-4, 4);
		spawnPosition.y = 0.25f + enemies[objectIndex].GetComponent<Renderer>().bounds.size.y / 2; //height(Land) / 2 + height(Eraser) / 2
		spawnPosition.z = 50f;  //Land length / 2
		Quaternion rotation = enemies[objectIndex].GetComponent<Transform>().rotation;
		GameObject spawnedObject = Instantiate (enemies [objectIndex], spawnPosition, rotation) as GameObject;
		spawnedObject.transform.parent = gameObject.transform;
					
	}
}
