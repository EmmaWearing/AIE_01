using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2Score : MonoBehaviour {

	public static int playerTwoScore;
	Text text1;


	void Awake () {
		text1 = GetComponent<Text>();
		playerTwoScore = 0;
	}

	void Update () {
		text1.text = "Player 2: " + playerTwoScore;
	}
}