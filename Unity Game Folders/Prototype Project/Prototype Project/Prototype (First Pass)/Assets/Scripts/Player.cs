using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;
using UnityEngine.UI;

public class Player : MonoBehaviour {

//Reference to the Rigidbody on the Player
	Rigidbody rb;

	//Speed
//Setting the Movement Speed of the Player
	public float movementSpeed = 100f;
//The Rotation Speed of the Player
	public float rotateSpeed = 1;
//The Player's speed when they are in the air
	public float inAirSpeed;
//Setting the Increased Speed of the Player
	public float increasedSpeed;
//A Bool to determine if the Player has picked up the Speed Power Up
	public bool speedPickUp;

	//KnockBack
//Setting the value of the Knockback Strength
	public float strength;

	//Player Spawn
//Setting the location of the Player Spawn
	public Transform playerSpawn;
//Setting the location of the Player
	public Transform player;

	//Controller
//Reference to the Controller being used from First - Second
	public XboxController controller;

	//Jump
//How high the player will jump
	public float jumpHeight;
//What speed the player will jump at
	public float jumpSpeed;
//A Bool to determine if the Player is able to jump at that time
	public bool canJump;
//A Bool to determine if the player is on the ground
	public bool isGrounded;
//A Bool to determine if the player is falling
	public bool isFalling;


//Setting the drag amount
	public int dragInt;

	//Fish Setup
//The Game Object that is the Fish Prefab to be used for the bullet
	public GameObject fishPrefab;
//How fast the bullet/fish will travel
	public float fishSpeed = 100;
//The location that the bullet/fish will spawn from
	public Transform fishSpawnPoint;
//The Game Object that is the Gun
	public GameObject fishGun;

	//Shoot the Fish
//A Bool to determine if the player can fire the gun
	public bool canFire = true;
//The time between being able to shoot
	public float shotSpeed = 0.2f;

	//Health
//The amount of the health the player has
	public int health = 100;
	public Slider healthBarSlider;

//----------------------------------------------------------------------------------------------
//			 Start()
//Runs during initialisation
//
//Param
//			None
//Return
//			Void
//----------------------------------------------------------------------------------------------
	void Start () {
		rb = GetComponent<Rigidbody> ();
		canJump = true;
		isGrounded = true;
		movementSpeed = 100f;
		speedPickUp = false;
		healthBarSlider.value = 100f;
	}

//----------------------------------------------------------------------------------------------
//			Update ()
//Runs every frame
//
//Param
//			None
//Return
//			Void
//----------------------------------------------------------------------------------------------
	void FixedUpdate () {
		//Move
		MovePlayer ();
		//Health
		//if the player health drops equal to or below 0 then:
		//Get the spawn object that has the spawn script, grab the spawn script off it and respawn the player at their spawn position.
		if (health <= 0) {
//			Debug.Log ("respawn");
			Respawn ();
		}
		//Shoot
		if ( XboxCtrlrInput.XCI.GetAxis(XboxAxis.RightTrigger,controller) > 0 && canFire == true) {
			GameObject GO = Instantiate (fishPrefab, fishSpawnPoint.position, Quaternion.identity) as GameObject;
			GO.GetComponent<Rigidbody> ().AddForce (fishGun.transform.forward * fishSpeed, ForceMode.Impulse);
			canFire = false;
			Invoke ("ResetShooting", shotSpeed);
		}

		if (isGrounded == true) {
			isFalling = false;
			canJump = true;
			movementSpeed = 50;
		}

		if (speedPickUp == true) {
			movementSpeed = 100;
		} else if (speedPickUp == false) {
			movementSpeed = 30;
		}

	}

//----------------------------------------------------------------------------------------------
//			ResetShooting()
//Resets the can fire meaning the Player can shoot again
//Param
//		 None
//Return
//		 Void 
//----------------------------------------------------------------------------------------------
	private void ResetShooting () {
		canFire = true;
	}

//----------------------------------------------------------------------------------------------
//			Move Player()
//Moves the Player, all the input the player needsto navigate the level including directional, 
//rotational and jump functionality
//Param
//		 None
//Return
//		 Void 
//----------------------------------------------------------------------------------------------

	public void MovePlayer() {
		//Move
		//		Debug.Log ("I'm moving...");
		//float moveForward = XboxCtrlrInput.XCI.GetAxis(XboxAxis.LeftStickY, controller);
		//float moveRight = XboxCtrlrInput.XCI.GetAxis(XboxAxis.LeftStickX, controller);




		float moveForwardT = XboxCtrlrInput.XCI.GetAxis (XboxAxis.LeftStickY, controller);
		float moveRightT = XboxCtrlrInput.XCI.GetAxis(XboxAxis.LeftStickX, controller);
//		Vector3 movement = moveRightT + moveForwardT;

		//Vector3 movement = new Vector3 (moveRight, 0, moveForward);
//		rb.AddForce (movement * movementSpeed);

		transform.Translate (moveRightT * movementSpeed * Time.deltaTime, 0, moveForwardT * movementSpeed * Time.deltaTime);

		//Rotate
		float rotatePlayer = XboxCtrlrInput.XCI.GetAxis(XboxAxis.RightStickX, controller);
		player.transform.Rotate (Vector3.up * rotateSpeed * rotatePlayer);



		// Jump
		if (canJump == true && isGrounded == true && XboxCtrlrInput.XCI.GetButton (XboxCtrlrInput.XboxButton.A, controller)) {
			
//			transform.Translate (0, jumpHeight * jumpSpeed * Time.deltaTime, 0);
			rb.AddForce (0, jumpHeight * jumpSpeed * Time.deltaTime, 0);

			movementSpeed = inAirSpeed;
			isGrounded = false;
			canJump = false;
			isFalling = true;
		} 
		if (isGrounded == false) {
//			rb.drag = 1 * dragInt;
//			transform.Translate (0, jumpHeight * jumpSpeed * Time.deltaTime, 0);
			rb.AddForce (Vector3.up * -jumpSpeed * Time.deltaTime);
		}

	}


	//Movement Speed
//----------------------------------------------------------------------------------------------
//			MovementFast()
//This is called when the Player gets a Speed Pick up and alters the movement Speed to be the
//increased Movement speed
//Param
//		 None
//Return
//		 Void 
//----------------------------------------------------------------------------------------------
	public void MovementFast() {
		
		Debug.Log (movementSpeed);
		speedPickUp = true;
		Invoke ("ResetMovementSpeed", 2);
	}

//----------------------------------------------------------------------------------------------
//			ResetMovementSpeed()
//This returns the player's normal speed after altering it to the increased speed in the 
//MovementFast function
//Param
//		 None
//Return
//		 Void 
//----------------------------------------------------------------------------------------------
	void ResetMovementSpeed () {
		movementSpeed = 30f;
		speedPickUp = false;
		Debug.Log (movementSpeed);
	}

//----------------------------------------------------------------------------------------------
//			ResetShooting()
//Checks if the player is in contact with the Floor
//Param
//		 Collision other - checks any colliders that the player is standing on to see
//		if they are tagged 'Floor'
//Return
//		 Void 
//----------------------------------------------------------------------------------------------
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


//----------------------------------------------------------------------------------------------
//			OnCollisionEnter()
//The Collision with the other player
//Param
//		Collision other - checks to see if the tag of the collision with the player is the 
//		other player
//Return
//		 Void 
//----------------------------------------------------------------------------------------------
	void OnCollisionEnter(Collision other) {
		if (other.collider.CompareTag("Player")) {
			rb.AddForce (strength, 5, strength);
		}
		if (other.collider.CompareTag("Player2")) {
			rb.AddForce (strength, 5, strength);
		}
	}

	//Damage
//----------------------------------------------------------------------------------------------
//			TakeDamage()
//This is where damage is subtracted from the overall health
//Param
//		 int damage - the amount of damage
//Return
//		 Void 
//----------------------------------------------------------------------------------------------
	public void TakeDamage (int damage) {
		//		Debug.Log ("hit");
		health -= damage;
		healthBarSlider.value -= damage;
	}

	//Respawn
//----------------------------------------------------------------------------------------------
//			Respawn()
//Resets the player health and player position to that of the respawn point
//Param
//		 None
//Return
//		 Void 
//----------------------------------------------------------------------------------------------
	public void Respawn() {
		//		Debug.Log ("..........");
		health = 100;
		healthBarSlider.value = 100;
		player.transform.position = playerSpawn.transform.position;
		player.transform.rotation = playerSpawn.transform.rotation;
		ResetMovementSpeed ();
	}


}