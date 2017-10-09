using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingItems : MonoBehaviour {

	public int speed;

	private GameObject leftItems;
	private GameObject rightItems;
	private RectTransform leftItemsTransform;
	private bool continueMoving;

	// Use this for initialization
	void Start () 
	{
		leftItems = GameObject.Find ("LeftSideItems");
		rightItems = GameObject.Find ("RightSideItems");
		rightItems.SetActive (false);
		leftItemsTransform = leftItems.GetComponent<RectTransform> ();
		continueMoving = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (continueMoving) 
		{
			leftItemsTransform.anchoredPosition += new Vector2 (speed * Time.deltaTime, 0);
		}
		if (leftItemsTransform.anchoredPosition.x <= -250)
		{
			continueMoving = false;
			rightItems.SetActive (true);
		}
	}
}
