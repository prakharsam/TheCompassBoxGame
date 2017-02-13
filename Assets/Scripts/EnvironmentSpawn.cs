using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentSpawn : Spawning {

	public override void Spawn(){

		for (int i = 1; i <= 2; i++) {
			int objectIndex = Random.Range (0, objectToSpawn.Length);
			spawnPosition.x = Mathf.Pow(-1,i) * 6 ;
			spawnPosition.y = 0.25f + objectToSpawn[objectIndex].GetComponent<Renderer>().bounds.size.y / 2; //height(Land) / 2 + height(Eraser) / 2
			spawnPosition.z = 50f;  //Land length / 2
			Quaternion rotation = objectToSpawn[objectIndex].GetComponent<Transform>().rotation;
			GameObject spawnedObject = Instantiate (objectToSpawn [objectIndex], spawnPosition, rotation) as GameObject;
			spawnedObject.transform.parent = gameObject.transform;

		}


	}
}
