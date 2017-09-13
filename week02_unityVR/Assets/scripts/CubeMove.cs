using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour {

	Vector3 destination; // this will remember where we want this cube to move

	void Update () {
		// tell the cube to move towards its destination
		transform.position = Vector3.MoveTowards( transform.position, destination, Time.deltaTime * 5f);
		// if I multiply Time.deltaTime by 5, that's like saying "move 5 meters / second"

		// are we within 1 meter of our destination?
		if( Vector3.Distance( transform.position, destination ) < 1f ) {
			// if so, pick a new destination
			destination = new Vector3( 
				Random.Range(-10f, 10f), // random x coordinate
				Random.Range(-10f, 10f), // random y coordinate
				Random.Range(-10f, 10f)  // random z coordinate
			);
		}
	}
}
