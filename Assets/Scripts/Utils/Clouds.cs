using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
	public float speed = 1f;
	public int numClouds = 25;
	public GameObject[] cloudPrefabs;

	void Start()
	{
		float angleSep = 360f / numClouds;

		for (int x = 0; x < numClouds; x++) {
			float y = Random.Range(-10f, -45f);
			float z = Random.Range(50f, 150f);
			float angle = Random.Range(angleSep/-2f, angleSep/2f);
			transform.Rotate(Vector3.up, (angleSep * x) + angle, Space.World);

			GameObject cloudPrefab = cloudPrefabs[Random.Range(0, cloudPrefabs.Length)];

			GameObject cloud = Instantiate(cloudPrefab, Vector3.up * y + Vector3.forward * z, cloudPrefab.transform.rotation, transform);
			cloud.transform.localScale *= Random.Range(.5f, 2f);
			// Rotate some of these
			cloud.transform.Rotate(Vector3.up, 180f * Random.Range(0, 2));
        }
	}

    void Update()
    {
		transform.Rotate(Vector3.up, speed * Time.deltaTime);
    }
}
