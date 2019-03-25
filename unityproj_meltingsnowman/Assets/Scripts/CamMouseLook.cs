using UnityEngine;
using System.Collections;

public class CamMouseLook : MonoBehaviour {

	Vector2 mouseLook;
	Vector2 smoothV; // smoothing vector to smooth the movement
	public float hsens = 2.0f;
	public float vsens = 1.0f;
	public float smoothing = 1.0f;

	GameObject character;

	// Use this for initialization
	void Start ()
	{
		character = this.transform.parent.gameObject;
		Cursor.lockState = CursorLockMode.Locked;
	}

	// Update is called once per frame
	void Update ()
	{
		var mouseDelta = new Vector2 (Input.GetAxisRaw ("Mouse X"), Input.GetAxisRaw ("Mouse Y"));

		mouseDelta = Vector2.Scale (mouseDelta, new Vector2(hsens * smoothing, vsens * smoothing));
		smoothV.x = Mathf.Lerp (smoothV.x, mouseDelta.x, 1.0f / smoothing);
		smoothV.y = Mathf.Lerp (smoothV.y, mouseDelta.y, 1.0f / smoothing);
		mouseLook += smoothV;

		// clamp looking up and down
		mouseLook.y = Mathf.Clamp (mouseLook.y, -90.0f, 90f);

		// when you rotate along the "right" axis u are rotating around the x-axis which moves camera up and down
		// when you rotate along the "up" axis u are rotating around the y-axis which moves camera left and right
		transform.localRotation = Quaternion.AngleAxis (-mouseLook.y, Vector3.right); // the "-" sign in front of mouselook.y inverts the movement
		character.transform.localRotation = Quaternion.AngleAxis (mouseLook.x, character.transform.up);


		if (Input.GetKeyDown ("escape")) {
			Cursor.lockState = CursorLockMode.None;
		}


	}
}
