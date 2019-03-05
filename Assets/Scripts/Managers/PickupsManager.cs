using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupsManager : MonoBehaviour
{
	public GameObject[] pickups;
	public float spawnTime;

	GameObject dropArea;

	void Awake()
	{
		dropArea = GameObject.FindGameObjectWithTag("DropArea");

		Invoke("Drop", spawnTime);
	}

	void Drop() {
		Vector3 placement = dropArea.transform.TransformPoint(Random.value-.5f, Random.value-.5f, -.5f);

		Debug.Log("DROP: " + placement);

		Instantiate(pickups[0], placement, Quaternion.identity);
		Invoke("Drop", spawnTime);
	}
}
