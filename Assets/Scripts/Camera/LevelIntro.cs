using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelIntro : MonoBehaviour
{
	public float introLength = 2f;

	Vector3 finalPosition;
	Quaternion finalRotation;
	float finalSize;
	Camera cam;
	GameObject center;
	float timeRemaining = 0f;
	Transform origParent;
	bool isRotating;

	void Awake()
    {
		cam = GetComponent<Camera>();
		finalSize = cam.orthographicSize;

		center = new GameObject();
		center.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
		origParent = transform.parent;

		finalPosition = transform.position;

		transform.parent = center.transform;
		center.transform.Rotate(Vector3.up, -270f);

		transform.LookAt(Vector3.zero);

		timeRemaining = introLength;
		isRotating = true;
    }

	// Update is called once per frame
	void Update() {
		if (timeRemaining <= 0) {
			transform.parent = origParent;
    		if (isRotating) {
				isRotating = false;

				transform.position = finalPosition;
				transform.LookAt(Vector3.zero);
			}
		} else {
    		timeRemaining -= Time.deltaTime;
		}
	}

	private void LateUpdate() {
		if (isRotating) {
			center.transform.Rotate(center.transform.up, (270f / introLength) * Time.deltaTime);
			transform.LookAt(Vector3.zero);
		}
	}
}
