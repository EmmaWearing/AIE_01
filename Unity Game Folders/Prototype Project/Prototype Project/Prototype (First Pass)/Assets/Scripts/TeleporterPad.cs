using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterPad : MonoBehaviour {


//A Game Object that sets the location of the teleporter
	public GameObject teleport;
//A Game Object that sets the location the player will be teleported to
//Or, the destination
	public Transform destination;

//----------------------------------------------------------------------------------------------
//			 OnTriggerEnter()
//The collision with either player
//
//Param
//			Collision other - checks to see if any collisions that enter the trigger 
//			tagged as being either player
//Return
//			Void
//----------------------------------------------------------------------------------------------
	void OnTriggerEnter (Collider other) {

		if (other.tag == "Player"){
			other.transform.position = destination.transform.position;
			other.transform.rotation = destination.transform.rotation;
		}
		if (other.tag == "Player2"){
			other.transform.position = destination.transform.position;
			other.transform.rotation = destination.transform.rotation;
		}
	}
}
