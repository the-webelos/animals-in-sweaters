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
	Vector3 moveTowardsPosition;
	float distance;
	Transform origParent;
	bool isRotating;
	bool isSmooshing;
	Matrix4x4 finalProjectionMatrix;

	void Awake()
    {
		cam = GetComponent<Camera>();
		finalSize = cam.orthographicSize;
		finalProjectionMatrix = cam.projectionMatrix;

		center = new GameObject();
		center.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
		origParent = transform.parent;

		finalPosition = transform.position;

		center.transform.Rotate(Vector3.up, 180f);

		transform.LookAt(Vector3.zero);
		//transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

		transform.parent = center.transform;

		cam.orthographic = false;

		timeRemaining = introLength;
		isRotating = true;
		isSmooshing = false;
    }

	// Update is called once per frame
	void Update() {
		if (timeRemaining <= 0) {
    		if (isRotating) {
				isRotating = false;

				transform.position = finalPosition;
				transform.LookAt(Vector3.zero);

				BlendToMatrix(finalProjectionMatrix, 1f, 8);
			}
		} else {
    		timeRemaining -= Time.deltaTime;
		}
	}

	private void LateUpdate() {
		if (isRotating) {
			center.transform.Rotate(center.transform.up, (360f / introLength) * Time.deltaTime);
			transform.LookAt(Vector3.zero);
		}
	}

	Matrix4x4 MatrixLerp(Matrix4x4 from, Matrix4x4 to, float time)
	{
		Matrix4x4 ret = new Matrix4x4();
		for (int i = 0; i < 16; i++)
			ret[i] = Mathf.Lerp(from[i], to[i], time);
		return ret;
	}

	IEnumerator LerpFromTo(Matrix4x4 src, Matrix4x4 dest, float duration, float ease)
	{
		float startTime = Time.time;
		while (Time.time - startTime < duration) {
			float step;
			step = 1 - Mathf.Pow(1 - (Time.time - startTime) / duration, ease);
			cam.projectionMatrix = MatrixLerp(src, dest, step);
			yield return 1;
		}
		cam.projectionMatrix = dest;
		cam.orthographic = true;
		cam.orthographicSize = finalSize; 
	}

	Coroutine BlendToMatrix(Matrix4x4 targetMatrix, float duration, float ease)
	{
		return StartCoroutine(LerpFromTo(cam.projectionMatrix, targetMatrix, duration, ease));
	}
}
