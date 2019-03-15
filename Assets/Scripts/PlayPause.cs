using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayPause : MonoBehaviour {
	public Text GetReadyText;
	public GameObject PausePanel;
	public GameObject Manager;
	private GameManager gamemanager;
	public Sprite start;
	public Sprite pause;
	public bool play = true;
	void Start(){
		gamemanager = Manager.GetComponent<GameManager>();
	}
	void Update(){
		if (!play) {
			Time.timeScale = 0;
		}
		else {
			Time.timeScale = gamemanager.TimeSpeed;
		}
	}
	void OnApplicationPause(){
		if (play && GetComponent<Button> ().interactable == true) {
			GetComponent<Image>().sprite = start;
			play = !play;
			PausePanel.SetActive (true);
		}
	}
	public void ChangeImage(){
		if (!play) {
			GetComponent<Image>().sprite = pause;
			PausePanel.SetActive (false);
			StartCoroutine ("getReady");
		}
		else{
			GetComponent<Image>().sprite = start;
			play = !play;
			PausePanel.SetActive (true);
		}
	}
	public void Restart(){
		SceneManager.LoadScene ("scene");
	}
	public void Quit(){
		SceneManager.LoadScene ("menu");
	}
	IEnumerator getReady()    
	{
		GetReadyText.gameObject.SetActive(true); 
		GetComponent<Button> ().interactable = false;
		GetReadyText.text = "3";    
		yield return StartCoroutine (WaitForRealSeconds(1f));
		GetReadyText.text = "2";    
		yield return StartCoroutine (WaitForRealSeconds(1f));
		GetReadyText.text = "1";    
		yield return StartCoroutine (WaitForRealSeconds(1f));
		GetReadyText.text = "GO!";    
		yield return StartCoroutine (WaitForRealSeconds(0.5f));
		GetReadyText.text = "";
		GetComponent<Button> ().interactable = true;
		play = !play;
		GetReadyText.gameObject.SetActive(false);  
	}

	IEnumerator WaitForRealSeconds (float waitTime) {
		float endTime = Time.realtimeSinceStartup+waitTime;

		while (Time.realtimeSinceStartup < endTime) {
			yield return null;
		}
	}
}