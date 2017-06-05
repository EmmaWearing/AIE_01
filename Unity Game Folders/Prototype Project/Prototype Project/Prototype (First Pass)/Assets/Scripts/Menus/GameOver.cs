using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	public GameObject gameController;

	public void Retry (){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	public void Quit (){
		Application.Quit ();
	}
}
