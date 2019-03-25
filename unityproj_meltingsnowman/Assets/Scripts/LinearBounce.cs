using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearBounce : MonoBehaviour {

	public float ampModX = 1.0f;
	public float ampModY = 1.0f;
	public float ampModZ = 1.0f;

	public float pdModX = 1.0f;
	public float pdModY = 1.0f;
	public float pdModZ = 1.0f;

	public bool xwobble = false;
	public bool ywobble = false;
	public bool zwobble = false;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		if(xwobble) {
			transform.Translate (Vector3.right * ampModX * Mathf.Sin(Time.realtimeSinceStartup * pdModX) * Time.deltaTime);
		}
		if (ywobble) {
			transform.Translate (Vector3.up * ampModY * Mathf.Sin(Time.realtimeSinceStartup * pdModY) * Time.deltaTime);
		}
		if (zwobble) {
			transform.Translate (Vector3.forward * ampModZ * Mathf.Sin(Time.realtimeSinceStartup * pdModZ) * Time.deltaTime);
		}

		// transform.Rotate (Vector3.forward, ampMod * Mathf.Sin(Time.realtimeSinceStartup) * Time.deltaTime);
	}
}
