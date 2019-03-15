using UnityEngine;
using System.Collections;

public class AI_Absorber : MonoBehaviour {
	public GameObject Manager;
	private AI gamemanager;
	Vector3 tempScale;
	Vector3 startScale;
	bool MaxFlag = false;
	float MaxTemp;
	bool MinFlag = false;
	float MinTemp;
	int Seconds=6;
	void Start(){
		Manager = GameObject.Find ("AI");
		gamemanager = Manager.GetComponent<AI>();
		startScale = gamemanager.Player.transform.localScale;
	}
	void OnTriggerEnter2D(Collider2D other){
			 if (other.gameObject.tag == "Maximize") {
				MaxFlag = true;
				MaxTemp = Time.time;
				MinFlag = false;
			} else if (other.gameObject.tag == "Minimize") {
				MinFlag = true;
				MinTemp = Time.time;
				MaxFlag = false;
			}
		Destroy (other.transform.root.gameObject);
	}
	void Update(){
		tempScale = gamemanager.Player.transform.localScale;
		if (Time.time - MaxTemp <= Seconds && MaxFlag){
			gamemanager.Player.transform.localScale = Vector3.Lerp (tempScale, new Vector3 (startScale.x * 1.3f, startScale.y * 1.3f, 1f), Time.deltaTime*10);
		}
		else if(MaxFlag){
			gamemanager.Player.transform.localScale = Vector3.Lerp (tempScale, startScale, Time.deltaTime*10);
			if (gamemanager.Player.transform.localScale.x == startScale.x){
				MaxFlag = false;
			}
		}
		if (Time.time - MinTemp <= Seconds && MinFlag){
			gamemanager.Player.transform.localScale = Vector3.Lerp (tempScale, new Vector3 (startScale.x * 0.8f, startScale.y * 0.8f, 1f), Time.deltaTime*10);
		}
		else if(MinFlag){
			gamemanager.Player.transform.localScale = Vector3.Lerp (tempScale, startScale, Time.deltaTime*10);
			if (gamemanager.Player.transform.localScale.x == startScale.x) {
				MinFlag = false;
			}
		}
	}
}	