using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI; // we need this line here to talk to our UI Image

public class TimedGaze : MonoBehaviour {

	public Image progressImage; // assign this in the Inspector!

	Transform lastThingWeLookedAt; // will remember the last thing we looked at
	float timeLookedAt = 0f;
	
	// Update is called once per frame
	void Update () {
		// STEP 1: define a "Ray" object, which consists of "origin" and a "direction"
		Ray myRay = new Ray( Camera.main.transform.position, Camera.main.transform.forward );

		// STEP 2: specify how far to shoot the raycast
		float myRaycastDistance = 10f; // for this, you'll usually want to keep this closer than further

		// STEP 3: visualize the ray (optional, but you should do it)
		Debug.DrawRay( myRay.origin, myRay.direction * myRaycastDistance, Color.yellow );

		// STEP 4: declare a RaycastHit variable, to keep all our data in it
		RaycastHit myRayHit = new RaycastHit(); // "allocate memory" for later

		// STEP 5: shoot our raycast!
		if( Physics.Raycast( myRay, out myRayHit, myRaycastDistance ) ) {
			// print in console if the raycast worked?
			Debug.Log( "raycast hit " + myRayHit.collider.name );

			// for testing purposes right now: grow in size as long as we're looking at it
			// myRayHit.transform.localScale += Vector3.one * Time.deltaTime; // increase size
			lastThingWeLookedAt = myRayHit.transform;

			timeLookedAt += Time.deltaTime; // e.g., after 1 second, this be 1

			if( timeLookedAt >= 1f ) { // if we've looked at it for 1 second...
				lastThingWeLookedAt.localScale *= 2f; // then double in size
				timeLookedAt = 0f; // reset look time, or else it'll keep doubling over and over
			}

		} else {
			// everything in this "else" happens if the raycast fails
			if( lastThingWeLookedAt != null ) {
				if( lastThingWeLookedAt.localScale.x > 1f ) { // is the thing still too big
					lastThingWeLookedAt.localScale -= Vector3.one * Time.deltaTime; // shrink size
				}
			}

			// if we're not looking at it, decay "timeLookedAt" value
			timeLookedAt = Mathf.Clamp( timeLookedAt - Time.deltaTime, 0f, 1f );
		}

		progressImage.fillAmount = timeLookedAt; // always update the UI Image with timeLookedAt

		// simple but buggy mouse look, just  to test stuff
		Camera.main.transform.Rotate( -Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0f );
	}
}
