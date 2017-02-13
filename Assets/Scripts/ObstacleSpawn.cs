using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : Spawning {
	
	public override void Spawn(){
		
		int objectIndex = Random.Range (0, objectToSpawn.Length);


		spawnPosition.x = Random.Range (-4, 4);
		spawnPosition.y = 0.25f + objectToSpawn[objectIndex].GetComponent<Renderer>().bounds.size.y / 2; //height(Land) / 2 + height(Eraser) / 2
		spawnPosition.z = 50f;  //Land length / 2
		Quaternion rotation = objectToSpawn[objectIndex].GetComponent<Transform>().rotation;
		GameObject spawnedObject = Instantiate (objectToSpawn [objectIndex], spawnPosition, rotation) as GameObject;
		spawnedObject.transform.parent = gameObject.transform;
					
	}
}
