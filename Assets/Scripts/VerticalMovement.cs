using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovement : MonoBehaviour {

	public float maxPositionY;
	public float speed;

	private bool goingUp;

	// Use this for initialization
	void Start () {
		goingUp = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (goingUp) {
			transform.Translate (transform.up * speed * Time.deltaTime);
		} else {
			transform.Translate (-transform.up * speed * Time.deltaTime);
		}

		if (transform.position.y > maxPositionY) {
			goingUp = false;
		} else if (transform.position.y < -maxPositionY) {
			goingUp = true;
		}
	}
}
