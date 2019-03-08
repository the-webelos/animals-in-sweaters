using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupsManager : MonoBehaviour {
	public GameObject[] pickups;
	public float spawnTime;

	GameObject dropArea;

	void Start() {
		dropArea = GameObject.FindGameObjectWithTag("DropArea");

		Invoke("Drop", 1f);
	}

	void Drop() {
		Vector3 placement = dropArea.transform.TransformPoint(Random.value-.5f, Random.value-.5f, -.5f);

		Instantiate(pickups[Random.Range(0, pickups.Length)], placement, Quaternion.identity);
		Invoke("Drop", spawnTime);
	}
}
