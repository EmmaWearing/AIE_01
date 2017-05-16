using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedModifyFast: MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {

		if (other.tag == "Player") {
			player.GetComponent<Player>().MovementFast();



			Destroy (gameObject.transform.parent.gameObject);
	
	}

	}
}
