using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	private bool jumped;
	private bool moved;
	private Rigidbody2D rig;

	private void Start() {
		jumped = false;
		moved = false;
		rig = GetComponent<Rigidbody2D>();
	}

	private void Update() {
		if (Input.GetAxisRaw("Jump") == 1 && !jumped) {
			jumped = true;
			moved = false;
		}
	}

	private void FixedUpdate() {
		if (jumped && !moved) {
			Vector2 force = new Vector2(0, 150);
			rig.AddForce(force);
			moved = true;
		}
		if (rig.velocity.y <= 0) {
			jumped = false;
		}

		rig.velocity = Vector2.up * Mathf.Clamp(rig.velocity.y, -10, 10);

		float rotation = (rig.velocity.y / 10) * 80;
		rig.MoveRotation(rotation);
	}
}