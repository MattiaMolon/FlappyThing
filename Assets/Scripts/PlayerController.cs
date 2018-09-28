using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
	 
	//variabili di movimento
	public float jumpVelocity;
	public float maxVelocity;

	//oggetti nella scena
	public Text scoreText, lifeText, highScoreText;
	public GameObject lifeBar;
	public GameObject diePanel, vita;

	//altre variabili secondarie
	private Image sr;
	private Rigidbody2D rb2d;
	private int score;
	private int highScore = 0;
	private float lifeBarScale;
	private bool dead = false;


	void Awake () 
	{
		rb2d = GetComponent<Rigidbody2D> ();
		sr = lifeBar.GetComponent<Image> ();
		score = 0;
	}

	void Start () 
	{
		Invoke ("AutoHeal", GlobalVariables.healingTime);
		lifeBarScale = lifeBar.transform.localScale.x;

		//setto high score con il PLayerPref
		highScore = PlayerPrefs.GetInt("highScore");
		setHighScoreText ();  setScoreText ();   setLifeText ();
	}

	void Update ()
	{
		if (!dead) {

			//PER QUANTO RIGUARDA IL SALTO SIA PER COMPUTER CHE PER ANDROID
			if (Input.GetKeyDown (KeyCode.Space) || (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began)) {
				if (rb2d.velocity.y < maxVelocity) {
					
					SoundManagerScript.PlaySound("flap");

					rb2d.AddForce (new Vector2 (0f, jumpVelocity));
				}
			}

			//TUTTI CONTROLLI SULLE VELOCITA'
			if (rb2d.velocity.y > maxVelocity)
				rb2d.velocity = new Vector2 (0, maxVelocity);
			else if (rb2d.velocity.y < -maxVelocity)
				rb2d.velocity = new Vector2 (0, -maxVelocity);

			if (rb2d.velocity.x != 0)
				rb2d.velocity = new Vector2 (0, rb2d.velocity.y);


			//CONTROLLI SULLA POSIZIONE
			if (transform.position.y <= 0)
				Die ();
			else if (transform.position.y >= 9.8f)
				rb2d.velocity = new Vector2 (0, -GlobalVariables.velocity * 2.5f);
			if (transform.position.x <= 0)
				Die ();


			//CONTROLLI SULLA VITA
			if (GlobalVariables.life <= 0)
				Die ();
		}
	}
		

	void OnTriggerEnter2D (Collider2D other) 
	{
		if (other.gameObject.CompareTag ("Point")) 
		{
			score += 1; setScoreText ();

			//controllo se score > highscore e salvo in PlayerPref
			if (score > highScore){
				SoundManagerScript.PlaySound("new record");
				highScore = score;
				PlayerPrefs.SetInt ("highScore", highScore);
				setHighScoreText ();
			}
			else{
				SoundManagerScript.PlaySound("point");
			}
		}
	}


	void OnCollisionEnter2D (Collision2D other)
	{	

		SoundManagerScript.PlaySound("hit");

		if (other.gameObject.CompareTag ("Tube") || other.gameObject.CompareTag("Moving Tube")) {
			GlobalVariables.life -= GlobalVariables.tubeDamage;
			//modifico la lifebar (i calcoli sono dovuti al fatto che modifico la lifebar in base ai danni dei vari oggetti
			lifeBar.transform.localScale = new Vector3 (lifeBar.transform.localScale.x - ((GlobalVariables.tubeDamage / 100f) * lifeBarScale)
													  , lifeBar.transform.localScale.y
													  , lifeBar.transform.localScale.z);
		} 

		else if (other.gameObject.CompareTag ("Wheel")) {
			GlobalVariables.life -= GlobalVariables.wheelDamage;
			lifeBar.transform.localScale = new Vector3 (lifeBar.transform.localScale.x - ((GlobalVariables.wheelDamage/100f)*lifeBarScale)
													  , lifeBar.transform.localScale.y
													  , lifeBar.transform.localScale.z);
		}

		setLifeText ();
	}


	void Die()
	{
		diePanel.SetActive (true);
		vita.SetActive (false);

		SoundManagerScript.PlaySound("death");

		//non so perchè ma per far si che venga fuori il DiePanel devo per forza metterci questo IF
		//se non lo metto schifa quel pannello perchè è uno stronzo
		if (diePanel.activeSelf) {
			gameObject.SetActive (false);
			dead = true;
		}
	}
		

	void AutoHeal ()
	{
		if (GlobalVariables.life <= 99.5f) {
			GlobalVariables.life += GlobalVariables.healing;
			lifeBar.transform.localScale = new Vector3 (lifeBar.transform.localScale.x + ((GlobalVariables.healing/ 100f) * lifeBarScale)
													  , lifeBar.transform.localScale.y
													  , lifeBar.transform.localScale.z);
		}
		setLifeText ();
		Invoke ("AutoHeal", GlobalVariables.healingTime);
	}


	//-------------------------------------------------------//
	//FUNZIONI PER SETTARE I VARI TEXT
	void setScoreText ()
	{
		scoreText.text = "SCORE: " + score.ToString ();
	}

	void setLifeText()
	{
		lifeText.text = GlobalVariables.life.ToString() + "/100 HP";
		if (GlobalVariables.life > 66 && GlobalVariables.life <= 100) {
			sr.color = Color.green;
		}

		if (GlobalVariables.life > 33 && GlobalVariables.life <= 66) {
			sr.color = Color.yellow;
		}

		if (GlobalVariables.life <= 33) {
			sr.color = Color.red;
		}
	}

	void setHighScoreText(){
		highScoreText.text = "RECORD : " + highScore.ToString();
	}
}
