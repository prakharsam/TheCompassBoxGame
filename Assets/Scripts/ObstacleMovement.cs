using UnityEngine;
using System.Collections;

public class ObstacleMovement : MonoBehaviour {


	public float speed=5.0f;
	public float minDist = 1f;
	public Transform target;

	// Use this for initialization
	void Start () {

		if (target == null) {

			if (GameObject.FindWithTag ("Player") != null)
				target = GameObject.FindWithTag ("Player").GetComponent<Transform> ();

		}
	
	}
	
	// Update is called once per frame
	void Update () {

		if (target == null)
			return;
		
		float distance = Vector3.Distance (transform.position, target.position);

		if (distance > minDist)
			transform.position -= transform.forward * speed * Time.deltaTime;
	}

	public void setTarget(Transform newTarget){
		target = newTarget;
	}
}
