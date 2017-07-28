using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

	public static GameControl instance;
	public GameObject scoreBar; 
	public bool gameOver = false;
	public float scrollSpeed = -1.5f;

	private Animator scoreAnim;

	// Use this for initialization
	void Awake () 
	{
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}

		scoreAnim = scoreBar.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (gameOver == true && Input.GetMouseButtonDown (0)) 
		{
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}
	}

	public void PlayerScored()
	{
		if (gameOver) 
		{
			return;
		}

		scoreAnim.SetTrigger ("Scores");
	}

	public void PlayerDied()
	{
		gameOver = true;
	}
}
