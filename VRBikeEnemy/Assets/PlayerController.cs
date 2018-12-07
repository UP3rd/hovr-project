using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController: MonoBehaviour {
	private int health;
	public float speed = 6.0f;
	float gravity = -9.8f;

	private CharacterController characterControl;

	// Use this for initialization
	void Start () {

		health = 10;
		characterControl = GetComponent<CharacterController> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		float deltaX = Input.GetAxis ("Horizontal") * speed;
		float deltaZ = Input.GetAxis ("Vertical") * speed;
		Vector3 movement = new Vector3 (deltaX, 0, deltaZ);
		movement = Vector3.ClampMagnitude (movement, speed);

		movement.y = gravity;

		movement *= Time.deltaTime;
		movement = transform.TransformDirection (movement);
		characterControl.Move (movement);
	}

	public void Hurt(int damage)
	{
		health -= damage;
		Debug.Log ("Health: " + health);
	}
}
