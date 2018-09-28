using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour {

	public static float cloudVelocity = 2;				//velocitaà delle nuvole sullo sfondo
	public static float velocity = 4;					//velocita degli oggetti del gioco
	public static float life = 100;						//vita del giocatore
	public static float tubeDamage = 35;				//danni deìi tubi
	public static float wheelDamage = 25;				//danni delle lame
	public static float healingTime = 1f;				//ogni quanto tempo si cura il personaggio
	public static float healing = 0.5f;					//di quanto si cura il personaggio
	public static float menuVelocity = 0.3f;			//di quanto si muovono i tubi nel menu
	public static bool highscoreBool = false;				//booleano che mi dice quando sto facendo un highscore
}
