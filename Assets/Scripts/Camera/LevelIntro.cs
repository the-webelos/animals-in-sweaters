using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelIntro : MonoBehaviour
{
	public float introLength = 2f;
	public float rotateAngle = 360f;
	public float zoomRatio = 3f;

	Vector3 finalPosition;
	GameObject center;
	float currentTime = 0f;
	Transform origParent;
	bool isRotating;
	float zoomDistance;

	void Awake()
    {
		center = new GameObject();
		center.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
		// Save off the parent so we can set it after rotation
		origParent = transform.parent;

		finalPosition = transform.position;
		//move camera back ready for zoom
		transform.position *= zoomRatio;
		zoomDistance = (transform.position - finalPosition).magnitude;

		// set camera parent as our new center object
		transform.parent = center.transform;

		// rotate the center object and the camera will follow
		center.transform.Rotate(Vector3.up, rotateAngle * -1f);

		// make sure we are still looking at the middle of the playfield
		transform.LookAt(Vector3.zero);

		isRotating = true;
    }

	// Update is called once per frame
	void Update() {
		if (isRotating) {
			if (currentTime >= introLength) {
				// Stop rotating and reset
				isRotating = false;
				transform.parent = origParent;
				Destroy(center);

				transform.position = finalPosition;
				transform.LookAt(Vector3.zero);
			} else {
				currentTime += Time.deltaTime;

				center.transform.Rotate(center.transform.up,
					(Mathf.Lerp(rotateAngle*2f, 0f, currentTime/introLength) / introLength) * Time.deltaTime);

				transform.LookAt(Vector3.zero);
				transform.Translate(Vector3.forward * (zoomDistance / introLength) * Time.deltaTime);
			}
		}
	}
}
