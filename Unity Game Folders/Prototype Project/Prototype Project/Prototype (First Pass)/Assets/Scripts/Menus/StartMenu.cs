using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.UI;
using XboxCtrlrInput;

public class StartMenu : MonoBehaviour {

	//The Game Object for the Start Menu
	//	public GameObject startMenu;
	//
	//A bool for whether the button is selected
	//	bool isSelected;

	//A Game Object for the Quit button
	public GameObject startMenu;
	//A Game Object for the Start button
	public GameObject levelSelectMenu;

	public GameObject howToPlayMenu;

	bool level1;
	bool level2;
	bool back;
	bool startGame;
	bool quitGame;
	bool howToPlay;

	//----------------------------------------------------------------------------------------------
	//			 ClickButton()
	//Enables the buttons on the UI to be pressed and have a function
	//
	//Param
	//			int buttonClicked - creates an integer for determining if a button is pressed
	//Return
	//			Void
	//----------------------------------------------------------------------------------------------
	//
	//	public void ClickButton(int buttonClicked) {
	//
	//		if (buttonClicked == 1) {
	//			SceneManager.LoadScene ("Main", LoadSceneMode.Additive);
	//			isSelected = true;
	//		}
	//
	//		if (buttonClicked == 2) {
	//			Application.Quit ();
	//			isSelected = true;
	//		}
	//
	//		if (isSelected == true) {
	//			startMenu.SetActive (false);
	//			return;
	//		}
	//	}

	void Start () {
		startGame = true;
		quitGame = true;
		level1 = false;
		level2 = false;
		back = false;
		howToPlay = false;
		startMenu.SetActive (true);
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
	void Update (){
		if ((XCI.GetButtonDown (XboxButton.Start, XboxController.All)) && startGame == true) {
			StartGame ();
			startGame = false;
			quitGame = false;
			level1 = true;
			level2 = true;
			back = true;
		}
		if (XCI.GetButtonDown (XboxButton.Back, XboxController.All) && startGame == true) {
			QuitGame ();
		}

		if ((XCI.GetButtonDown (XboxButton.B, XboxController.All)) && back == true) {
			levelSelectMenu.SetActive (false);
			startMenu.SetActive (false);
			startGame = true;
			quitGame = true;
			level1 = false;
			level2 = false;
			back = false;
		}

		if ((XCI.GetButtonDown (XboxButton.X, XboxController.All)) && level1 == true) {
			LevelOne ();
		}

		if ((XCI.GetButtonDown (XboxButton.Y, XboxController.All)) && level2 == true) {
			LevelTwo ();
		}

		if (XCI.GetButtonDown (XboxButton.A) && startGame == true) {
			howToPlay = true;
		
		}

		if ((XCI.GetButtonDown (XboxButton.B, XboxController.All)) && howToPlay == true) {

			startGame = true;
		}

	}

	//----------------------------------------------------------------------------------------------
	//			 StartGame()
	//Runs the Main scene when the button is pressed. 
	//
	//Param
	//			None
	//Return
	//			Void
	//----------------------------------------------------------------------------------------------
	public void StartGame (){
		startMenu.SetActive (false);
		levelSelectMenu.SetActive (true);
	}

	//----------------------------------------------------------------------------------------------
	//			QuitGame ()
	//Quits the game when the button is pressed
	//
	//Param
	//			None
	//Return
	//			Void
	//----------------------------------------------------------------------------------------------

	public void QuitGame (){
		Application.Quit ();
	}

	public void LevelOne (){
		SceneManager.LoadScene ("Main");
	}

	public void LevelTwo (){
		SceneManager.LoadScene ("Level2");
	}

	public void HowToPlay (){
		howToPlay = true;
	
	}
}