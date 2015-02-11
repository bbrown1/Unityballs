﻿/// <summary>
/// InputManager.cs
/// Authors: Kyle Dawson, [ANYONE ELSE WHO MODIFIES CODE PUT YOUR NAME HERE]
/// Date Created:  Feb. 11, 2015
/// Last Revision: Feb. 11, 2015
/// 
/// Class that handles all game input.
/// 
/// NOTES: - Should probably be attached to GameMaster object.
/// 
/// TO DO: - Allow customizable keys.
/// 
/// </summary>

using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	// Variables
	#region Variables
	public GameMaster gm;		// Reference to Game Master.

	public KeyCode forward;		// Which key moves the marble forward.
	public KeyCode backward;	// Which key moves the marble backward.
	public KeyCode left;		// Which key moves the marble left.
	public KeyCode right;		// Which key moves the marble right.
	public KeyCode jump;		// Which key makes the marble jump.

	public KeyCode camUp;		// Which key moves the camera upwards.
	public KeyCode camDown;		// Which key moves the camera downwards.
	public KeyCode camLeft;		// Which key moves the camera left.
	public KeyCode camRight;	// Which key moves the camera right.
	public KeyCode camToggle;	// Which key toggles the camera control mode.

	public KeyCode pause;		// Which key pauses the game.
	public KeyCode brake;		// Which key brakes the marble.
	public KeyCode respawn;		// Which key respawns the marble.

	#endregion

	// Awake - Called before anything else. Use this to find the Game Master and tell it this exists.
	void Awake () {
		gm = GameMaster.CreateGM();
	}

	// Start - Use this for initialization
	void Start () {

		// DEFAULT CONTROLS - SHOULD BE READ EXTERNALLY OR SOMETHING LATER
		forward = KeyCode.W;
		backward = KeyCode.S;
		left = KeyCode.A;
		right = KeyCode.D;
		jump = KeyCode.Space;
		camUp = KeyCode.UpArrow;
		camDown = KeyCode.DownArrow;
		camLeft = KeyCode.LeftArrow;
		camRight = KeyCode.RightArrow;
		camToggle = KeyCode.C;
		pause = KeyCode.Escape;
		brake = KeyCode.B;
		respawn = KeyCode.R;
	}
	
	// Update - Called once per frame.
	void Update () {
		// These controls are active during gameplay.
		if (gm.state == GameMaster.GameState.Playing) {
			// These controls are relevant to moving the camera when the camera is in keyboard mode.
			if (gm.cam.GetComponent<CameraController>().mode == CameraController.ControlMode.Keyboard) {
				// Move up.
				if (Input.GetKey(camUp)) {
					gm.cam.GetComponent<CameraController>().MoveUp();
				}
				// Move down.
				if (Input.GetKey(camDown)) {
					gm.cam.GetComponent<CameraController>().MoveDown();
				}
				// Move left.
				if (Input.GetKey(camLeft)) {
					gm.cam.GetComponent<CameraController>().MoveLeft();
				}
				// Move right.
				if (Input.GetKey(camRight)) {
					gm.cam.GetComponent<CameraController>().MoveRight();
				}
			}
			// Toggle whether the keyboard or mouse control the camera.
			if (Input.GetKeyDown(camToggle)) {
				gm.cam.GetComponent<CameraController>().ToggleControlMode();
			}

			// Toggles the game being paused.
			if (Input.GetKeyDown(pause)) {
				gm.TogglePause();
			}

			// As long as the game isn't paused, these controls handle marble movement and positioning.
			if (!gm.paused) {
				// Forward movement.
				if (Input.GetKey(forward)) {
					gm.marble.GetComponent<Marble>().Forward();
				}
				// Backward movement.
				if (Input.GetKey(backward)) {
					gm.marble.GetComponent<Marble>().Backward();
				}
				// Leftwards movement.
				if (Input.GetKey(left)) {
					gm.marble.GetComponent<Marble>().Left();
				}
				// Rightwards movement.
				if (Input.GetKey(right)) {
					gm.marble.GetComponent<Marble>().Right();
				}
				// Jumping.
				if (Input.GetKeyDown(jump)) {
					gm.marble.GetComponent<Marble>().Jump();
				}
				// Braking.
				if (Input.GetKey(brake)) {
					gm.marble.GetComponent<Marble>().Brake();
				}
				// Respawning.
				if (Input.GetKeyDown (respawn)) {
					gm.marble.GetComponent<Marble>().Respawn();
				}
			}
		}
	}
}
