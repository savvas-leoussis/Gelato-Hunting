using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ToggleSelection : MonoBehaviour {
	public Button Cups;
	public Button Walls;
	public GameObject CupsMenu;
	public GameObject WallsMenu;
	public void SelectWalls(){
		Cups.interactable = true;
		Walls.interactable = false;
		CupsMenu.SetActive (false);
		WallsMenu.SetActive (true);
	}
	public void SelectCups(){
		Cups.interactable = false;
		Walls.interactable = true;
		CupsMenu.SetActive (true);
		WallsMenu.SetActive (false);
	}
}