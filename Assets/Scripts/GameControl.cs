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

	private int scoreCount;
	private Animator scoreAnim;
	private GameObject book;
	private GameObject player;

	// Use this for initialization
	void Awake () 
	{
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}

		book = GameObject.Find ("Goal");
		player = GameObject.Find ("Player");
		scoreAnim = scoreBar.GetComponent<Animator> ();
		scoreCount = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (gameOver == true && Input.GetKeyDown (KeyCode.X)) 
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
		scoreCount++;
	}

	public void PlayerAttacked()
	{
		scoreCount = 0;
		scoreAnim.SetTrigger ("Attack");
		if (book.transform.position.y < player.transform.position.y + 1f && book.transform.position.y > player.transform.position.y - 1f) {
			print ("YOU WIN!");
			SceneManager.LoadScene ("WinScreen");
		}
	}

	public void PlayerDied()
	{
		gameOver = true;
		SceneManager.LoadScene ("EndScreen");
	}

	public int GetScoreCount()
	{
		return scoreCount;
	}
}
