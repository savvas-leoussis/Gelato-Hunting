using UnityEngine;
using System.Collections;

public class FloorAbsorber : MonoBehaviour {
    public GameObject Manager;
	private GameManager gamemanager;
    void Start(){
		gamemanager = Manager.GetComponent<GameManager> ();
		gamemanager.li5.SetActive (true);
    }
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Simple" && gamemanager.Lives >0) {
			gamemanager.RemoveLives ();
			if (gamemanager.Lives <= 0) {
                gamemanager.GetComponent<AudioSource>().PlayOneShot(gamemanager.crunch);
            	gamemanager.li1.SetActive (false);
				gamemanager.li0.SetActive (true);
				gamemanager.GameOver();
			}
			else if (gamemanager.Lives == 4) {
                gamemanager.GetComponent<AudioSource>().PlayOneShot(gamemanager.lick);
                gamemanager.li5.SetActive (false);
				gamemanager.li4.SetActive (true);
			}
			else if (gamemanager.Lives == 3) {
                gamemanager.GetComponent<AudioSource>().PlayOneShot(gamemanager.lick);
                gamemanager.li4.SetActive (false);
			gamemanager.li3.SetActive (true);
			}
			else if (gamemanager.Lives == 2) {
                gamemanager.GetComponent<AudioSource>().PlayOneShot(gamemanager.lick);
                gamemanager.li3.SetActive (false);
				gamemanager.li2.SetActive (true);
			}
			else if (gamemanager.Lives == 1) {
                gamemanager.GetComponent<AudioSource>().PlayOneShot(gamemanager.crunch);
             gamemanager.li2.SetActive (false);
				gamemanager.li1.SetActive (true);
			}
		}
		Destroy (other.gameObject);
	}
}
