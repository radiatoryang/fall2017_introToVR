using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// put this script on our trigger
public class PlayerTrigger : MonoBehaviour {

	public ParticleSystem fireworks; // don't forget: assign in inspector!

	// automatically fires when the Player Vehicle object enters this trigger
	void OnTriggerEnter ( Collider activator ) {
		fireworks.Play(); // start the fireworks!

	}

}
