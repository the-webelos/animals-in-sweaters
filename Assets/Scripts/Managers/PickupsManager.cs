using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupsManager : MonoBehaviour
{
	public GameObject[] pickups;

	float minX = 0;
	float minZ = 0;
	float maxX = 0;
	float maxZ = 0;

	// Start is called before the first frame update
	void Awake()
	{
		foreach (GameObject walkableObject in GameObject.FindGameObjectsWithTag("Walkable")) {
			Renderer r = walkableObject.GetComponent<Renderer>();
			Debug.Log(r);
			Vector3 min = r.bounds.center - r.bounds.extents;
			Vector3 max = r.bounds.center + r.bounds.extents;
			Debug.Log("min: " + min);
			Debug.Log("max: " + max);

			minX = min.x;
			minZ = min.z;
			maxX = max.x;
			maxZ = max.z;
		}

		Invoke("Drop", 5f);
	}

	void Drop() {
		Instantiate(pickups[0], new Vector3(Random.Range(minX, maxX), .3f, Random.Range(minZ, maxZ)), new Quaternion());
		Invoke("Drop", 5f);
	}
}
