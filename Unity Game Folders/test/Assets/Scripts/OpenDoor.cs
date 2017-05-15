using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour {

	public Transform doorTransform;
	public float doorSlide = 3f;
	public float speed = 3f;
	public bool isClosed;
	public Vector3 closedPosition;


	// Use this for initialization
	void Start () {
		isClosed = true;
		closedPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		if (isClosed = false) {




		}
		
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player" && hasKey == true) {
			isClosed = false
				
				
		}
	}



}
