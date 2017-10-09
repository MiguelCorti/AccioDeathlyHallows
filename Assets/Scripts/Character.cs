/*
	Accio Deathly Hallows
    Copyright (C) 2017  Sibling Games

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	public float minForce;
	public float maxForce;
	public float acceleration;
	public float deceleration;

	private float upForce;
	private bool isDead;
	private Rigidbody2D rb2d;
	private Animator anim;
	private int maxScoreCount;

	// Use this for initialization
	void Start () {
		isDead = false;
		upForce = minForce;
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		maxScoreCount = 8;
	}

	// Update is called once per frame
	void Update () {

		if (isDead == false) {

			if (Input.GetKeyDown (KeyCode.X)) {
				rb2d.velocity = Vector2.zero;
				if (upForce < maxForce) {
					upForce = upForce + (acceleration * Time.deltaTime);
				}

				rb2d.AddForce (new Vector2 (0, upForce));
				anim.SetTrigger ("Flap");
			} else {
				upForce = upForce - (deceleration * Time.deltaTime);
				if (upForce < minForce) {
					upForce = minForce;
				}
			}

			if (Input.GetKeyDown (KeyCode.V)) 
			{
				anim.SetTrigger ("Attack");
				if (GameControl.instance.GetScoreCount () > maxScoreCount) {
					GameControl.instance.PlayerAttacked ();
				}
			}
		}
	}

	void OnCollisionEnter2D ()
	{
		rb2d.velocity = Vector2.zero;
		isDead = true;
		GameControl.instance.PlayerDied ();
	}
}
