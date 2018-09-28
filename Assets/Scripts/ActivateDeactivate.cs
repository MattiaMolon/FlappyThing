using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDeactivate : MonoBehaviour {

	void Awake(){
		if (gameObject.CompareTag ("Death Panel"))
			gameObject.SetActive (false);
		else if (gameObject.CompareTag ("Score Panel"))
			gameObject.SetActive (true);
	}
}
