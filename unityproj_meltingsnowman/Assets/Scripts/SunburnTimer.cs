using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SunburnTimer : MonoBehaviour {

	//public GameObject MainCamera;

	//// internally these values are considered health, they decrease to zero over time
	/// on the GUI they are shown to be increasing to fill up your Burn Bar (tm).
	public float maxTime = 60.0f;
	public float timeLeft;
	//
	public float maxBurn = 15.0f; // amount of seconds you can go in the sun for
	public float currentBurn;
	public float burnSpeed = 200.0f; // max number of points player can be burned per second (this is in % of 100% of the bar)
	public float recoverSpeed = 3.0f; // recovered points per second
	////

	public float deltaFactor = 1.0f;

	public Slider burnMeter; // this is for the meter on the side that shows you how sunburned you are
	public Image sliderFill;
	private ColorCurvesManager colorCurvesManager;
	private UnityStandardAssets.ImageEffects.BloomOptimized bloom;

	// Use this for initialization
	void Start () {

		bloom = GetComponent<UnityStandardAssets.ImageEffects.BloomOptimized>();
		colorCurvesManager = GetComponent<ColorCurvesManager>();
		sliderFill = GetComponent<Image>();

		timeLeft = maxTime;
		currentBurn = maxBurn;

		burnMeter.maxValue = 100.0f;
		burnMeter.minValue = 0.0f;

	}

	// Update is called once per frame
	void Update () {

		if (currentBurn >= 0) { //// if the player is not fully roasted yet (a currentBurn value of 0 means fully burned)

			if (Physics.Raycast (transform.position, Vector3.up, Mathf.Infinity) == true) {

				// if player IS in the shade
				// if the player IS somewhat burned (lol!)

				if (currentBurn < maxBurn) {
					
					// recover from the sunburn
					currentBurn = currentBurn + (Time.deltaTime * recoverSpeed);
				}

			} else {

				// if player IS NOT in the shade

				currentBurn = currentBurn - (Time.deltaTime * burnSpeed * (1.0f - (timeLeft / maxTime))); // tick the currentBurn amount down
				timeLeft = timeLeft - Time.deltaTime; // tick the timer down linearly

			}

			////
			// as long as player is not dead, keep doing these calculations & updating game appearance:

			deltaFactor = (1.0f - (currentBurn / maxBurn)); // update deltaFactor (which increases from 0.0 to 1.0)

			// for aesthetic & graphical changes in the game: burnmeter, colour curves, bloom
			burnMeter.value = (deltaFactor * 100); // update graphical Burn Meter GUI
			bloom.intensity = (deltaFactor * 2); // update the bloom intensity post-processing script
			colorCurvesManager.SetFactor (deltaFactor); // update the colour curves post-processing script
			////

		} else {
			
			// if you're outta time...
			// game over bruh
			// load to lose scene (which is index 3)
			SceneManager.LoadScene(3);
			Cursor.lockState = CursorLockMode.None; // free the cursor

		} ////



			
	}

}
