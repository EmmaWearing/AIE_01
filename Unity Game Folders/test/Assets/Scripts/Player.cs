using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class Player : MonoBehaviour {
	
//Rigidbody
	Rigidbody rb;
//Speed
	public float movementSpeed = 100f;
	public float rotateSpeed = 1;
	public float inAirSpeed;
	public float increasedSpeed;
	public bool speedPickUp;
//KnockBack
	public float strength;
	public Transform direction = null;
//Player Spawn
	public Transform playerSpawn;
	public Transform player;
//Controller
	public XboxController controller;
//Jump
	public float jumpHeight;
	public float jumpSpeed;
	public bool canJump;
	public bool isGrounded;
	public bool isFalling;
	public int dragInt;
//Fish Setup
	public GameObject fishPrefab;
	public float fishSpeed = 100;
	public Transform fishSpawnPoint;
	public GameObject fishGun;
//Shoot the Fish
	public bool canFire = true;
	public float shotSpeed = 0.2f;
//Health
	public int health = 100;


	void Start () {
		rb = GetComponent<Rigidbody> ();
		canJump = true;
		isGrounded = true;
		movementSpeed = 100f;
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
		if ( XboxCtrlrInput.XCI.GetAxis(XboxAxis.RightTrigger,controller) > 0 && canFire == true) {
			GameObject GO = Instantiate (fishPrefab, fishSpawnPoint.position, Quaternion.identity) as GameObject;
			GO.GetComponent<Rigidbody> ().AddForce (fishGun.transform.forward * fishSpeed, ForceMode.Impulse);
			canFire = false;
			Invoke ("ResetShooting", shotSpeed);
		}

	}

	private void ResetShooting () {
		canFire = true;
	}

	public void MovePlayer() {
//Move
//		Debug.Log ("I'm moving...");
		//float moveForward = XboxCtrlrInput.XCI.GetAxis(XboxAxis.LeftStickY, controller);
		//float moveRight = XboxCtrlrInput.XCI.GetAxis(XboxAxis.LeftStickX, controller);


		Vector3 moveForwardT = transform.forward * XboxCtrlrInput.XCI.GetAxis (XboxAxis.LeftStickY, controller);
		Vector3 moveRightT = transform.right * XboxCtrlrInput.XCI.GetAxis(XboxAxis.LeftStickX, controller);
		Vector3 movement = moveRightT + moveForwardT;

		//Vector3 movement = new Vector3 (moveRight, 0, moveForward);
		rb.AddForce (movement * movementSpeed);

//Rotate
		float rotatePlayer = XboxCtrlrInput.XCI.GetAxis(XboxAxis.RightStickX, controller);
		player.transform.Rotate (Vector3.up * rotateSpeed * rotatePlayer);
	


// Jump
		if (canJump == true && isGrounded == true && XboxCtrlrInput.XCI.GetButton (XboxCtrlrInput.XboxButton.A, controller)) {
			rb.AddForce (0, jumpHeight, 0);
			rb.drag = 1 * dragInt;
//			rb.AddForce = jump;

//			Debug.Log ("I'm jumping...");
			movementSpeed = inAirSpeed;
			isGrounded = false;
			canJump = false;
			isFalling = true;
		}
		if (isGrounded == false) {
			rb.AddForce (Vector3.up * -jumpSpeed * Time.deltaTime);
		}

	}

//Movement Speed
	public void MovementFast() {
		movementSpeed = increasedSpeed;
		speedPickUp = true;
		Invoke ("ResetMovementSpeed", 2);
	}

	void ResetMovementSpeed () {
		movementSpeed = 100f;
		speedPickUp = false;
		Debug.Log (movementSpeed);
	}

//Checking for Floor to Jump on
	void OnCollisionStay(Collision other) {

		if (other.collider.CompareTag("Floor")) {
			isGrounded = true;
			canJump = true;
			isFalling = false;
		}

//can't jump if touching the walls
		if (other.collider.CompareTag ("Wall")) {
			isGrounded = false;
			canJump = false;
			isFalling = false;
		}
	}


//Collision with the other player
	void OnCollisionEnter(Collision other) {
		if (other.collider.CompareTag("Player")) {
			rb.AddForce (strength, 5, strength);
		}
		if (other.collider.CompareTag("Player2")) {
			rb.AddForce (strength, 5, strength);
		}
}

//Damage
	public void TakeDamage (int damage) {
//		Debug.Log ("hit");
		health -= damage;
	}

//Respawn
	void Respawn() {
//		Debug.Log ("..........");
		health = 100;
		player.transform.position = playerSpawn.transform.position;
		ResetMovementSpeed ();
	}


}
