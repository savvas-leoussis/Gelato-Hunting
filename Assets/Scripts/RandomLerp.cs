using UnityEngine;
using System.Collections;

public class RandomLerp : MonoBehaviour 
{
	Vector3 temp;
	public float speed;
	public float seconds;
	private float x=0;
	private float y=0;
	private bool changedirection = true;
	void Start() {
		InvokeRepeating ("Move", 0, seconds);
	}
	void Move(){
		x = Random.Range (-1, 1);
		y = Random.Range (-1, 1);
		while (x == 0 && y == 0) {
			x = Random.Range (-1, 1);
			y = Random.Range (-1, 1);
		}
		if (changedirection) {
			temp = new Vector2 (x, y).normalized*speed;
			GetComponent<Rigidbody2D> ().velocity = temp;
			changedirection = !changedirection;
		}
		else {
			GetComponent<Rigidbody2D> ().velocity = -temp;
			changedirection = !changedirection;
		}
	}
}

