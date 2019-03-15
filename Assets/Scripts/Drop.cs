using UnityEngine;
using System.Collections;

public class Drop : MonoBehaviour {
	public float speed = 1.0f;
	void Update () {
		transform.position -= Vector3.up * Time.deltaTime * speed;
	}
}