using UnityEngine;
using System.Collections;

public class Return : MonoBehaviour {
	public GameObject MainMenu;
	public AudioSource AI;
	public AudioClip menu_button;
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			ReturnBack ();
		}
	}
	void ReturnBack(){
		AI.PlayOneShot (menu_button);
		MainMenu.SetActive (true);
		transform.parent.gameObject.SetActive (false);
	}
}
