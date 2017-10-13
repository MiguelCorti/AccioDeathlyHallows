using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EraseOnStart : MonoBehaviour {

	private GameObject tutorialText;

	// Use this for initialization
	void Start () 
	{
		tutorialText = GameObject.Find ("Tutorial Text");

		GameControl.instance.PauseGame (true);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.X)) 
		{
			Destroy (tutorialText);
			GameControl.instance.PauseGame (false);
			GameControl.instance.SetCanPause (true);
		}

		if (transform.position.x < -15) {
			Destroy (gameObject);
		}
	}
}
