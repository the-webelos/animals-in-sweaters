using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentManager : MonoBehaviour {
	public GameObject[] environPrefabs;

    void Awake() {
		Instantiate(environPrefabs[Random.Range(0, environPrefabs.Length)], transform);
	}
}
