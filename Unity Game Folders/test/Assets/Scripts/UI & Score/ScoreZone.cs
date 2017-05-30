using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreZone : MonoBehaviour {

	private int currentScorePlayer1;
	private int currentScorePlayer2;

	public GameObject p1Score;
	public GameObject p2Score;

	public GameObject p1Lose;
	public GameObject p1Win;
	public GameObject p2Lose;
	public GameObject p2Win;

	public bool P1 = false;
	public bool P2 = false;

	private float scoreSpeed = 1;
	public bool canScore;
	public int scoreLimit;

	void Start (){
		canScore = true;

		Player1Score.playerOneScore = 0;
		Player2Score.playerTwoScore = 0;

	}

	public void OnTriggerEnter(Collider other){
		
		if (other.tag == "Player") {
//			Debug.Log ("p1");
			P1 = true;
		}else if (other.tag == "Player2") {
			P2 = true;
//			Debug.Log ("p2");
		}
	}

	public void OnTriggerExit(Collider other){
//		Debug.Log ("bye");
		if (other.tag == "Player") {
			P1 = false;
		}else if (other.tag == "Player2") {
			P2 = false;
		}
	}

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
		if (Player1Score.playerOneScore >= scoreLimit) {
			p1Score.SetActive (false);
			p2Score.SetActive (false);
			p1Win.SetActive (true);
			p2Lose.SetActive (true);
			Time.timeScale = 0;
			GameOver ();
			return;

		}

		//Check the score, if over whatever load gameover scene
		if (Player2Score.playerTwoScore>= scoreLimit) {
			p1Score.SetActive (false);
			p2Score.SetActive (false);
			p2Win.SetActive (true);
			p1Lose.SetActive (true);
			Time.timeScale = 0;
			GameOver ();
			return;
		}

	}

	void ResetScoring () {
		canScore = true;
	}

	public void GameOver () {
		SceneManager.LoadScene ("Game Over Menu", LoadSceneMode.Additive);
		return;
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