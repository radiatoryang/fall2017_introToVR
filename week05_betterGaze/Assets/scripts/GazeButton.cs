using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeButton : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		// STEP 0: (possible optimization) is the button close enough? if not, don't bother doing anything else

		// STEP 1: is this object / button within the vision cone of the Main Camera?

		// first, get vector from camera toward the button
		Vector3 fromCameraToButton = transform.position - Camera.main.transform.position;
		// get the angle between my look direction vs. vector toward the button
		float distanceDegrees = Vector3.Angle( Camera.main.transform.forward, fromCameraToButton.normalized );
		// is that angle within our range? if so, then do stuff
		if( distanceDegrees < 20f ) {

			// STEP 2: fire a raycast to see if there is anything between the camera and this button
			// ("is anything occluding the field of view?")

			// construct Ray object
			Ray ray = new Ray( Camera.main.transform.position, fromCameraToButton.normalized );

			// determine how far the raycast should go
			float maxRayDistance = 50f;

			// construct a RaycastHit object
			RaycastHit rayHit = new RaycastHit();

			// debug: visualize the raycast in the Scene view
			Debug.DrawRay( ray.origin, ray.direction * maxRayDistance, Color.yellow );

			// actually shoot the raycast now
			if( Physics.Raycast( ray, out rayHit, maxRayDistance ) ) {
				// did this raycast actually hit the object?
				if( rayHit.transform == this.transform ) {
					transform.Rotate( 0f, 5f, 0f ); // DEBUG: if so, let's spin
				}
			} // end Physics.Raycast

		} // end distanceDegrees check

	} // end Update
}
