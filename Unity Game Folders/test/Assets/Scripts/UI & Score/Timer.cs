using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public float roundTimer = 90;
	public Text timerText;


	void Start () {
		timerText = GetComponent<Text> ();

	}


	void Update () {

		if (roundTimer <= 0) {
			Time.timeScale = 0;
			GameOver ();
		}
			
		roundTimer -= Time.deltaTime;
		timerText.text = roundTimer.ToString("f0");

	}


	void GameOver (){
		
	}
}
