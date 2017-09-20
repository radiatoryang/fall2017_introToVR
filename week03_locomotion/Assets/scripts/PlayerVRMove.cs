using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// IMPORTANT: do not put this script on your Main Camera!
// instead, you must parent your Main Camera to a "Camera Rig" or "Vehicle" object,
// and then use code to move/rotate THAT parent object around
public class PlayerVRMove : MonoBehaviour {

	public float speed = 5f;
	
	// Update is called once per frame
	void Update () {

		// is the player holding down the spacebar?
		if( Input.GetKey( KeyCode.Space ) ) {
			// first, see in what direction the player is looking
			Vector3 lookDirection = Camera.main.transform.forward;
			// this lookDirection is in "world space"

			// move ourselves forward based on that direction
			// either of these lines below works
			// transform.Translate( lookDirection, Space.World ); // Translate normally uses "local space"
			// transform.position += lookDirection * speed * Time.deltaTime;

			// ONE BIG PROBLEM WITH USING transform.Translate / transform.position
			// IS THAT IT DOESN'T DO ANY COLLISION DETECTION FOR MOVEMENT

			// if you *do* want collisions, you have to use "CharacterController.Move()"
			GetComponent<CharacterController>().Move( lookDirection * speed * Time.deltaTime );
		}

	}

}
