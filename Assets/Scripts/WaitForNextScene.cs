using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class WaitForNextScene : MonoBehaviour {
	public float seconds;
	IEnumerator Start () {
		yield return new WaitForSeconds (seconds);
		SceneManager.LoadScene ("menu");
	}
	void Update(){
		if (Input.GetMouseButton (0) || Input.touchCount > 0) {
			SceneManager.LoadScene ("menu");
		}
	}
}
