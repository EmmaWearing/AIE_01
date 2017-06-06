using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

//A Game Object for the object that spawns
	public GameObject spawnPrefab;

//The position of the object's parent
	public Transform objectParent;

//A float that allows the maximum time to be set
	public float maxTime;
//A float that allows the minimum time to be set
	public float minTime;

//A float that allows the time to be set
	private float time;

//A float that allows the spawn time to be set
	private float spawnTime;

//determines whether something is already spawned or not
	public bool alreadySpawned;
	

//----------------------------------------------------------------------------------------------
//			Start()
//Runs during initialisation
//Param
//		 None
//Return
//		 Void 
//----------------------------------------------------------------------------------------------
	void Start () {

		SetRandomTime ();
		time = minTime;
		alreadySpawned = false;

	}

//----------------------------------------------------------------------------------------------
//			OnTriggerEnter()
//Runs when the determined collider enters the trigger
//Param
//		 Collider other
//Return
//		 Void 
//----------------------------------------------------------------------------------------------
	void OnTriggerEnter (Collider other){
		if (other.tag == "pickup") {
			alreadySpawned = true;
		}
	}

	//----------------------------------------------------------------------------------------------
	//			Update()
	//Runs every frame
	//Param
	//		 None
	//Return
	//		 Void 
	//----------------------------------------------------------------------------------------------
	void OnTriggerExit (Collider other){
		if (other.tag == "Player") {
			alreadySpawned = false;
		}
		
		if (other.tag == "Player2") {
			alreadySpawned = false;
		}
	}
	

//----------------------------------------------------------------------------------------------
//			FixedUpdate()
//Runs eveyr set time as a reliable alternative to Update that doesn't just rely on framerate
//Param
//		 None
//Return
//		 Void 
//----------------------------------------------------------------------------------------------
	void FixedUpdate () {

		if (alreadySpawned == false) {
			time += Time.deltaTime;
			if (time >= spawnTime) {
				SpawnObject ();
				SetRandomTime ();
			}
		}
	}

//----------------------------------------------------------------------------------------------
//			Update()
//Runs every frame
//Param
//		 None
//Return
//		 Void 
//----------------------------------------------------------------------------------------------
	void SpawnObject () {
		time = 0;
		GameObject GO = Instantiate (spawnPrefab, transform.position, spawnPrefab.transform.rotation);
		GO.transform.SetParent (objectParent);
	}

//----------------------------------------------------------------------------------------------
//			Update()
//Runs every frame
//Param
//		 None
//Return
//		 Void 
//----------------------------------------------------------------------------------------------
	void SetRandomTime () {
		spawnTime = Random.Range (minTime, maxTime);
	}
}
