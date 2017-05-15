using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {

	public bool hasKey;

	void Start() {
	
		hasKey = false
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			//other.GetComponent<Player> ().GetKey ();
			hasKey = true
			
			Destroy (gameObject);
		}
	}
}
