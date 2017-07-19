using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
	Rigidbody rb;
	public Camera camera;
	public float normalSpeed;
	public float boostSpeed;
	float speed;
	float boostTime;
	bool boosting;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		boosting = false;
	}
	
	// Update is called once per frame
	void Update () {
		AlphaMove ();
	}

	void AlphaMove() {
		float z = Input.GetAxis ("Vertical") * Time.deltaTime * 50f;

		Vector3 v = camera.transform.forward;
		v.y = transform.position.y;

		rb.AddForce (v.normalized * z);
	}

	void BetaMove() {
		float x = Input.GetAxis("Horizontal") * Time.deltaTime * 5f;
		float z = Input.GetAxis("Vertical") * Time.deltaTime * 5f;
		transform.Translate(x, 0f, z);
	}

	void ZetaMove() {
		Boost();
		Move();
		ReduceBoost();
	}

	void Move() {
		float x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
		float z = Input.GetAxis("Vertical") * Time.deltaTime * speed;
		transform.Translate(x, 0f, z);
	}

	// Gradually reduces boost to normalSpeed
	void ReduceBoost() {
		if(!boosting) return;

		speed = Mathf.Lerp(boostSpeed, normalSpeed, 1 - boostTime);
		boostTime += Time.deltaTime;

		if(boostTime >= 1.0f) {
			boostTime = 0f;
			boosting = false;
			speed = normalSpeed;
		}
	}

	// Initiates a boost if not already boosting
	void Boost() {
		if(boosting) return;

		//if(Input.KeyPressed('x')) {
		//	bootsTime = 0f;
		//	boosting = true;
		//	speed = maxSpeed;
		//}
	}
}
