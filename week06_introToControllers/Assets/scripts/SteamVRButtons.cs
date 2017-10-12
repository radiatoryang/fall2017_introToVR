using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PUT THIS SCRIPT ON YOUR CONTROLLER GAMEOBJECT
public class SteamVRButtons : MonoBehaviour {

	SteamVR_TrackedObject myTrackedObject;

	// this is a "property"
	// a variable that can run extra code when you read or write to it
	SteamVR_Controller.Device myController { 
		// we want to do it this way because the controllers might change connections / etc
		// during the game, so we want to get a fresh connection each time
		get { 
			return SteamVR_Controller.Input( (int)myTrackedObject.index );
		}
	}

	// Use this for initialization
	void Start () {
		myTrackedObject = GetComponent<SteamVR_TrackedObject>();

	}
	
	// Update is called once per frame
	void Update () {

		// is the player press the trigger?
		if( myController.GetHairTriggerDown() ) {
			// if so, shoot a bullet, etc.

		}

		// get a button manually... e.g., holding down Grip button...
		if( myController.GetPress( Valve.VR.EVRButtonId.k_EButton_Grip ) ) {
			// if so, pick up a nearby object

		}

		// myController.GetAxis( Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger );

	}
}
