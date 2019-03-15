using UnityEngine;
using System.Collections;

public class AI_PlayerController : MonoBehaviour {
	public float speed=1000;
	Vector3 GoTo;
	GameObject closest;
	void Start(){
		GameObject closest = transform.gameObject;
	}
	void Update () {
		GoTo.y = transform.position.y;
		GoTo.z = transform.position.z;
		GoTo.x = FindClosest ().transform.position.x;
		transform.position = Vector3.MoveTowards(transform.position, GoTo, speed * Time.deltaTime);
	}
	GameObject FindClosest() {
		GameObject[] gos;
		gos = GameObject.FindObjectsOfType<GameObject> ();
		float distance = -1f;
		Vector3 position = transform.position;
		foreach (GameObject go in gos) {
			float curDistance = Vector3.Distance (go.transform.position, position);
			if ((curDistance < distance || distance == -1) && (go.tag != "Destructor" && go.tag != "Paparia" && go.tag!= "Player")) {
				closest = go;
				distance = curDistance;
			}
		}
	//	Debug.Log (closest);
		return closest;
	}
}
