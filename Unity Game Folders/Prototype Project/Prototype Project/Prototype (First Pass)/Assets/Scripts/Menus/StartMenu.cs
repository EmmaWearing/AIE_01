using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour {

//The Game Object for the Start Menu
//	public GameObject startMenu;
//
//A bool for whether the button is selected
//	bool isSelected;

	public GameObject pressQuit;
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

	void Awake(){
		
	}

	public void StartGame (){
		if (XboxCtrlrInput.XCI.GetButton(XboxCtrlrInput.XboxButton.Start)){
		SceneManager.LoadScene ("Main");
		}
	}

	public void QuitGame (){
		if (XboxCtrlrInput.XCI.GetButton(XboxCtrlrInput.XboxButton.Back)){
		Application.Quit ();
		}
	}
}