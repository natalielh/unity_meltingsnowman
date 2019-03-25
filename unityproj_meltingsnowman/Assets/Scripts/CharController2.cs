using UnityEngine;
using System.Collections;

public class CharController2 : MonoBehaviour {

	public float speed = 2.0f;
	Vector3 playerMovement = new Vector3();

	// Use this for initialization
	void Start ()
	{
		Cursor.lockState = CursorLockMode.Locked;
	}

	// Update is called once per frame
	void Update ()
	{
		playerMovement = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical"));
		//// old code
		// float translation = Input.GetAxis ("Vertical") * speed;
		// float strafe = Input.GetAxis ("Horizontal") * speed;
		// translation *= Time.deltaTime;
		// strafe *= Time.deltaTime;

		// normalize the movement vector
		playerMovement.Normalize ();

		// apply the translation, after multiplying with speed and deltaTime
		transform.Translate (playerMovement.x * speed * Time.deltaTime, 0f, playerMovement.z * speed * Time.deltaTime);

		if (Input.GetKeyDown ("escape")) {
			Cursor.lockState = CursorLockMode.None;
		}
	}

}