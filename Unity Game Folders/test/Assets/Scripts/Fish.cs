using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour {

	public int damage = 20;

	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, 3f);
	}

	//When the ball hits something this function will activate
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
