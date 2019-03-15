using UnityEngine;
using System.Collections;

public class HighScore : MonoBehaviour {
	public GameObject menu;
	public GameObject highscores;
	public void OpenHighScores(){
		menu.SetActive (false);
		highscores.SetActive (true);
	}
	public void CloseHighScores(){
		menu.SetActive (true);
		highscores.SetActive (false);
	}
}
