using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles: MonoBehaviour {

	public GameObject tube, wheel, pointCounter, movTube;
	public float maxHeight; //altezza massima di offset
	public float minHeight; //altezza minima di offset
	public float timeOfSpawn; //quanto ci mette a spawnare


	void Awake () 
	{
		Invoke ("Spawna", 0);
	}


	void Spawna ()
	{
		//può spawnare i tubi rossi solo se il record è sopra i 20
		int det = PlayerPrefs.GetInt ("highScore");
		int ostacolo = Random.Range (0, 3);
		if (det >= 20) {
			if (ostacolo == 1)
				SpawnWheel ();
			else if (ostacolo == 2)
				SpawnMovTubo ();
			else
				SpawnTubo ();
		} 

		else {
			if (ostacolo == 2)
				SpawnWheel ();
			else
				SpawnTubo ();
		}

		Invoke ("Spawna", timeOfSpawn);
	}

	void SpawnWheel(){
		Vector2 position = new Vector2 (transform.position.x, transform.position.y);
		Instantiate (wheel, position, Quaternion.identity);
		Instantiate (pointCounter, position + (Vector2.up*3), Quaternion.identity);
	}

	void SpawnTubo(){
		Vector2 range = new Vector2 (transform.position.x, transform.position.y + Random.Range (minHeight, maxHeight));
		Instantiate (tube, range, Quaternion.identity);
	}

	void SpawnMovTubo(){
		Vector2 range = new Vector2 (transform.position.x, transform.position.y + Random.Range (-2, 2));
		Instantiate (movTube, range, Quaternion.identity);
	}

}
