using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.VR; // you need this line to use Unity's VR functions

public class NativeVRInput : MonoBehaviour {

	public Transform leftHand, rightHand; // assign in Inspector

	void Update () {
		// sync leftHand cube with VR data for leftHand
		leftHand.position = InputTracking.GetLocalPosition( VRNode.LeftHand );
		leftHand.rotation = InputTracking.GetLocalRotation( VRNode.LeftHand );
		// sync rightHand cube with VR data for rightHand
		rightHand.position = InputTracking.GetLocalPosition( VRNode.RightHand );
		rightHand.rotation = InputTracking.GetLocalRotation( VRNode.RightHand );

	}
}
