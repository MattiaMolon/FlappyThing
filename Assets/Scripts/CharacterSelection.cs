using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour {

	private GameObject[] characterList;
	private int index = 0;

	private void Start(){
		
		characterList = new GameObject[transform.childCount];
		index = PlayerPrefs.GetInt ("CS");

		for (int i = 0; i < transform.childCount; i++) 
			characterList [i] = transform.GetChild (i).gameObject;

		for (int i = 0; i < transform.childCount; i++) 
			characterList [i].SetActive (false);

		if (characterList [index])
			characterList [index].SetActive (true);
	}

	public void ToggleLeft(){

		//disattiviamo il modello che abbiamo attivo
		characterList[index].SetActive(false);

		index--;

		if (index < 0)
			index = characterList.Length - 1;

		//attiviamo il modello che vogliamo
		characterList [index].SetActive (true);
	}


	public void ToggleRight(){

		//disattiviamo il modello che abbiamo attivo
		characterList[index].SetActive(false);

		index++;

		if (index > characterList.Length-1)
			index = 0;

		//attiviamo il modello che vogliamo
		characterList [index].SetActive (true);
	}

	public void SetIndex(){
		PlayerPrefs.SetInt ("CS", index);
	}

	public void Inizializza(){
		index = PlayerPrefs.GetInt ("CS");

		for (int i = 0; i < transform.childCount; i++) 
			characterList [i].SetActive (false);

		if (characterList [index])
			characterList [index].SetActive (true);
	}

}
