using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneByClick : MonoBehaviour {

	private Animator anim;

	void Start()
	{
		anim = GetComponent<Animator> ();
	}
	public void LoadByIndex(int sceneIndex)
	{
		anim.SetTrigger ("Pressed");
		SceneManager.LoadScene (sceneIndex);
	}
}
