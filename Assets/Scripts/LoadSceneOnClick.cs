using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour {

	//è pubblica per poterla usare nell'ispector
	public void LoadByIndex(int sceneIndex)
	{
		if (gameObject.CompareTag ("Death Panel"))
			gameObject.SetActive (false);

		GlobalVariables.life = 100;

		SceneManager.LoadScene (sceneIndex);
	}
		
}
