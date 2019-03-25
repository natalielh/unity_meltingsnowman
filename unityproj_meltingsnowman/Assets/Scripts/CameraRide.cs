using UnityEngine;
using System.Collections;

public class CameraRide : MonoBehaviour {

	public float speed = 10.0f;
	bool waterSceneActive = false;

	void Start () {

		waterSceneActive = true;
		
	}


	// Update is called once per frame
	void Update () {

		if (waterSceneActive == true) {
			transform.Translate (Vector3.forward * speed * Time.deltaTime);
		}
	
	}
}
