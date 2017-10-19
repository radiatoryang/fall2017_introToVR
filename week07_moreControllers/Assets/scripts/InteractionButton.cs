using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Valve.VR.InteractionSystem;

public class InteractionButton : MonoBehaviour {

	// will happen automatically, every frame, as long as a Hand is touching it
	void HandHoverUpdate (Hand hand) {
		// is the player pulling the trigger on this Hand?
		if( hand.GetStandardInteractionButtonDown() ) {
			Debug.Log( "button pressed!" );
			// for debug purposes, destroy myself (the button) when it's pressed
			Destroy( this.gameObject );
		}
	}

	// if you make a function "public void", that means UnityEvents can talk to it
	// for example, like in InteractionButtonEvents script
	public void DestroyThisButton () {
		Debug.Log( "something happened!" );
		Destroy( this.gameObject );
	}

}
