using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Valve.VR.InteractionSystem; // we need this to talk to Hands

// put this script on a Hand; talk to the Hand to get more controller data
public class MoreHandInput : MonoBehaviour {

	Hand myHand;
	SteamVR_Controller.Device myController { get { return myHand.controller; } }

	// Use this for initialization
	void Start () {
		myHand = GetComponent<Hand>();
	}
	
	// Update is called once per frame
	void Update () {
		if( myController != null ) { // is the controller connected?
			// am I pulling my Analog Stick or Touchpad toward the right?
			if( myController.GetAxis( Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad ).x > 0.5f ) {
				Debug.Log( "right!" );
			}
		}
	}
}
