using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour {

//An integer declaring the damage amount
	public int damage = 20;

//----------------------------------------------------------------------------------------------
//			 Start()
//Runs when the Scene loads
//
//Param
//			None
//Return
//			Void
//----------------------------------------------------------------------------------------------
	void Start () {
		Destroy (this.gameObject, 3f);
	}
//----------------------------------------------------------------------------------------------
//			 OnTriggerEnter()
//Trigger Detection, detects when the gameobject enters either player's trigger box
//
//Param
//			Collider other - The colliders of any objects that this object passes into
//Return
//			Void
//----------------------------------------------------------------------------------------------

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			other.GetComponent<Player> ().TakeDamage (damage);
		}

		if (other.tag == "Player2") {
			other.GetComponent<Player> ().TakeDamage (damage);
		}

		if (other.tag == "Obstacle") {
			Destroy (this.gameObject);
		}

		if (other.tag == "Wall") {
			Destroy (this.gameObject);
		}


	}
}
