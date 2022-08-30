using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour {
	private Rigidbody2D rig;

	private void Start() {
		rig = GetComponent<Rigidbody2D>();
	}

	private void OnTriggerEnter2D(Collider2D other) {
		Vector3 previous = transform.position;
		transform.position = new Vector3(previous.x, 0, 0);
		rig.velocity = Vector2.zero;
	}
}