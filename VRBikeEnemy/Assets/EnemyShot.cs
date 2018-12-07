﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour {

	public void GotShot()
	{
		EnemyController enemy = GetComponent<EnemyController> ();
		if (enemy != null) {
			enemy.SetAlive (false);
		}
		StartCoroutine (Die ());
	}
		
	private IEnumerator Die()
	{
		this.transform.Rotate (-75, 0, 0);

		yield return new  WaitForSeconds (1.5f);

		Destroy (this.gameObject);
	}
}
