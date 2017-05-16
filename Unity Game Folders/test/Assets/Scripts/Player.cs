using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float movementSpeed = 0.1f;
	public float rotateSpeed = 1;

	public KeyCode forwardsKey = KeyCode.W;
	public KeyCode backwardsKey = KeyCode.S;
	public KeyCode leftKey = KeyCode.A;
	public KeyCode rightKey = KeyCode.D;


	public GameObject key;
	public bool hasKey;

	// Use this for initialization
	void Start () {

		hasKey = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKey (forwardsKey)) {
			transform.position += transform.forward * movementSpeed;
		}

		if (Input.GetKey (backwardsKey)) {
			transform.position += transform.forward * -movementSpeed;
		}

		Vector3 moveDir = Vector3.zero;
			moveDir.x = Input.GetAxis("Horizontal"); 
			transform.position += moveDir * movementSpeed;
	}

	public void GetKey(){
		hasKey = true;
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player" && Input.GetKey (KeyCode.E)) {
			//other.GetComponent<Player> ().GetKey ();
			hasKey = true;

			Destroy (key);
		}
	}

}
