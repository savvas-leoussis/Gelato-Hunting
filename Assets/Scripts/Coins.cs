using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Coins : MonoBehaviour {
	void Update () {
		GetComponent<Text> ().text = PlayerPrefs.GetInt ("Coins").ToString ();
	}
}
