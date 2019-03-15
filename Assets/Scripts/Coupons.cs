using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Coupons : MonoBehaviour {
	public GameObject MessageBox;
	void Update () {
		GetComponent<Text> ().text = PlayerPrefs.GetInt ("Coupons", 0).ToString ();
	}
	public void Redeem(){
			PlayerPrefs.SetInt ("Coupons", PlayerPrefs.GetInt ("Coupons", 0) - 1);
	}
	public void Check(){
		if (PlayerPrefs.GetInt ("Coupons", 0) > 0) {
			MessageBox.SetActive (true);
		}
	}
}
