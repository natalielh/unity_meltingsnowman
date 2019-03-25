using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour {

	public float rotationSpeed = 200.0f;
	public float boatSpeed = 100.0f;
	public float slowness = 0.25f;
	public Rigidbody rb;

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody> ();

	}
	
	// Update is called once per frame
	void Update () {

		//// if a key is currently held down
		if (Input.anyKey) {

			/// ROTATION
			// if a key of the horizontal axis is currently held down
			// Input.GetAxisRaw() is always -1 or 0 or +1 and 0 means it's not activated
			if (Input.GetAxisRaw("Horizontal") != 0) {

				// rotate around y-axis when the button is held
				//transform.Rotate (0.0f, Input.GetAxis ("Horizontal") * rotationSpeed * Time.deltaTime, 0.0f);
				rb.AddTorque(transform.up * Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime);

			}
				

			/// FORWARD AND BACKWARD MOVEMENT
			// if a key of the vertical axis is currently held down
			// if this key holding means 'go backward'
			if (Input.GetAxis ("Vertical") < 0)
			{
				// do the move with the slowness factor multiplied to the force vector
				//transform.Translate (Vector3.forward * Input.GetAxis ("Vertical") * boatSpeed * slow * Time.deltaTime);
				rb.AddForce(transform.forward * Input.GetAxis("Vertical") * boatSpeed * slowness * Time.deltaTime);
			}
			// if a key of the vertical axis is currently held down
			// if this key holding means 'go forward'
			else if (Input.GetAxis("Vertical") >= 0)
			{
				// move forward
				// transform.Translate (Vector3.forward * Input.GetAxis("Vertical") * boatSpeed * Time.deltaTime);
				rb.AddForce(transform.forward * Input.GetAxis("Vertical") * boatSpeed * Time.deltaTime);
			}

		} ////

	}
}
