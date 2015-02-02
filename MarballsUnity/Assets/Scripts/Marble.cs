﻿/// <summary>
/// Marble.cs
/// Authors: Kyle Dawson, [ANYONE ELSE WHO MODIFIES CODE PUT YOUR NAME HERE]
/// Date Created:  Jan. 28, 2015
/// Last Revision: Jan. 28, 2015
/// 
/// Class that controls marble properties and actions.
/// 
/// TO DO:
/// 	- Tweak movement until desired.
/// 
/// </summary>

using UnityEngine;
using System.Collections;

public class Marble : MonoBehaviour {
	// Variables
	public float speedMultiplier = 10000f;	// How speedy the variety of marble should be.
	// public float weight;					// Weight may be nice for messing with gravity.


	// Start - Use this for initialization
	void Start () {
	
	}
	
	// Update - Called once per frame
	void Update () {
		// Currently, all of these controls are with respect to the world.
		// These should soon be changed to be with respect to the camera. Yay vector math.

		if (Input.GetKey (KeyCode.W)) {
			this.gameObject.rigidbody.AddTorque (Vector3.forward * speedMultiplier, ForceMode.Acceleration);
		}

		if (Input.GetKey (KeyCode.S)) {
			this.gameObject.rigidbody.AddTorque (Vector3.back * speedMultiplier, ForceMode.Acceleration);
		}

		if (Input.GetKey (KeyCode.A)) {
			this.gameObject.rigidbody.AddTorque (Vector3.left * speedMultiplier, ForceMode.Acceleration);
		}

		if (Input.GetKey (KeyCode.D)) {
			this.gameObject.rigidbody.AddTorque (Vector3.right * speedMultiplier, ForceMode.Acceleration);
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			this.gameObject.rigidbody.AddForce (0f, 200f, 0f);
		}
	}
}
