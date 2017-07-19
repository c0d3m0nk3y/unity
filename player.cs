using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
	Rigidbody rb;
	public Camera camera;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		AlphaMove ();
	}

	void AlphaMove() {
		float x = Input.GetAxis ("Horizontal") * Time.deltaTime * 50f;
		float z = Input.GetAxis ("Vertical") * Time.deltaTime * 50f;

		Vector3 v = camera.transform.forward;
		v.y = transform.position.y;

		rb.AddForce (v.normalized * z);
	}

	void BetaMove() {
	}
}
