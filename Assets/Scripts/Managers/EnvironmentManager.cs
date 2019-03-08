using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{
	public GameObject[] environPrefabs;

    // Start is called before the first frame update
    void Awake()
    {
		Instantiate(environPrefabs[Random.Range(0, environPrefabs.Length)], transform);
	}
}
