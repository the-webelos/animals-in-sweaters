using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour {
	GameObject stagePrefab;

    public void LoadStage() {
		GameObject stage = Instantiate(stagePrefab, Vector3.zero, Quaternion.identity);
		stage.transform.Rotate(Vector3.up, 45f);
	}

	public void SetStage(GameObject prefab) {
		stagePrefab = prefab;
	}
}
