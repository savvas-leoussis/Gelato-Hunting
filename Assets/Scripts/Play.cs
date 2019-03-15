using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour {
	public GameObject BGM;
	void Start(){
		PlayerPrefs.Save();
		Time.timeScale = 1f;
	}
	public void PlayGame(){
		SceneManager.LoadScene ("scene");
	}
	public void FadeOutMusic()
	{
		StartCoroutine(FadeMusic());
	}
	IEnumerator FadeMusic()
	{
		while(BGM.GetComponent<AudioSource>().volume > .1F)
		{
			BGM.GetComponent<AudioSource>().volume = Mathf.Lerp(BGM.GetComponent<AudioSource>().volume,0F,Time.deltaTime*3);
			yield return 0;
		}
		BGM.GetComponent<AudioSource>().volume = 0;
	}
}
