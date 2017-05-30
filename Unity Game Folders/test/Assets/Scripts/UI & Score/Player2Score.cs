using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2Score : MonoBehaviour {

	//Sets the score for Player 2
	public static int playerTwoScore;

	//Determines that there is a text variable to be written through code	
	Text text1;

	//----------------------------------------------------------------------------------------------
	//			Awake()
	//Is only called once the first time the script runs
	//Param
	//		 None
	//Return
	//		 Void 
	//----------------------------------------------------------------------------------------------
	void Awake () {
		text1 = GetComponent<Text>();
		playerTwoScore = 0;
	}

	//----------------------------------------------------------------------------------------------
	//			Update()
	//Runs every frame
	//Param
	//		 None
	//Return
	//		 Void 
	//----------------------------------------------------------------------------------------------
	void Update () {
		text1.text = "Player 2: " + playerTwoScore;
	}
}