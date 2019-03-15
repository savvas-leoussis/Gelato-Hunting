using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public GameObject Manager;
	private GameManager gamemanager;
	public float limit;
	public float speed = 1000;
	public GameObject cube;
	private Vector3 velocity = Vector3.zero;
	Vector3 targetPosition;
	Vector3 posVec = new Vector3();
	int i=0;
	void Start () {
		targetPosition = transform.position;
		gamemanager = GameObject.Find("Game Manager").GetComponent<GameManager>();
	}
	void Update(){
		if (Input.GetMouseButtonDown (1)) {
			ScreenCapture.CaptureScreenshot ("Screenshot " + i.ToString ()+".png");
			i++;
			Debug.Log ("Screenshot " + i.ToString ());
		}
		if(gamemanager.isGameOver==false)
		{
			if (Input.GetMouseButton (0)) {
				posVec = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			}
			else if (Input.touchCount > 0) {
				posVec = Camera.main.ScreenToWorldPoint (Input.touches[0].position);
			}
			if (posVec.y < 1) {
				posVec.z = transform.position.z;
				posVec.y = transform.position.y;
				posVec.x = Boundary (posVec.x, limit);
			//	MovePosition (posVec);
			//	transform.position = Vector3.SmoothDamp (transform.position, posVec, ref velocity, Time.deltaTime/speed);
				transform.position = Vector3.MoveTowards(transform.position, posVec, speed * Time.deltaTime);  
			}
		}
	}
	float Boundary (float input, float limit){
		if (input > limit) {
			return limit;
		} else if (input < -limit) {
			return -limit;
		}
		else {
			return input;
		}
	}
}
