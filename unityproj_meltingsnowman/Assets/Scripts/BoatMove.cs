using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMove : MonoBehaviour {

	public float rotSpeed = 0.2f;
	// public float boatSpeed = 5.0f;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

		if (Input.anyKey) { // keep checking if a key is held down
			
			// rotate around y-axis when the button is held
			transform.Rotate (0.0f, Input.GetAxis ("Horizontal") * rotSpeed * Time.deltaTime, 0.0f);

			// move forward
			// transform.Translate (Vector3.forward * Input.GetAxis("Vertical") * boatSpeed * Time.deltaTime);

		}
	}
}
