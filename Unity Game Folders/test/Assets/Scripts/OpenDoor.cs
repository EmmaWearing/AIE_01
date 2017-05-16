using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour {

	public Transform doorTransform;
	public float slideOpen = -3f;
	public float speed = 3f;
	public bool isClosed;
	public Vector3 closedPosition;

	public bool hasKey;


	// Use this for initialization
	void Start () {
		isClosed = true;
		closedPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		if (isClosed == false) {
			Vector3 endpos = closedPosition + new Vector3(slideOpen, 0f, 0f);
			}
		}


	void OnTriggerEnter(Collider other){
		if (other.tag == "Player" && hasKey == true) {
			isClosed = false;
		}
	}

		void OntriggerExit(Collider other) {
		Vector3 endpos = closedPosition + new Vector3 (-slideOpen, 0f, 0f);
	}



}
