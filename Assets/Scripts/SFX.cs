using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SFX : MonoBehaviour {
	public AudioSource SFX_Source1;
	public AudioSource SFX_Source2;
	public Sprite SFX_On;
	public Sprite SFX_Off;
	void Start(){
		if (PlayerPrefs.GetInt("SFX",0) == 1) {
			GetComponent<Image>().sprite = SFX_Off;
			SFX_Source1.volume = 0;
			SFX_Source2.volume = 0;
		}
		else{
			GetComponent<Image>().sprite = SFX_On;
			SFX_Source1.volume = 1;
			SFX_Source2.volume = 1;
		}
	}
	public void Toggle(){
		if (PlayerPrefs.GetInt("SFX",0) == 1) {
			PlayerPrefs.SetInt ("SFX", 0);
			GetComponent<Image>().sprite = SFX_On;
			SFX_Source1.volume = 1;
			SFX_Source2.volume = 1;
		}
		else{
			PlayerPrefs.SetInt ("SFX", 1);
			GetComponent<Image>().sprite = SFX_Off;
			SFX_Source1.volume = 0;
			SFX_Source2.volume = 0;
		}
	}

}
