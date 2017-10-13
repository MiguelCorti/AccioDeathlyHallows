using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

	public Camera cam;

	void Update()
	{
		Vector3 screenPos = cam.WorldToScreenPoint(transform.position);
		if (screenPos.x < -1f) {
			setNewPosition ();
		}
	}

	private void OnTriggerEnter2D (Collider2D other)
	{
		if(other.GetComponent<Character> () != null)
		{
			GameControl.instance.PlayerScored ();
			setNewPosition ();
		}
	}

	void setNewPosition ()
	{
		float newPositionY = Random.Range (-2f, 2f);
		float newPositionX = Random.Range (25f, 30f);
		Vector3 target = new Vector3 (newPositionX, newPositionY, 1);
		transform.position = Vector3.MoveTowards (transform.position, target, 30f);
	}
}