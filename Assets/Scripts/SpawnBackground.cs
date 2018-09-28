using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBackground : MonoBehaviour {

	public GameObject cloud;
	public float maxHeight; //altezza di offset


	void Awake () 
	{
		Invoke ("Spawna", 1);
	}
		

	void Spawna (){
		Vector3 range = new Vector3 (transform.position.x, transform.position.y + Random.Range (-2, maxHeight+2), +1);
		Instantiate (cloud, range, Quaternion.identity);
		Invoke ("Spawna", Random.Range(3, 5));
	}

}
