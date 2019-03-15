using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class PressButton : MonoBehaviour {
	public StoreSelect store;
	public int Cost;
	private int index;
	private char type;
	public AudioClip Buy;
	public AudioClip Using;
	public GameObject NoMoney;
	
	void Start(){
		index = int.Parse(tag[tag.Length - 1].ToString());
		if (tag.Length == 7) {
			if (int.Parse (tag [tag.Length - 2].ToString ()) == 2) { 
				index += 10;
			}
			index += 10;
		}
		index--;
		type = tag [0];
	}

	public void Press(){
		if (type.Equals ('C')) {
			if (store.CupStatus [index] == 1) {
				store.GetComponent<AudioSource> ().PlayOneShot (Using);
				store.SetToUseCup (Array.IndexOf (store.CupStatus, 2));
				store.SetToUsingCup (index);
				PlayerPrefs.SetInt ("CupToUse", index);
			}
			else if (store.CupStatus [index] == 0) {
				if (PlayerPrefs.GetInt ("Coins") >= Cost) {
					store.GetComponent<AudioSource> ().PlayOneShot (Buy);
					store.SetToUseCup (Array.IndexOf (store.CupStatus, 2));
					store.SetToUsingCup (index);
					PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt("Coins") - Cost);
					PlayerPrefs.SetInt ("CupToUse", index);
				}
				else {
					NoMoney.SetActive (true);
				}
			}

		}
		else {
			if (store.WallStatus [index] == 1) {
				store.GetComponent<AudioSource> ().PlayOneShot (Using);
				store.SetToUseWall (Array.IndexOf (store.WallStatus, 2));
				store.SetToUsingWall (index);
				PlayerPrefs.SetInt ("BackroundToUse", index);
			}
			else if (store.WallStatus [index] == 0) {
				if (PlayerPrefs.GetInt ("Coins") >= Cost) {
					store.GetComponent<AudioSource> ().PlayOneShot (Buy);
					store.SetToUseWall (Array.IndexOf (store.WallStatus, 2));
					store.SetToUsingWall (index);
					PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt("Coins") - Cost);
					PlayerPrefs.SetInt ("BackroundToUse", index);
				}
				else {
					NoMoney.SetActive (true);
					Debug.Log ("1");
				}		
			}
		}
	}
}
