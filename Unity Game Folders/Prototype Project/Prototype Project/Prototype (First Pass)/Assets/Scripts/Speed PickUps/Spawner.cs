using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject spawnPrefab;

	public Transform objectParent;

	public float maxTime;
	public float minTime;

	private float time;

	private float spawnTime;

	public bool alreadySpawned;
	

	// Use this for initialization
	void Start () {

		SetRandomTime ();
		time = minTime;
		alreadySpawned = false;

	}


	void OnTriggerEnter (Collider other){
		if (other.tag == "pickup") {
			alreadySpawned = true;
		}
	}

	void OnTriggerExit (Collider other){
		if (other.tag == "Player") {
			alreadySpawned = false;
		}
		
		if (other.tag == "Player2") {
			alreadySpawned = false;
		}
	}
	

	void FixedUpdate () {

		if (alreadySpawned == false) {
			time += Time.deltaTime;
			if (time >= spawnTime) {
				SpawnObject ();
				SetRandomTime ();
			}
		}
	}

	void SpawnObject () {
		time = 0;
		GameObject GO = Instantiate (spawnPrefab, transform.position, spawnPrefab.transform.rotation);
		GO.transform.SetParent (objectParent);
	}

	void SetRandomTime () {
		spawnTime = Random.Range (minTime, maxTime);
	}
}
