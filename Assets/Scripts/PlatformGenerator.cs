﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

	public GameObject platform;
	public Transform generationPoint;
	public ObjectPooler objectPool;

	public float distanceBetween;

	private float platformWidth;

	void Start () {
		platformWidth = platform.GetComponent<BoxCollider2D> ().size.x;
	}
	
	void Update () {
		if (transform.position.x < generationPoint.position.x) {
			transform.position = new Vector3 (transform.position.x + platformWidth + distanceBetween, transform.position.y, 0);

			//Instantiate(platform, transform.position, transform.rotation);
			GameObject newPlatform = objectPool.GetPooledObject ();

			newPlatform.transform.position = transform.position;
			newPlatform.transform.rotation = transform.rotation;
			newPlatform.SetActive (true);
		}
	}
}
