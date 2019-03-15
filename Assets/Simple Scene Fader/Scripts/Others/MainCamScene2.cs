using UnityEngine;
using System.Collections;

public class MainCamScene2 : MonoBehaviour {

	public void OpenScene1Button () {
		GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ().enabled = false;
		Time.timeScale = 1f;
		SimpleSceneFader.ChangeSceneWithFade("menu");
	}

}
