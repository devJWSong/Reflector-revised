﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldCtrlWithJoystick : MonoBehaviour {

	public float movSpeed = 20.0f;
	
	private Transform parentTr;
	private float mouseX;
	private float mouseY;
	private const float distance = 1.7f;
	private JoystickShield joystick;

	// Use this for initialization
	void Start () {
		// get parent's transform component
		parentTr = this.transform.parent.parent;
		joystick = FindObjectOfType<JoystickShield>();
	}
	
	// Update is called once per frame
	void Update () {
		MoveShield();
		RotateShield();
	}

	void MoveShield() {
		bool onMove = false;
		Vector2 moveDir = new Vector2(joystick.Horizontal, joystick.Vertical);

		// Prevent from shield to go on top of player
		if((Mathf.Abs(moveDir.x) >= Mathf.Epsilon) || (Mathf.Abs(moveDir.y) >= Mathf.Epsilon)) {
			onMove = true;
		}

		// Only move shield when joystick is being used
		if(onMove) {
			transform.position = moveDir * Time.deltaTime * 5.0f;
			transform.position += parentTr.position;
		}

		// Keeps distance between character and shield
		float distBetweenTwo = Vector3.SqrMagnitude(parentTr.position - transform.position);
		if(distance != distBetweenTwo) {
			transform.position = (transform.position - parentTr.position).normalized * distance + parentTr.position;
		}


		/*
        mouseX = Input.GetAxisRaw("Mouse X");
		mouseY = Input.GetAxisRaw("Mouse Y");
		float distBetweenTwo = Vector3.SqrMagnitude(parentTr.position - transform.position);

		Vector3 moveDir = new Vector2(mouseX, mouseY);
		transform.Translate(moveDir * Time.deltaTime * movSpeed, Space.Self);
		

		if(distance != distBetweenTwo) {
			transform.position = (transform.position - parentTr.position).normalized * distance + parentTr.transform.position;
		}
		*/
	}

	void RotateShield() {
        // Rotate shield based on its current location
        Vector2 dirVec = (Vector2)(transform.position - parentTr.position);
        float rotDeg = Mathf.Atan2(dirVec.y, dirVec.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotDeg);
	}
	
	void OnCollisionEnter2D(Collision2D coll) {
		Debug.Log("check collision");
		if(coll.gameObject.tag == "Enemy") {
			Destroy(coll.gameObject);
		}
	}
}