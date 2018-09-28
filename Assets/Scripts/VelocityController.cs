using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityController : MonoBehaviour {

	private Rigidbody2D rb2d;

	void Awake ()
	{
		rb2d = GetComponent<Rigidbody2D> ();
	}


	void Start ()
	{
		//Movimenti dei vari oggetti
		if (CompareTag("Cloud"))
			rb2d.velocity = Vector2.left * GlobalVariables.cloudVelocity;

		else if(CompareTag("Moving Tube")){
			int random = Random.Range(0, 100);
			Vector2 direction;
			if (random % 2 == 0) 
				direction = new Vector2(-GlobalVariables.velocity, GlobalVariables.velocity*80/100);
			else
				direction = new Vector2(-GlobalVariables.velocity, -GlobalVariables.velocity*80/100);
			rb2d.velocity = direction;
		}

		else
			rb2d.velocity = Vector2.left * GlobalVariables.velocity;

		//Velocità di rotazione della ruota
		if (CompareTag("Wheel"))
			rb2d.angularVelocity = 500f;

	}


	void Update ()
	{
		//movimento degli oggetti che non sono nuvole
		if (!CompareTag("Cloud") && !CompareTag("Moving Tube"))
			if (rb2d.velocity.y != -GlobalVariables.velocity)
				rb2d.velocity = Vector2.left * GlobalVariables.velocity;

		//distruzione dell'oggetto fuori dallo schermo
		if (transform.position.x <= -3)
			Destroy (gameObject);

		//Up and Down del tubo rosso
		if (CompareTag ("Moving Tube")) {
			//controllo di posizione in alto ed in basso
			if (transform.position.y >= 6.50 || transform.position.y <= 3.50) {
				Vector2 upDown = Vector2.zero;
				if (transform.position.y >= 6.50)
					upDown = new Vector2 (rb2d.velocity.x, -GlobalVariables.velocity*80/100);
				else if (transform.position.y <= 3.50)
					upDown = new Vector2 (rb2d.velocity.x, +GlobalVariables.velocity*80/100);
				rb2d.velocity = upDown;
			}
				
		}
			
	}
}