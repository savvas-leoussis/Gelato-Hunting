using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class RandomTitle : MonoBehaviour {
	public Sprite[] Titles = new Sprite[4];
	void Start () {
		GetComponent<Image> ().sprite = Titles [(int)(Random.Range (0, 3))];
	}
}
