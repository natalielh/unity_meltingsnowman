using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatForward : MonoBehaviour {

	public float boatSpeed = 5.0f;
	public float slow = 0.1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		// if you hold down any key
		if (Input.anyKey) {

			// if you're tryna move backward...
			if (Input.GetAxis ("Vertical") < 0)
			{
				// do the move but add goo to slow it down
				transform.Translate (Vector3.forward * Input.GetAxis ("Vertical") * boatSpeed * slow * Time.deltaTime);
			}
			else
			{
				// move forward
				transform.Translate (Vector3.forward * Input.GetAxis("Vertical") * boatSpeed * Time.deltaTime);	
			}


		}
		
	}
}
