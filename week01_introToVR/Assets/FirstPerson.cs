using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPerson : MonoBehaviour {

	// "public" exposes this variable to the Inspector as well as other scripts
	public float mouseSensitivity = 5f;

	// Update is called once per frame
	void Update () {
		// Input.GetAxis will return a float between -1f and 1f, and 0 if the mouse isn't moving
		float mouseX = Input.GetAxis( "Mouse X" ) * mouseSensitivity * Time.deltaTime; // horizontal mouse input
		float mouseY = Input.GetAxis( "Mouse Y" ) * mouseSensitivity * Time.deltaTime; // vertical mouse input
		// Time.deltaTime = the number in seconds between frames
		// 100 FPS = 0.01 dT.... 10 FPS = 0.1 dT
		// multiply things by Time.deltaTime to make it framerate independent

		// GetAxis refers to the current mouse velocity! not mousePosition!

		// rotate this object (camera) based on mouseDelta (mouse values)
		// "transform" refers to wherever we put this script
		transform.Rotate( -mouseY, mouseX, 0f);

		// un-roll the camera view
		// transform.eulerAngles.z = 0f; // THIS WILL NOT WORK, FOR BORING C# MEMORY REASONS
		// euler angles are like 0-360 degree angles
		transform.eulerAngles = new Vector3( transform.eulerAngles.x, transform.eulerAngles.y, 0f );

		// hide the mouse cursor and lock it in the middle of the screen
		if ( Input.GetMouseButton(0) ) { // 0 = left-click, 1 = right, 2 = middle, 3...
			Cursor.lockState = CursorLockMode.Locked; // lock cursor position to middle of the screen
			Cursor.visible = false; // hides the mouse cursor
		}

	}
}
