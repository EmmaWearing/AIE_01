using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour {

	//Tank Stuff
	public float movementSpeed = 0.1f;
	public float rotateSpeed = 1;

	//Turret Stuff
	public GameObject turret;
	public float turretRotateSpeed = 2;

	//Bullet Stuff
	public GameObject bulletPrefab;
	public float bulletSpeed = 20;
	public Transform bulletSpawnPoint;

	//Controls
	public KeyCode forwardsKey = KeyCode.W;
	public KeyCode backwardsKey = KeyCode.S;
	public KeyCode rotateLeftKey = KeyCode.A;
	public KeyCode rotateRightKey = KeyCode.D;
	public KeyCode rotateTurretLeftKey = KeyCode.Q;
	public KeyCode rotateTurretRightKey = KeyCode.E;
	public KeyCode fireKey = KeyCode.Space;

	//Health
	public int health = 100;

	public void TakeDamage(int damageToTake) {
		health -= damageToTake;
	}

	// Update is called once per frame
	void Update () {

		if (health <= 0) {
			//this exits the function and does not run anything after it.
			return;
		}

		if (Input.GetKeyDown (fireKey)) {
			GameObject GO = Instantiate (bulletPrefab, bulletSpawnPoint.position, Quaternion.identity) as GameObject;
			GO.GetComponent<Rigidbody> ().AddForce (turret.transform.forward * bulletSpeed, ForceMode.Impulse);
		}

		if (Input.GetKey (rotateTurretLeftKey)) {
			turret.transform.Rotate (Vector3.up * turretRotateSpeed);
		}

		if (Input.GetKey (rotateTurretRightKey)) {
			turret.transform.Rotate (Vector3.up * -turretRotateSpeed);
		}

		if (Input.GetKey (forwardsKey)) {
			transform.position += transform.forward * movementSpeed;
		}

		if (Input.GetKey (backwardsKey)) {
			transform.position += transform.forward * -movementSpeed;
		}

		if (Input.GetKey(rotateRightKey)) {
			transform.Rotate (Vector3.up * rotateSpeed);
		}

		if (Input.GetKey(rotateLeftKey)) {
			transform.Rotate (Vector3.up * -rotateSpeed);
		}




	}
}
