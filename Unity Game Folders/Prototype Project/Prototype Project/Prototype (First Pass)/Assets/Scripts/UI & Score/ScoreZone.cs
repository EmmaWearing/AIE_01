using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreZone : MonoBehaviour {

//An integer for Player 1's current score
	private int currentScorePlayer1;
//An integer for Player 2's current score
	private int currentScorePlayer2;
//A GameObject that is Player 1's score
	public GameObject p1Score;
//A Game Object that is Player 2's score
	public GameObject p2Score;
//A Game Object for Player 1's losing text
	public GameObject p1Lose;
//A Game Object for Player 1's winning text
	public GameObject p1Win;
//A Game Object for Player 2's losing text
	public GameObject p2Lose;
//A Game Object for Player 2's winning text
	public GameObject p2Win;
//A Game Object for the Capture Point
	public GameObject capturePoint;
//A Bool to determine when Player 1 is not in the capture zone
	public bool P1 = false;
//A Bool to determine when Player 2 is not in the capture zone
	public bool P2 = false;
//How quickly the score goes up
	private float scoreSpeed = 1;
//A Bool to determine whether the players can score 
	public bool canScore;
//What the score limit is
	public int scoreLimit;

//----------------------------------------------------------------------------------------------
//			 Start()
//Runs during initialisation
//
//Param
//			None
//Return
//			Void
//----------------------------------------------------------------------------------------------
	void Start (){
		canScore = true;

		Player1Score.playerOneScore = 0;
		Player2Score.playerTwoScore = 0;

	}

//----------------------------------------------------------------------------------------------
//			GameOver ()
//When called the Game Over Menu Scene will load over the Main Scene
//
//Param
//			None
//Return
//			Void
//----------------------------------------------------------------------------------------------
	public void GameOver () {

		SceneManager.LoadScene ("Game Over Menu", LoadSceneMode.Additive);
		return;
	}


//----------------------------------------------------------------------------------------------
//			 OnTriggerEnter()
//Trigger Detection, detects when each player enters the Trigger Box
//
//Param
//			Collider other - The colliders of anything passing through the object
//Return
//			Void
//----------------------------------------------------------------------------------------------
	public void OnTriggerEnter(Collider other){

		if (other.tag == "Player") {
			//			Debug.Log ("p1");
			P1 = true;
			capturePoint.SetActive (false);
		}else if (other.tag == "Player2") {
			P2 = true;
			capturePoint.SetActive (false);
			//			Debug.Log ("p2");
		}
	}

//----------------------------------------------------------------------------------------------
//			 OnTriggerExit()
//Trigger Detection, detects when each player exits the Trigger Box
//
//Param
//			Collider other - The colliders of anything passing through the object
//Return
//			Void
//----------------------------------------------------------------------------------------------
	public void OnTriggerExit(Collider other){
		//Debug.Log ("bye");
		if (other.tag == "Player") {
			P1 = false;
		}else if (other.tag == "Player2") {
			P2 = false;
		}
	}

//----------------------------------------------------------------------------------------------
//			Update ()
//Runs every frame
//
//Param
//			None
//Return
//			Void
//----------------------------------------------------------------------------------------------
	void Update(){

		if (P1 == true && P2 == true) {
			return;
		}

		if (P1 == true && canScore == true) {
			canScore = false;
			Player1Score.playerOneScore += 1;
			Invoke ("ResetScoring", scoreSpeed);
		}

		if (P2 == true && canScore == true) {
			canScore = false;
			Player2Score.playerTwoScore += 1;
			Invoke ("ResetScoring", scoreSpeed);
		}

		//Check the score, if over whatever load gameover scene
		if (Player1Score.playerOneScore > scoreLimit) {
			p1Score.SetActive (false);
			p2Score.SetActive (false);
			p2Win.SetActive (false);
			p1Lose.SetActive (false);
			p1Win.SetActive (true);
			p2Lose.SetActive (true);
			Invoke ("PauseGame", 3f);
//			GameOver ();
		}

		//Check the score, if over whatever load gameover scene
		if (Player2Score.playerTwoScore > scoreLimit) {
			p1Score.SetActive (false);
			p2Score.SetActive (false);
			p1Win.SetActive (false);
			p2Lose.SetActive (false);
			p2Win.SetActive (true);
			p1Lose.SetActive (true);
			Invoke ("PauseGame", 3f);
//			GameOver ();
		}

	}
//----------------------------------------------------------------------------------------------
//			ResetScoring ()
//Resets the player ability to score in the score zone back to true
//
//Param
//			None
//Return
//			Void
//----------------------------------------------------------------------------------------------
	void PauseGame (){
		Time.timeScale = 0;

	}

	//----------------------------------------------------------------------------------------------
	//			 Start()
	//Runs during initialisation
	//
	//Param
	//			None
	//Return
	//			Void
	//----------------------------------------------------------------------------------------------
	void ResetScoring () {
		canScore = true;
	}

}


//	public void OnTriggerStay (Collider other) {
//
//		int player1Increase = 0;
//		int player2Increase = 0;
//
//		if ((other.tag == "Player") && canScore == true) {
//			player1Increase = 1;
////			Debug.Log ("P1");
//			P1 = true;
//			canScore = false;
//			Invoke ("ResetScoring", scoreSpeed);
//		} 
//	
//
//		if ((other.tag == "Player2") && canScore == true) {
//			player2Increase = 1;
////			Debug.Log ("P2");
//			P2 = true;
//			canScore = false;
//			Invoke ("ResetScoring", scoreSpeed);
//		} 
//
////If both players are in the Score Zone then no one scores any points...
//		if (P1 == true && P2 == true) {
//			player1Increase = 0;
//			player2Increase = 0;
//		}
//
//		Player1Score.playerOneScore += player1Increase;
//		Player2Score.playerTwoScore += player2Increase;
//	}
//