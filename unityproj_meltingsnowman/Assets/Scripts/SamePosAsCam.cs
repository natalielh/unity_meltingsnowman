using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamePosAsCam : MonoBehaviour {

	Vector3 campos = new Vector3();

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

		campos = Camera.main.transform.position;

		transform.position = new Vector3(campos.x, 0, campos.z);
	}
}
