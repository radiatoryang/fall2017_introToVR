using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Valve.VR.InteractionSystem; // we need this line to talk to the Hand

// put this script on a Hand
public class InteractionSystemInput : MonoBehaviour {

	Hand hand;

	// Use this for initialization
	void Start () {
		hand = GetComponent<Hand>();
	}

	void Update () {
		// is the user holding down the trigger on this Hand?
		if( hand.GetStandardInteractionButton() ) {
			// if so, shoot a gun or spawn a doggy treat, etc.

		}

		// we can also see how fast / direction the hand is moving, if we wanted to?
		Debug.Log( hand.GetTrackedObjectVelocity() );

	}
}
