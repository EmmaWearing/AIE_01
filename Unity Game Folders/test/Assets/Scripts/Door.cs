using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

	public Transform doorTransform;
	public float slideOpen = 3f;
	public float speed = 3f;
	private Vector3 closedPosition;

	// Use this for initialization
	void Start () {
		_closedPosition = transform.position;
	}

	void OnTriggerEnter (Collider other) {
		StopCoroutine("MoveDoor");
		Vector3 endpos = _closedPosition + new Vector3(-slideOpen, 0f, 0f);
		StartCoroutine("MoveDoor", endpos);
	}

	void OnTriggerExit (Collider other) {
		StopCoroutine("MoveDoor");
		StartCoroutine("MoveDoor", _closedPosition);
	}


	IEnumerator MoveDoor (Vector3 endPos) {
		float t = 0f;
		Vector3 startPos = doorTransform.position;
		while (t < 1f) {
			t += Time.deltaTime * speed;
			doorTransform.position = Vector3.Slerp(startPos, endPos, t);
			yield return null;
		}
	}

}
