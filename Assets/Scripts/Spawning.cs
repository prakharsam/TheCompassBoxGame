using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawning : MonoBehaviour {

	public float secondsBetweenSpawning = 0.5f;
	public GameObject[] objectToSpawn;
	public float nextSpawnTime;
	public Vector3 spawnPosition;

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

	public abstract void Spawn ();
}
