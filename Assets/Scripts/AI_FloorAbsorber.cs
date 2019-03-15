using UnityEngine;
using System.Collections;

public class AI_FloorAbsorber : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D other){
		Destroy (other.transform.root.gameObject);
	}
}