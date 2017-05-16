using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class Player : MonoBehaviour {

	Rigidbody rb;

	public float movementSpeed = 0.1f;
	public float rotateSpeed = 1;

	public XboxController controller;
	public KeyCode forwardsKey = KeyCode.W;
	public KeyCode backwardsKey = KeyCode.S;
	public KeyCode rotateLeftKey = KeyCode.A;
	public KeyCode rotateRightKey = KeyCode.D;


	public GameObject key;
	public bool hasKey;

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody> ();

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



		float moveForward = XboxCtrlrInput.XCI.GetAxis(XboxAxis.LeftStickY, controller);
		float moveRight = XboxCtrlrInput.XCI.GetAxis(XboxAxis.LeftStickX, controller);
		Vector3 movement = new Vector3 (moveRight, 0, moveForward);

		rb.AddForce (movement * movementSpeed);
//		if (Input.GetKey (KeyCode.S)) {
//			transform.position += transform.forward * movementSpeed;
//		}
//
//		if (Input.GetKey (KeyCode.W)) {
//			transform.position += transform.forward * -movementSpeed;
//		}
//
//		if (Input.GetKey (rotateRightKey)) {
//			transform.Rotate (Vector3.up * rotateSpeed);
//		}
//
//		if (Input.GetKey (rotateLeftKey)) {
//			transform.Rotate (Vector3.up * -rotateSpeed);
//		}
	}


	public void MovementSecond() {

		movementSpeed = movementSpeed * 1.7f;

	}

	public void MovementFast() {

		movementSpeed = movementSpeed * 2.2f;

	}

}
