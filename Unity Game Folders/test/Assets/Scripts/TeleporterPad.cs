using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterPad : MonoBehaviour {

	public GameObject teleport;
	public Transform destination;

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
