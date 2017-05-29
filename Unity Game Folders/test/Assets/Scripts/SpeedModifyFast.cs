using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedModifyFast: MonoBehaviour {

	public GameObject player;
	public GameObject player2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {

		if (other.tag == "Player") {
			player.GetComponent<Player>().MovementFast ();
			Destroy (this.gameObject.transform.parent.gameObject);
		}
		if (other.tag == "Player2") {
			player2.GetComponent<Player> ().MovementFast ();
			Destroy (this.gameObject.transform.parent.gameObject);
		}

	}
}
