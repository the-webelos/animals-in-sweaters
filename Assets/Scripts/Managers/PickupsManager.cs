using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupsManager : MonoBehaviour
{
	public GameObject[] pickups;

	Quaternion rotation;
	float minX = 0;
	float minZ = 0;
	float maxX = 0;
	float maxZ = 0;

	// Start is called before the first frame update
	void Awake()
	{
		foreach (GameObject walkableObject in GameObject.FindGameObjectsWithTag("Walkable")) {
			Renderer r = walkableObject.GetComponent<Renderer>();
			Vector3 min = r.bounds.center - r.bounds.extents;
			Vector3 max = r.bounds.center + r.bounds.extents;

			minX = min.x;
			minZ = min.z;
			maxX = max.x;
			maxZ = max.z;
		}

		Invoke("Drop", 5f);
	}

	void Drop() {
		Vector3 placement = new Vector3(Random.Range(minX, maxX), 1f, Random.Range(minZ, maxZ));
		placement = Quaternion.Euler(0f, 45f, 0f) * placement;

		Instantiate(pickups[0], placement, Quaternion.identity);
		Invoke("Drop", 5f);
	}
}
