using UnityEngine;
using System.Collections;

public class Absorber : MonoBehaviour {
	public GameObject Manager;
	private GameManager gamemanager;
	public GameObject ScoreText;
	Vector3 tempScale;
	Vector3 startScale;
	int multiplier = 1;
	bool MaxFlag = false;
	float MaxTemp;
	bool MinFlag = false;
	float MinTemp;
	bool DoubleFlag = false;
	float DoubleTemp;
	public bool SlowFlag = false;
	float SlowTemp;
	int Seconds=6;
	void Start(){
		ScoreText = GameObject.Find ("Score Text");
		gamemanager = GameObject.Find("Game Manager").GetComponent<GameManager>();
		startScale = gamemanager.Player.transform.localScale;
	}
	void OnTriggerEnter2D(Collider2D other){
		if (!gamemanager.isGameOver) {
			if (other.gameObject.tag == "Simple") {
				gamemanager.GetComponent<AudioSource> ().PlayOneShot (gamemanager.bip);
				gamemanager.AddScore (10 * multiplier);
			} else if (other.gameObject.tag == "Extra 1") {
				gamemanager.GetComponent<AudioSource> ().PlayOneShot (gamemanager.extra1);
				gamemanager.AddScore (20 * multiplier);
			} else if (other.gameObject.tag == "Extra 2") {
				gamemanager.GetComponent<AudioSource> ().PlayOneShot (gamemanager.extra2);
				gamemanager.AddScore (50 * multiplier);
			} else if (other.gameObject.tag == "Maximize") {
				gamemanager.GetComponent<AudioSource> ().PlayOneShot (gamemanager.max);
				MaxFlag = true;
				gamemanager.Special2.SetActive (true);
				MaxTemp = Time.time;
				MinFlag = false;
				gamemanager.Special3.SetActive (false);
			} else if (other.gameObject.tag == "Minimize") {
				gamemanager.GetComponent<AudioSource> ().PlayOneShot (gamemanager.min);
				MinFlag = true;
				gamemanager.Special3.SetActive (true);
				MinTemp = Time.time;
				MaxFlag = false;
				gamemanager.Special2.SetActive (false);
			} else if (other.gameObject.tag == "Double") {
				gamemanager.GetComponent<AudioSource> ().Stop ();
				gamemanager.GetComponent<AudioSource> ().clip = gamemanager.by2;
				gamemanager.GetComponent<AudioSource> ().Play ();
				DoubleFlag = true;
				ScoreText.GetComponent<Animation> ().Stop ();
				ScoreText.GetComponent<Animation> ().Play ();
				gamemanager.Special1.SetActive (true);
				DoubleTemp = Time.time;
				multiplier = 2;
			} else if (other.gameObject.tag == "Slow") {
				gamemanager.GetComponent<AudioSource> ().PlayOneShot (gamemanager.slow);
				Seconds = 3;
				SlowFlag = true;
				gamemanager.Special4.SetActive (true);
				SlowTemp = Time.time;
				Time.timeScale = 0.5f;
				gamemanager.TimeSpeed = 0.5f;
			} else if (other.gameObject.tag == "Destructor" && gamemanager.Lives > 0) {
				gamemanager.RemoveLives ();
				gamemanager.GetComponent<AudioSource> ().PlayOneShot (gamemanager.banana);
				if (gamemanager.Lives <= 0) {
					gamemanager.li1.SetActive (false);
					gamemanager.li0.SetActive (true);
					gamemanager.GameOver ();
				} else if (gamemanager.Lives == 4) {
					gamemanager.li5.SetActive (false);
					gamemanager.li4.SetActive (true);
				} else if (gamemanager.Lives == 3) {
					gamemanager.li4.SetActive (false);
					gamemanager.li3.SetActive (true);
				} else if (gamemanager.Lives == 2) {
					gamemanager.li3.SetActive (false);
					gamemanager.li2.SetActive (true);
				} else if (gamemanager.Lives == 1) {
					gamemanager.li2.SetActive (false);
					gamemanager.li1.SetActive (true);
				} 
				Destroy (other.transform.root.gameObject);
			}
		}
		Destroy (other.gameObject);
	}
	void Update(){
		tempScale = gamemanager.Player.transform.localScale;
		if (Time.time - MaxTemp <= Seconds && MaxFlag){
			gamemanager.Player.transform.localScale = Vector3.Lerp (tempScale, new Vector3 (startScale.x * 1.3f, startScale.y * 1.3f, 1f), Time.deltaTime*10);
		}
		else if(MaxFlag){
			gamemanager.Player.transform.localScale = Vector3.Lerp (tempScale, startScale, Time.deltaTime*10);
			gamemanager.Special2.SetActive (false);
			if (gamemanager.Player.transform.localScale.x == startScale.x){
				MaxFlag = false;
			}
		}
		if (Time.time - MinTemp <= Seconds && MinFlag){
			gamemanager.Player.transform.localScale = Vector3.Lerp (tempScale, new Vector3 (startScale.x * 0.8f, startScale.y * 0.8f, 1f), Time.deltaTime*10);
		}
		else if(MinFlag){
			gamemanager.Player.transform.localScale = Vector3.Lerp (tempScale, startScale, Time.deltaTime*10);
			gamemanager.Special3.SetActive (false);
			if (gamemanager.Player.transform.localScale.x == startScale.x) {
				MinFlag = false;
			}
		}
		if (Time.time - DoubleTemp > Seconds && DoubleFlag){
			multiplier = 1;
			gamemanager.Special1.SetActive (false);
			DoubleFlag = false;
		}
		if (Time.time - SlowTemp > Seconds && SlowFlag){
			gamemanager.TimeSpeed = gamemanager.speed;
			Time.timeScale = gamemanager.TimeSpeed;
			Seconds = 6;
			SlowFlag = false;
			gamemanager.Special4.SetActive (false);
		}
	}
}	