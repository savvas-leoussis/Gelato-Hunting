using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
//using GooglePlayGames;
//using GooglePlayGames.BasicApi;
//using UnityEngine.SocialPlatforms;

public class AI : MonoBehaviour{
	public GameObject Player;
	int i;
	public GameObject Coupons;
	public GameObject[] IceCreams = new GameObject[8];
	public GameObject[] SimpleIceCreams = new GameObject[4];
	public GameObject GPG;
	public GameObject[] Cups = new GameObject[4];
	/*void Awake(){
		PlayGamesPlatform.DebugLogEnabled = true;
		PlayGamesPlatform.Activate();
		if (!Social.localUser.authenticated) {
			Social.localUser.Authenticate ((bool success) => {
			});
			Social.ReportScore (PlayerPrefs.GetInt ("Score0"), GelatoHuntingResources.leaderboard_high_scores, (bool success) => {
			});
		}
		GPG.GetComponent<Button> ().enabled = true;
		GPG.GetComponent<Image> ().enabled = true;
	}*/
	IEnumerator Start (){
		//PlayerPrefs.DeleteAll ();
		Time.timeScale = 1f;
		Player = (GameObject)Instantiate(Cups [(int)UnityEngine.Random.Range(0,3)], new Vector3 (0, -4, -3), Quaternion.identity);
		if (PlayerPrefs.GetInt ("TotalCoupons", 0) == 3 && PlayerPrefs.GetInt("Coupons",0) == 0) {
			Coupons.SetActive (false);
		}
		while (true){
			yield return new WaitForSeconds(UnityEngine.Random.Range(0.4f, 1.2f));
			StartCoroutine ("Throw");
		}
	}

	void Update (){
		if (Input.GetMouseButtonDown (1)) {
			ScreenCapture.CaptureScreenshot ("Screenshot " + i.ToString ()+".png");
			i++;
			Debug.Log ("Screenshot " + i.ToString ());
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
		int random = RandomBall ();
		if (random !=0)
		{	
			Instantiate (IceCreams [random], new Vector3 (RandomPosition (), 6, 0), Quaternion.identity);
		}
		else
		{
			Instantiate (SimpleIceCreams [SimpleFlavorPicker()], new Vector3 (RandomPosition (), 6, 0), Quaternion.identity);
		}
	}
	int SimpleFlavorPicker(){
		return (int)UnityEngine.Random.Range (0, 3);
	}
}