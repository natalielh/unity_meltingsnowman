using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBehavior : MonoBehaviour {

	private float fishPushForce = 20;
	private float fishJumpForce = 20;

	private Rigidbody boatRb;
	private Rigidbody fishRb;

	void Start () {

		boatRb = GameObject.Find("boating_02").GetComponent<Rigidbody>();
		fishRb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update () {

		transform.Rotate(Vector3.forward * 500.0f * Time.deltaTime);

	}

	void OnCollisionEnter (Collision target) {
		
		// if the fish collider hits the boat collider
		if (target.gameObject.tag.Equals("Boat") == true) {

			// immediately push the boat backward
			boatRb.AddForce(-Vector3.forward * fishPushForce, ForceMode.Impulse);
			//shoot the fish up (hahaah)
			fishRb.AddForce(Vector3.up * fishJumpForce, ForceMode.Impulse);
		}

	}

}
