using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	public GameObject gameController;

	public void Retry (){
		Debug.Log ("Retry");
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	public void Quit (){
		Debug.Log ("Quit");
		Application.Quit ();
	}
}
