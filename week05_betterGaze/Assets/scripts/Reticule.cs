using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reticule : MonoBehaviour {

	public Transform myReticule;
	
	// Update is called once per frame
	void Update () {
		
		Ray ray = new Ray( Camera.main.transform.position, Camera.main.transform.forward );
		RaycastHit rayHit = new RaycastHit();
		float maxRayDistance = 10f;

		Debug.DrawRay( ray.origin, ray.direction * maxRayDistance, Color.yellow );

		if( Physics.Raycast( ray, out rayHit, maxRayDistance ) ) {
			// "RaycastHit.point" = world position where it hit
			myReticule.position = rayHit.point + rayHit.normal * 0.01f; // add "rayHit.normal * 0.01f" to prevent Z-fighting
			// "RaycastHit.normal" = surface normal where it hit
			myReticule.forward = rayHit.normal; // make the reticle point along the surface direction
		}
	}
}
