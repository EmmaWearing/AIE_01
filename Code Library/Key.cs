using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerStay(Collider other){
		if (other.tag == "Player" && Input.GetKey (KeyCode.E)) {
		//if (other.tag == "Player") {

			//other.GetComponent<Player> ().GetKey ();
			//hasKey = true;
			player.GetComponent<Player>().GetKey();
			Destroy (gameObject.transform.parent.gameObject);
		}
	}
}
