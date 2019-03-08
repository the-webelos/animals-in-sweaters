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
	Vector3 origAngle;

	void Awake()
    {
		center = new GameObject();
		center.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
		origAngle = center.transform.eulerAngles;

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
				float t = currentTime / introLength;
				t = Mathf.Sin(t * Mathf.PI * 0.5f);

				center.transform.eulerAngles = new Vector3(
					Mathf.Lerp(origAngle.x, 0f, t),
					Mathf.Lerp(origAngle.y, rotateAngle, t),
					Mathf.Lerp(origAngle.z, 0f, t));

				transform.LookAt(Vector3.zero);
				transform.Translate(Vector3.forward * (zoomDistance / introLength) * Time.deltaTime);

				currentTime += Time.deltaTime;
			}
		}
	}
}
