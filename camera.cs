using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour {
	public GameObject player;
	Vector3 offset;
	float yRotation;
	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position;
	}

	// Update is called once per frame
	void Update () {
		BetaMove ();
	}

	void BetaMove() {
		Quaternion rotation = Quaternion.Euler (
			0f,
			yRotation += Input.GetAxis("Horizontal"),
			0f
		);

		transform.rotation = rotation;
		transform.position = player.transform.position + rotation * new Vector3 (0f, 1f, -3f);
		transform.LookAt (player.transform.position);
	}
		

	void AlphaMove() {
		transform.LookAt (player.transform);
		float x = Input.GetAxis ("Horizontal") * Time.deltaTime * 30f;
		transform.RotateAround (player.transform.position, Vector3.up, x);

		//transform.TransformDirection (Vector3.forward);
	}
		
}
