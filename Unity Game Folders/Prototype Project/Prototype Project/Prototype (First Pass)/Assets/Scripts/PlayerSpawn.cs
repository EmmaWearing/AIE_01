using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour {


	//A Game Object that sets the location of Player 1's Spawn
	public Transform player1Spawn;
	//A Game Object that sets the location of Player 2's Spawn
	public Transform player2Spawn;

	//A GameObject that sets the location of Player 1
	public Transform player1;
	//A GameObject that sets the location of Player 2
	public Transform player2;

	//----------------------------------------------------------------------------------------------
	//			Start()
	//Runs during initialisation
	//Param
	//		 None
	//Return
	//		 Void 
	//----------------------------------------------------------------------------------------------
	void Start () {

		player1.transform.position = player1Spawn.transform.position;
		player2.transform.position = player2Spawn.transform.position;

		player1.transform.rotation = player1Spawn.transform.rotation;
		player2.transform.rotation = player2Spawn.transform.rotation;


	}
}
