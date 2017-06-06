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
	public GameObject pressQuit;
//A Game Object for the Start button
	public GameObject pressStart;

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
		if (XCI.GetButtonDown (XboxButton.Start, XboxController.All)) {
			StartGame ();
		}
		if (XCI.GetButtonDown (XboxButton.Back, XboxController.All)) {
			QuitGame ();
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
//		if (XboxCtrlrInput.XCI.GetButton(XboxCtrlrInput.XboxButton.Start)){
		SceneManager.LoadScene ("Main");
//		}
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
		if (XboxCtrlrInput.XCI.GetButton(XboxCtrlrInput.XboxButton.Back)){
		Application.Quit ();
		}
	}
}