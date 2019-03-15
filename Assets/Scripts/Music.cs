using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Music : MonoBehaviour {
	public AudioSource BGM;
	public Sprite MusicOn;
	public Sprite MusicOff;
	void Start(){
		if (PlayerPrefs.GetInt("Music",0) == 1) {
			GetComponent<Image>().sprite = MusicOff;
			BGM.volume = 0;
		}
		else{
			GetComponent<Image>().sprite = MusicOn;
			BGM.volume = 1;
		}
	}
	public void Toggle(){
		if (PlayerPrefs.GetInt("Music",0) == 1) {
			PlayerPrefs.SetInt ("Music", 0);
			GetComponent<Image>().sprite = MusicOn;
			BGM.volume = 1;
		}
		else{
			PlayerPrefs.SetInt ("Music", 1);
			GetComponent<Image>().sprite = MusicOff;
			BGM.volume = 0;
		}
	}

}
