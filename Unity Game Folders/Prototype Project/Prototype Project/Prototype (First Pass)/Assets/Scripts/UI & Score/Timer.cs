﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	//The number the timer will count down from
	public float roundTimer = 60;
	//Sets a text object to be written in the code
	public Text timerText;

	public int secondTimer = 10;

	public int thirdTimer;

	//----------------------------------------------------------------------------------------------
	//			 Start()
	//Runs during initialisation
	//
	//Param
	//			None
	//Return
	//			Void
	//----------------------------------------------------------------------------------------------
	void Start () {
		timerText = GetComponent<Text> ();
	}

	//----------------------------------------------------------------------------------------------
	//			 Update()
	//Runs every frame - To count down from specified number at the set rate and pause when it 
	//reaches 0
	//
	//Param
	//			None
	//Return
	//			Void
	//----------------------------------------------------------------------------------------------
	void Update () {

		if (roundTimer <= 0) {
			Time.timeScale = 0;
		}



		roundTimer -= Time.deltaTime;
		timerText.text = roundTimer.ToString("f0");
		timerText.color = Color.white;

		if (roundTimer <= secondTimer){
			timerText.color = Color.red;
		}

	}
}
