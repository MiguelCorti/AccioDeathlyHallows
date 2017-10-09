using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextNoises : MonoBehaviour {
	public GameObject[] noisesPrefabs;

	private int noiseChosen;
	private GameObject currentNoise;

	// Use this for initialization
	void Start () 
	{
		noiseChosen = Random.Range (0, 2);
		currentNoise = Instantiate (noisesPrefabs[noiseChosen], Vector2.zero, Quaternion.identity);
		currentNoise.transform.parent = gameObject.transform;
		currentNoise.GetComponent<RectTransform> ().anchoredPosition = Vector2.zero;
	}

}
