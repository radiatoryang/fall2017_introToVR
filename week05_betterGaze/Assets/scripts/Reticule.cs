using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reticule : MonoBehaviour {

	public Transform myReticule;

	Vector3 startScale; // remember initial scale of UI Canvas, to scale it up later based on distance

	void Start () {
		startScale = myReticule.localScale; // remember the scale of my UI Canvas
	}
	
	// Update is called once per frame
	void Update () {
		
		Ray ray = new Ray( Camera.main.transform.position, Camera.main.transform.forward );
		RaycastHit rayHit = new RaycastHit();
		float maxRayDistance = 100f;

		Debug.DrawRay( ray.origin, ray.direction * maxRayDistance, Color.yellow );

		if( Physics.Raycast( ray, out rayHit, maxRayDistance ) ) {
			// "RaycastHit.point" = world position where it hit
			myReticule.position = rayHit.point + rayHit.normal * 0.01f; // add "rayHit.normal * 0.01f" to prevent Z-fighting
			// "RaycastHit.normal" = surface normal where it hit
			// myReticule.forward = rayHit.normal; // make the reticle point along the surface direction

			// what if you only wanted a 2D "constant" reticule?
			myReticule.forward = -Camera.main.transform.forward;


			// make sure the Reticule gets bigger if it's further away
			myReticule.localScale = startScale * rayHit.distance;
		} else {
			// didn't raycast against anything, so move back to default distance; further away is better than too close
			myReticule.position = ray.origin + ray.direction * maxRayDistance;
			myReticule.LookAt( Camera.main.transform ); // another way of making it look at Camera
		}
	}
}
