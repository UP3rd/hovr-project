﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public float speed = 5.0f;
	float obstacleRange = 5.0f;

	private bool isAlive;

	public GameObject bulletPrefab;
	private GameObject bullet;

	// Use this for initialization
	void Start () {

		isAlive = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (isAlive) {
			transform.Translate (0, 0, speed * Time.deltaTime);
		}

		Ray ray = new Ray (transform.position, transform.forward);
		RaycastHit hit;
		if (Physics.SphereCast (ray, 0.75f, out hit)) {
			GameObject hitObject = hit.transform.gameObject;
			if (hitObject.GetComponent<PlayerController> ()) {
				if (bullet == null) {
					bullet = Instantiate (bulletPrefab) as GameObject;
					bullet.transform.position = transform.TransformPoint (Vector3.forward * 1.5f);
					bullet.transform.rotation = transform.rotation;
				}
			} else if (hit.distance < obstacleRange) {
				float angle = Random.Range (-120, 120);
				transform.Rotate (0, angle, 0);
			}
		}
	}

	public void SetAlive(bool alive)
	{
		isAlive = alive;
	}
	

	
}
