using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SetCostToText : MonoBehaviour {
	public PressButton button;
	void Start () {
		GetComponent<Text> ().text = button.Cost.ToString () + " coins";
	}
}