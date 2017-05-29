using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public float roundTimer = 90;
	public Text timerText;

	// Use this for initialization
	void Start () {
		timerText = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		roundTimer -= Time.deltaTime;
		timerText.text = roundTimer.ToString("f0");
	}
}
