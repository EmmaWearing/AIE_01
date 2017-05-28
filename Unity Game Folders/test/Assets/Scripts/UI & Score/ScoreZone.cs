using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreZone : MonoBehaviour {

	private int currentScorePlayer1;
	private int currentScorePlayer2;

	bool P1;
	bool P2;

	void Start (){

		P1 = false;
		P2 = false;
		Player1Score.playerOneScore = 0;
		Player2Score.playerTwoScore = 0;

	}

	public void OnTriggerStay (Collider other) {
		if (other.tag == "Player") {
			Player1Score.playerOneScore += 1;
//			Debug.Log ("P1");
			P1 = true;
		}
	

		if (other.tag == "Player2") {
			Player2Score.playerTwoScore += 1;
//			Debug.Log ("P2");
			P2 = true;

		}

//If both players are in the Score Zone then no one scores any points...
		if (P1 == true && P2 == true) {
			Player1Score.playerOneScore += 0;
			Player2Score.playerTwoScore += 0;
		}

	}


//If they aren't in the score zone then their score depletes to 0...
	void onTriggerExit (Collider other) {
		
		if (other.tag == "Player") {
			Player1Score.playerOneScore -= 1;
			//			Debug.Log ("P1");
			P1 = false;
		}


		if (other.tag == "Player2") {
			Player2Score.playerTwoScore -= 1;
			//			Debug.Log ("P2");
			P2 = false;

		}
	}

}
