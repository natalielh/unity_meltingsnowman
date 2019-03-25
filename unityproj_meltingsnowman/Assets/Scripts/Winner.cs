using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Winner : MonoBehaviour {

	void OnCollisionEnter (Collision target) {

		// if the win collider hits the boat collider
		if (target.gameObject.tag.Equals("Boat") == true) {

			// load the win scene
			SceneManager.LoadScene(2);
			Cursor.lockState = CursorLockMode.None;

		}

	}

}
