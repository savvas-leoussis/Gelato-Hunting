using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
//using GooglePlayGames;
//using UnityEngine.SocialPlatforms;

public class GameManager : MonoBehaviour{
	private int[] ScoreTable = new int[11] ;
	public Text ScoreText;

	private GameObject absorber;
	public GameObject ScoreParent;
	public GameObject gameover;
	public GameObject Player;
	public GameObject Confetti1;
	public GameObject Confetti2;
	public GameObject IntroMessageBox;
	public GameObject LevelUpper;

	public GameObject gameoverText;
	public GameObject loser;
	public GameObject GameOverButton1;
	public GameObject GameOverButton2;

	public Text GameOverText;
	public Text GetReadyText;
	public Text NewHighScoreText;

	private bool isNewHighScore = false;
	public bool isGameOver = false;
	public int isStarted;
	public int Lives = 5;
	public int Score = 0;
	private float PitchTemp;

	public float TimeSpeed = 1f;
	public float speed = 1f;

	public int[] level = new int[3];
	public int ScoreForCoupon;
	public GameObject[] IceCreams = new GameObject[8];
	public GameObject[] SimpleIceCreams = new GameObject[4];

	public GameObject Level1Text;
	public GameObject Level2Text;
	public GameObject Level3Text;
	public GameObject Level4Text;

	public GameObject Special1;
	public GameObject Special2;
	public GameObject Special3;
	public GameObject Special4;

	public GameObject li0;
	public GameObject li1;
	public GameObject li2;
	public GameObject li3;
	public GameObject li4;
	public GameObject li5;

	public GameObject CouponMessage;

	public GameObject[] Background = new GameObject[21];
	public GameObject[] Cups = new GameObject[4];

	public Button Pause;
	public AudioClip bip;
    public AudioClip lick;
    public AudioClip crunch;
    public AudioClip max;
    public AudioClip min;
    public AudioClip extra1;
    public AudioClip extra2;
    public AudioClip banana;
    public AudioClip by2;
    public AudioClip slow;
    public AudioClip gameover_sound;
	public AudioClip newhighscore;
	public AudioSource BGM;

	IEnumerator Start (){
		isStarted = PlayerPrefs.GetInt ("FirstTime", 0);
		if (PlayerPrefs.GetInt ("SFX") == 1) {
			GetComponent<AudioSource> ().volume = 0;
		}
		if (PlayerPrefs.GetInt("Music") == 1){
			BGM.volume = 0;
		}
		Player = (GameObject)Instantiate(Cups [PlayerPrefs.GetInt ("CupToUse")], new Vector3 (0, -4, -3), Quaternion.identity);
		absorber = Player.GetComponentInChildren<Absorber> ().gameObject;
		ScoreText.text = Score.ToString ();
		for (int i = 0; i < 21; i++) {
			Background [i].SetActive (false);
		}
		Background [PlayerPrefs.GetInt ("BackroundToUse")].SetActive (true);
		while (true){
				yield return new WaitForSeconds (UnityEngine.Random.Range (0.4f, 1.2f));
				StartCoroutine ("Throw");
				if (isGameOver) {
					break;
				}
			}
	}
	void Update (){
		if (isStarted == 1) {
			LevelUpper.SetActive (true);
		}
		if (!absorber.GetComponent<Absorber>().SlowFlag) {
			Time.timeScale = TimeSpeed;
			TimeSpeed = speed;
		}
		if (Score < level[0]) {
			BGM.pitch = 1f;
			speed = 0.99f;
			Level4Text.SetActive (false);
			Level1Text.SetActive (true);
		}
		else if (Score >= level[0] && Score < level[1]) {
			BGM.pitch = 1.1f;
			speed = 1.29f;
			Level1Text.SetActive (false);
			Level2Text.SetActive (true);
		}
		else if (Score >= level[1] && Score < level[2]) {
			BGM.pitch = 1.2f;
			speed = 1.49f;
			Level2Text.SetActive (false);
			Level3Text.SetActive (true);
		}
		else{
			if (Score < level [2] + 500) {
				Level3Text.SetActive (false);
				Level4Text.SetActive (true);
				speed = 1.69f;
				BGM.pitch = 1.3f;
			} else if (Score >= level [2] + 500 && Score < 5000) {
				speed = 1.69f * (1.0f + (Mathf.Log (Score * 1.0f / (level [2] + 500.0f))) * 0.2f);
			} else 
			{
				speed = 1.999706f;
				BGM.pitch = 1.4f;
			}
		}
	}
	int RandomBall(){
		int rand;
		int temp = UnityEngine.Random.Range(1,100);
		if (temp < 77) {
			rand = 0; // simple
		}
		else if (temp < 84) 
		{
			rand = 1; // destructor
		} 
		else if (temp < 87) 
		{
			rand = 2; // double
		} 
		else if (temp < 92) 
		{
			rand = 3; // extra 1
		} 
		else if (temp < 94) 
		{
			rand = 4; // extra 2
		} 
		else if (temp < 96) 
		{
			rand = 5; // max
		} 
		else if (temp < 98) 
		{
			rand = 6; // min
		}
		else {
			rand = 7; // slow
		}
		return rand;
	}
	float RandomPosition(){
		float rand = UnityEngine.Random.Range(-2.60f,2.60f);
		return rand;
	}
	void Throw(){
		if (isStarted == 0) {
			IntroMessageBox.SetActive (true);
		} 
		else {
			int random = RandomBall ();
			if (random != 0) {	
				Instantiate (IceCreams [random], new Vector3 (RandomPosition (), 6, 0), Quaternion.identity);
			} else {
				Instantiate (SimpleIceCreams [SimpleFlavorPicker ()], new Vector3 (RandomPosition (), 6, 0), Quaternion.identity);
			}
		}
	}
	 public void AddScore(int value){
		if (!isGameOver) {
			ScoreParent.GetComponent<Animation> ().Stop ();
			ScoreParent.GetComponent<Animation> ().Play ();
			Score += value;
			ScoreText.text = Score.ToString ();
			if (Score > PlayerPrefs.GetInt ("Score0") && !isNewHighScore && PlayerPrefs.GetInt("FirstTime",0) == 1) {
				GetComponent<AudioSource> ().PlayOneShot (newhighscore);
				NewHighScoreText.gameObject.SetActive (true);
				Confetti1.SetActive (true);
				isNewHighScore = true;
			}
		}
	}
	 public void RemoveLives(){
		Lives--;
	}
	public void GameOver(){
		/*if (Score > PlayerPrefs.GetInt ("Score0") && Application.platform == RuntimePlatform.Android) {
			Social.ReportScore (Score, GelatoHuntingResources.leaderboard_high_scores, (bool success) => {
			});
		}*/
		PlayerPrefs.SetInt ("FirstTime", 1);
		Pause.interactable = false;
		isGameOver = true;
		gameoverText.GetComponent<Text> ().text = ScoreText.text;
		GameOverButton1.SetActive (true);
		GameOverButton2.SetActive (true);
		if (Score == 0) {
			loser.SetActive (true);
            loser.GetComponent<Animation> ().Play ();
		}
		else {
			gameover.SetActive (true);
            gameover.GetComponent<Animation> ().Play ();
		}
		ScoreText.enabled = false;
		li0.SetActive (false);
		gameoverText.SetActive (true);
        GetComponent<AudioSource>().Stop();
		if (Score >= ScoreForCoupon && PlayerPrefs.GetInt ("Coupons", 0) < 3 && PlayerPrefs.GetInt("TotalCoupons",0) != 3) {
			PlayerPrefs.SetInt ("Coupons", PlayerPrefs.GetInt ("Coupons", 0) + 1);
			PlayerPrefs.SetInt ("TotalCoupons", PlayerPrefs.GetInt ("TotalCoupons", 0) + 1);
			CouponMessage.SetActive (true);
			GetComponent<AudioSource> ().PlayOneShot (newhighscore);
			Instantiate (Confetti2, new Vector3 (0, 10, 2), Quaternion.identity);
		} 
		else {
			GetComponent<AudioSource> ().PlayOneShot (gameover_sound);
		}
        gameoverText.GetComponent<Animation> ().Play ();
		PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + Score);
		PlayerPrefs.SetInt ("CurrentScore", Score);
		for (int i = 0; i < 10; i++) {
			ScoreTable[i] = PlayerPrefs.GetInt ("Score" + i.ToString ());
		}
		ScoreTable [10] = Score;
		Array.Sort (ScoreTable);
		Array.Reverse (ScoreTable);
		for (int i = 0; i < 10; i++) {
			PlayerPrefs.SetInt ("Score" + i.ToString (), ScoreTable [i]);
		}
		PlayerPrefs.Save();
	}
	int SimpleFlavorPicker(){
		if (Score < level[0]) {
			return 0;
		}
		else if (level[0] <= Score && Score < level[1]) {
			return 1;
		}
		else if (level[1] <= Score && Score < level[2]) {
			return 2;
		}
		else{
			return 3;
		}
	}
	public IEnumerator getReady()    
	{
		Debug.Log ("resume");
		GetReadyText.gameObject.SetActive(true);    
		GetReadyText.text = "3";    
		yield return StartCoroutine (WaitForRealSeconds(0.5f));
		GetReadyText.text = "2";    
		yield return StartCoroutine (WaitForRealSeconds(0.5f));
		GetReadyText.text = "1";    
		yield return StartCoroutine (WaitForRealSeconds(0.5f));
		GetReadyText.text = "GO";    
		yield return StartCoroutine (WaitForRealSeconds(0.5f));
		GetReadyText.text = "";
		GetReadyText.gameObject.SetActive(false);  
		Time.timeScale = TimeSpeed;
	}
	IEnumerator WaitForRealSeconds (float waitTime) {
		float endTime = Time.realtimeSinceStartup+waitTime;
		while (Time.realtimeSinceStartup < endTime) {
			yield return null;
		}
	}
	public void setStart(){
		isStarted = 1;
	}
}