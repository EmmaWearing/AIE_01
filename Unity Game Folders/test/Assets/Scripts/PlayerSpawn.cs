using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour {

	public Transform player1Spawn;
	public Transform player2Spawn;
	public Transform player1;
	public Transform player2;

	// Use this for initialization
	void Start () {

		player1.transform.position = player1Spawn.transform.position;
		player2.transform.position = player2Spawn.transform.position;


	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
