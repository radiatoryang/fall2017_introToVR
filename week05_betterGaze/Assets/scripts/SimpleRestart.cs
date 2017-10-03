using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// let's us access scene manager, to load / reload scenes
using UnityEngine.SceneManagement;

public class SimpleRestart : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		// if user presses R...
		if( Input.GetKeyDown( KeyCode.R ) ) {
			// ... then reload the current scene, by finding out the current scene and reloading it
			SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex );
			// DON'T FORGET: don't forget to disable "Auto-Generate" lighting in Lighting settings!
		}
	}
}
