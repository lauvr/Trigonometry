﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ej8 : MonoBehaviour {

	[SerializeField]
	float speed;

	Vector3 dif;

	Vector3 velocity;
	Vector3 displacement;
	Vector3 acceleration;

	// Update is called otnce per frame
	void Update () {

		Vector3 worldMousePosition = GetWorldMousePosition ();
		acceleration = worldMousePosition - transform.position;
		velocity = velocity + acceleration * Time.deltaTime;
		Mover();
		dif = worldMousePosition - transform.position;
		float radians = Mathf.Atan2 (velocity.y, velocity.x);
		transform.localRotation = Quaternion.Euler (0f, 0f, radians*Mathf.Rad2Deg);


	}

	public Vector4 GetWorldMousePosition(){
		Camera camera = Camera.main;
		Vector3 screenPos = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, camera.nearClipPlane);
		Vector3 worldPos = Camera.main.ScreenToWorldPoint (screenPos);
		Debug.DrawLine (Vector3.zero, transform.position, Color.cyan);
		worldPos.z = 0;
		return worldPos;
	}

	public void Mover(){

		displacement = velocity * Time.deltaTime;
		transform.position = transform.position + displacement;
	}
}
