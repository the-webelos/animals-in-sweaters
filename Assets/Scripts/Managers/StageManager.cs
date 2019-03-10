using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour {
	GameObject stagePrefab;

    public void LoadStage() {
		Instantiate(stagePrefab, Vector3.zero, Quaternion.identity);
	}

	public void SetStage(GameObject prefab) {
		stagePrefab = prefab;
	}
}
