using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class Player : MonoBehaviour {
//Rigidbody
	Rigidbody rb;
//Speed
	public float movementSpeed = 20f;
	public float rotateSpeed = 1;
	public float inAirSpeed;
//KnockBack
	public float knockBackDistance;
	public float knockBackSpeed;
//Player Spawn
	public Transform playerSpawn;
	public Transform player;
//Controller
	public XboxController controller;
//Jump
	public float jumpHeight;
	public bool canJump;
	public bool isGrounded;
	public bool isFalling;
//Fish Setup
	public GameObject fishPrefab;
	public float fishSpeed = 20;
	public Transform fishSpawnPoint;
	public GameObject fishGun;
//Shoot the Fish
	KeyCode fireKey = KeyCode.Space;
//Health
	public int health = 100;


	void Start () {
		rb = GetComponent<Rigidbody> ();
		canJump = true;
		isGrounded = true;
	}


// Update is called once per frame
	void Update () {
//Move
		MovePlayer ();
//Health
		//if the player health drops equal to or below 0 then:
		//Get the spawn object that has the spawn script, grab the spawn script off it and respawn the player at their spawn position.
		if (health <= 0) {
			Debug.Log ("respawn");
			Respawn ();
		}
//Shoot
		if (Input.GetKeyDown (fireKey)) {
			GameObject GO = Instantiate (fishPrefab, fishSpawnPoint.position, Quaternion.identity) as GameObject;
			GO.GetComponent<Rigidbody> ().AddForce (fishGun.transform.forward * fishSpeed, ForceMode.Impulse);
		}

	}


	public void MovePlayer() {
//Move
//		Debug.Log ("I'm moving...");
		float moveForward = XboxCtrlrInput.XCI.GetAxis(XboxAxis.LeftStickY, controller);
		float moveRight = XboxCtrlrInput.XCI.GetAxis(XboxAxis.LeftStickX, controller);
		Vector3 movement = new Vector3 (moveRight, 0, moveForward);

		rb.AddForce (movement * movementSpeed);


// Jump
		if (canJump == true && isGrounded == true && XboxCtrlrInput.XCI.GetButton (XboxCtrlrInput.XboxButton.A)) {
			rb.AddForce (0, jumpHeight, 0);
//			rb.AddForce = jump;

//			Debug.Log ("I'm jumping...");
			movementSpeed = inAirSpeed;
			isGrounded = false;
			canJump = false;
			isFalling = true;
		}
	}


	public void MovementFast() {
		movementSpeed = movementSpeed * 2f;
	}


	void OnCollisionStay(Collision other) {

		if (other.collider.CompareTag("Floor")) {
			movementSpeed = movementSpeed;
			isGrounded = true;
			canJump = true;
			isFalling = false;
		}

		if (other.collider.CompareTag ("Wall")) {
			isGrounded = false;
			canJump = false;
			isFalling = false;
		}
	}


	void OnCollisionEnter(Collision other) {
		if (other.collider.CompareTag("Player")) {
			rb.AddForce (0f, jumpHeight * knockBackSpeed * 0.05f, -knockBackDistance * knockBackSpeed);
		}
		if (other.collider.CompareTag("Player2")) {
			rb.AddForce (0f, jumpHeight * knockBackSpeed * 0.05f, -knockBackDistance * knockBackSpeed);
		}
	}


	public void TakeDamage (int damage) {
		Debug.Log ("hit");
		health -= damage;
	}

	void Respawn() {
		Debug.Log ("..........");
		player.transform.position = playerSpawn.transform.position;
	}


}
