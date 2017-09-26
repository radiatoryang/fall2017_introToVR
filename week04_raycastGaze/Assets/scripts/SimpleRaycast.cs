using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRaycast : MonoBehaviour {

	public Transform cube, sphere;
	
	// Update is called once per frame
	void Update () {
		// STEP 1: build our "Ray" object, based on the cube's transform
		Ray myRay = new Ray( cube.position, cube.forward );
		// "cube.forward" refers to the cube's local Z axis (blue)

		// STEP 2: declare the raycast distance
		float myRaycastDistance = 5f;

		// STEP 3: (optional, but recommended:) visualize the ray in your Scene view
		Debug.DrawRay( myRay.origin, myRay.direction * myRaycastDistance, Color.yellow );

		// STEP 4: shoot our raycast now?
		if( Physics.Raycast( myRay, myRaycastDistance ) ) { // TRUE == the raycast hit a collider
			Debug.Log( "raycast hit something!" );
			cube.Rotate( 0f, 1f, 0f ); // rotate the cube away
		}
	}
}
