using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreZone : MonoBehaviour {

	private int currentScorePlayer1;
	private int currentScorePlayer2;

	private bool P1;
	private bool P2;

	private float scoreSpeed = 1;
	public bool canScore;

	void Start (){
		P1 = false;
		P2 = false;

		canScore = true;

		Player1Score.playerOneScore = 0;
		Player2Score.playerTwoScore = 0;

	}

	public void OnTriggerStay (Collider other) {

		int player1Increase = 0;
		int player2Increase = 0;

		if ((other.tag == "Player") && canScore == true) {
			player1Increase = 1;
//			Debug.Log ("P1");
			P1 = true;
			canScore = false;
			Invoke ("ResetScoring", scoreSpeed);
		} 
	

		if ((other.tag == "Player2") && canScore == true) {
			player2Increase = 1;
//			Debug.Log ("P2");
			P2 = true;
			canScore = false;
			Invoke ("ResetScoring", scoreSpeed);
		} 

//If both players are in the Score Zone then no one scores any points...
		if (P1 == true && P2 == true) {
			player1Increase = 0;
			player2Increase = 0;
		}

		Player1Score.playerOneScore += player1Increase;
		Player2Score.playerTwoScore += player2Increase;
	}


	void ResetScoring () {
		canScore = true;
	}

}
