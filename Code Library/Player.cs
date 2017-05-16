using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float movementSpeed = 0.1f;
	public float rotateSpeed = 1;

	public KeyCode forwardsKey = KeyCode.W;
	public KeyCode backwardsKey = KeyCode.S;
	public KeyCode rotateLeftKey = KeyCode.A;
	public KeyCode rotateRightKey = KeyCode.D;


	public GameObject key;
	public bool hasKey;

	// Use this for initialization
	void Start () {

		hasKey = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		MovePlayer ();

//		Vector3 moveDir = Vector3.zero;
//			moveDir.x = Input.GetAxis("Horizontal"); 
//			transform.position += moveDir * movementSpeed;
	}

	public void GetKey(){
		Debug.Log ("check");
		hasKey = true;
	}

	public void MovePlayer() {

		if (Input.GetKey (forwardsKey)) {
			transform.position += transform.forward * movementSpeed;
		}

		if (Input.GetKey (backwardsKey)) {
			transform.position += transform.forward * -movementSpeed;
		}

		if (Input.GetKey (rotateRightKey)) {
			transform.Rotate (Vector3.up * rotateSpeed);
		}

		if (Input.GetKey (rotateLeftKey)) {
			transform.Rotate (Vector3.up * -rotateSpeed);
		}
	}


	public void MovementSecond() {

		movementSpeed = movementSpeed * 1.7f;

	}

	public void MovementFast() {

		movementSpeed = movementSpeed * 2.2f;

	}

}
