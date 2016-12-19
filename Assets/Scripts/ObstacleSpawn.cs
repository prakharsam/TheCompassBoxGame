using UnityEngine;
using System.Collections;

public class ObstacleSpawn : MonoBehaviour {

	public float secondsBetweenSpawning=4.0f;
	public float xMinRange = 0f;
	public float xMaxRange = 0f;
	public float yMinRange = 0f;
	public float yMaxRange = 0f;
	public float zMinRange = 0f;
	public float zMaxRange = 0f;
	public GameObject[] objectsToSpawn;

	private float nextSpawnTime;

	// Use this for initialization
	void Start () {
		nextSpawnTime = Time.time + secondsBetweenSpawning;	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (GameManager.gm) {
			if (GameManager.gm.gamestate == GameManager.GameState.Lose)
				return;
		}

		if (Time.time >= nextSpawnTime) {
			Spawn ();
			nextSpawnTime = Time.time + secondsBetweenSpawning;
		}
	
	}

	void Spawn(){

		Vector3 spawnPosition;

		spawnPosition.x = Random.Range (xMinRange, xMaxRange);
		spawnPosition.y = Random.Range (yMinRange, yMaxRange);
		spawnPosition.z = Random.Range (zMinRange, zMaxRange);

		int objectIndex = Random.Range (0, objectsToSpawn.Length);

		GameObject spawnedObject = Instantiate (objectsToSpawn [objectIndex], spawnPosition, transform.rotation)as GameObject;

		spawnedObject.transform.parent = gameObject.transform;
	}
}
