using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour {

	Rigidbody2D rb2d;
	private bool destra = true;

	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		if(gameObject.CompareTag("Menu Tubes"))
			Invoke ("MuoviTubo", 0);
		else
			Invoke("MuoviSkull", 0);
	}
		
	void Update(){

		//controlli di posizione
		if(gameObject.CompareTag("Menu Tubes")){
			if (transform.position.y >= -2f)
				rb2d.velocity = Vector2.down * GlobalVariables.menuVelocity;
			if (transform.position.y <= -3f)
				rb2d.velocity = Vector2.up * GlobalVariables.menuVelocity;
		}
	}

	void MuoviTubo(){
		int y = Random.Range (0, 100);
		Vector2 direction;
		if (y % 2 == 0) 
			direction = Vector2.up * GlobalVariables.menuVelocity;
		else
			direction = Vector2.down * GlobalVariables.menuVelocity;

		rb2d.velocity = direction;

		Invoke ("MuoviTubo", 1.5f);
	}

	void MuoviSkull(){
		destra = !destra;

		if (destra)
			rb2d.AddTorque (5f);
		else
			rb2d.AddTorque (-5f);

		Invoke ("MuoviSkull", 1f);
		
	}

	
}
