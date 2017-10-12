using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeFollow : MonoBehaviour {

	public Transform sphere;
	
	// Update is called once per frame
	void Update () {
		// define the camera's gaze as a Ray
		Ray lookRay = new Ray( Camera.main.transform.position, Camera.main.transform.forward );
		// define how far the raycast should be able to go
		float maxLookDistance = 50f;
		// setup a blank "RaycastHit" variable for later
		RaycastHit lookRayHit = new RaycastHit();

		// visualize the Raycast
		Debug.DrawRay( lookRay.origin, lookRay.direction * maxLookDistance, Color.yellow );

		// let's actually shoot the Raycast!
		if( Physics.Raycast( lookRay, out lookRayHit, maxLookDistance ) ) {
			// visualize where the Raycast Hit something
			Debug.DrawRay( lookRayHit.point, lookRayHit.normal, Color.magenta ); 

			// move the Sphere towards the RaycastHit point
			sphere.position = Vector3.MoveTowards( sphere.position, lookRayHit.point, 5f * Time.deltaTime );
		}

	}

}
