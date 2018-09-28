using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour {

	public static AudioClip flap, hit, point, newRecord, death;
	static AudioSource audioSrc;

	// Use this for initialization
	void Start () {

		flap = Resources.Load<AudioClip>("flap");
		hit = Resources.Load<AudioClip>("hit");
		point = Resources.Load<AudioClip>("point");
		death = Resources.Load<AudioClip>("death");
		newRecord = Resources.Load<AudioClip>("new record");

		audioSrc = GetComponent<AudioSource> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static void PlaySound (string clip){

		switch (clip){
			case "hit":
				audioSrc.PlayOneShot(hit);
				break;
			case "flap":
				audioSrc.PlayOneShot(flap);
				break;
			case "death":
				audioSrc.PlayOneShot(death);
				break;
			case "new record":
				audioSrc.PlayOneShot(newRecord);
				break;
			case "point":
				audioSrc.PlayOneShot(point);
				break;
		}

	}
}
