using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// put this script on your Main Camera
public class GazeRaycast : MonoBehaviour {

	public LayerMask myRayHitMask; // edit in Inspector
	
	void Update () {
		// shoot a raycast based on the Main Camera's forward direction

		// STEP 1: make a Ray object
		Ray myRay = new Ray( transform.position, transform.forward );

		// STEP 2: declare the distance
		float myRayDistance = 20f; // only affect stuff 20 meters near us

		// STEP 3: visualize the Raycast
		Debug.DrawRay( myRay.origin, myRay.direction * myRayDistance, Color.yellow );

		// STEP 3.5: setup a RaycastHit object, to hold RaycastHit data
		RaycastHit myRayHit = new RaycastHit(); // this is just an empty container

		// STEP 4: shoot the Raycast
		if( Physics.Raycast( myRay, out myRayHit, myRayDistance, myRayHitMask ) ) {
			Debug.Log( "I'm looking at " + myRayHit.collider.name ); // the thing the raycast hit

			// we can now access anything on the collider that we hit (e.g. transform, gameObject)

			// let's smoothly rotate the spheres to look toward us
			myRayHit.transform.forward = Vector3.Lerp( 
				myRayHit.transform.forward,
				Vector3.Normalize( transform.position - myRayHit.transform.position ),
				Time.deltaTime * 5f
			);
		}


		// for testing purposes: code a simple mouse-look
		transform.Rotate( -Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0f );
	}
}
