using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedModifyFast: MonoBehaviour {


//A Game Object for Player 1
	public GameObject player;
//A Game Object for Player 2
	public GameObject player2;

//A Game Object for the Speed Pick Up
	public GameObject pickup;


//----------------------------------------------------------------------------------------------
//			Start()
//Runs during initialisation
//Param
//		 None
//Return
//		 Void 
//----------------------------------------------------------------------------------------------
	void Start () {

	}

//----------------------------------------------------------------------------------------------
//			Update()
//Runs every frame
//Param
//		 None
//Return
//		 Void 
//----------------------------------------------------------------------------------------------
	void FixedUpdate () {

	}
//----------------------------------------------------------------------------------------------
//			OnTriggerEnter()
//Checks anything entering the trigger to see if it is either player and then grabs the Player 
//object specified above to access the MovementFast function and initiate the Speed increase
//Param
//		 None
//Return
//		 Void 
//----------------------------------------------------------------------------------------------
	void OnTriggerEnter(Collider other) {

		if (other.tag == "Player") {
			other.GetComponent<Player>().MovementFast ();
			Destroy (this.gameObject);
		}
		if (other.tag == "Player2") {
			other.GetComponent<Player> ().MovementFast ();
			Destroy (pickup.gameObject.transform.gameObject);
		}

	}
}