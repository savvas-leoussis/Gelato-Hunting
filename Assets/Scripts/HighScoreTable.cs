using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScoreTable : MonoBehaviour {
	public Text[] HighScore = new Text[10];
	void Start () {
		for (int i = 0; i < 9; i++) {
			HighScore[i].text = "  "+(i+1).ToString()+".   "+PlayerPrefs.GetInt ("Score" + i.ToString ()).ToString();
		}
		HighScore[9].text = (10).ToString()+".   "+PlayerPrefs.GetInt ("Score" + 9.ToString ()).ToString();
	}
}
