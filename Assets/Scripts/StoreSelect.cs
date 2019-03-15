using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StoreSelect : MonoBehaviour {
	public Button[] Cups = new Button[4];
	public Button[] Walls = new Button[21];

	public int[] CupStatus = new int[4];
	public int[] WallStatus = new int[21];

	public Sprite BuyColor;
	public Sprite UseColor;
	public Sprite UsingColor;

	public GameObject[] CostTextCups = new GameObject[3];
	public GameObject[] CostTextWalls = new GameObject[20];

	void Start () {
		CupStatus[0] = PlayerPrefs.GetInt("Cup 1",2);
		for (int i = 1; i < 4; i++) {
			CupStatus[i] = PlayerPrefs.GetInt ("Cup "+(i+1).ToString());
		}
		for (int i = 0; i < 4; i++) {
			if (CupStatus [i] == 0) {
				SetToBuyCup (i);
			} 
			else if (CupStatus [i] == 1) {
				SetToUseCup (i);
			} 
			else {
				SetToUsingCup (i);
			}
		}

		WallStatus[0] = PlayerPrefs.GetInt("Wall 1",2);
		for (int i = 1; i < 21; i++) {
			WallStatus[i] = PlayerPrefs.GetInt ("Wall "+(i+1).ToString());
		}
		for (int i = 0; i < 21; i++) {
			if (WallStatus [i] == 0) {
				SetToBuyWall (i);
			} 
			else if (WallStatus [i] == 1) {
				SetToUseWall (i);
			} 
			else {
				SetToUsingWall (i);
			}
		}
	}
	public void SetToBuyCup(int ind){
		Cups [ind].GetComponentInChildren<Text> ().text = "Buy";
		Cups [ind].GetComponent<Image>().sprite = BuyColor;
		CupStatus [ind] = 0;
		if (ind > 0) {
			CostTextCups [ind - 1].SetActive (true);
		}
	}
	public void SetToUseCup(int ind){
		Cups [ind].GetComponentInChildren<Text> ().text = "Use";
		Cups [ind].GetComponent<Image>().sprite = UseColor;
		CupStatus [ind] = 1;
		PlayerPrefs.SetInt ("Cup "+(ind+1).ToString(),CupStatus[ind]);
		if (ind > 0) {
			CostTextCups [ind - 1].SetActive (false);
		}	
	}
	public void SetToUsingCup(int ind){
		Cups [ind].GetComponentInChildren<Text> ().text = "Using";
		Cups [ind].GetComponent<Image>().sprite = UsingColor;
		CupStatus [ind] = 2;
		PlayerPrefs.SetInt ("Cup "+(ind+1).ToString(),CupStatus[ind]);
		if (ind > 0) {
			CostTextCups [ind - 1].SetActive (false);
		}	
	}

	public void SetToBuyWall(int ind){
		Walls [ind].GetComponentInChildren<Text> ().text = "Buy";
		Walls [ind].GetComponent<Image>().sprite = BuyColor;
		WallStatus [ind] = 0;
		if (ind > 0) {
			CostTextWalls [ind - 1].SetActive (true);
		}	
	}
	public void SetToUseWall(int ind){
		Walls [ind].GetComponentInChildren<Text> ().text = "Use";
		Walls [ind].GetComponent<Image>().sprite = UseColor;
		WallStatus [ind] = 1;
		PlayerPrefs.SetInt ("Wall "+(ind+1).ToString(),WallStatus[ind]);
		if (ind > 0) {
			CostTextWalls [ind - 1].SetActive (false);
		}	
	}
	public void SetToUsingWall(int ind){
		Walls [ind].GetComponentInChildren<Text> ().text = "Using";
		Walls [ind].GetComponent<Image>().sprite = UsingColor;
		WallStatus [ind] = 2;
		PlayerPrefs.SetInt ("Wall "+(ind+1).ToString(),WallStatus[ind]);
		if (ind > 0) {
			CostTextWalls [ind - 1].SetActive (false);
		}	
	}
}
