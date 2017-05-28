using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1Score : MonoBehaviour {

	public static int playerOneScore;
	Text text1;


	void Awake () {
		text1 = GetComponent<Text>();
		playerOneScore = 0;
	}

	void Update () {
		text1.text = "Player 1: " + playerOneScore;
	}
}
