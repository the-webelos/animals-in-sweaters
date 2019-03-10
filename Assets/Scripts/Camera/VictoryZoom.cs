using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryZoom : MonoBehaviour
{
	private Transform victorTransform;
	Vector3 startPosition;
	Vector3 endPosition;
	float timer;
	float timeToTarget = 2f;
	bool targetReached = false;

	public void SetVictorTransform(Transform trsfm)
	{
		startPosition = transform.position;
		victorTransform = trsfm;
		endPosition = victorTransform.position + (victorTransform.forward * 4f) + (victorTransform.up * 2f);

		timer = 0f;
		targetReached = false;
	}

	// Update is called once per frame
	void Update()
    {
        if (victorTransform != null) {
			timer += Time.deltaTime / timeToTarget;
			transform.position = Vector3.Lerp(startPosition, endPosition, timer);
			transform.LookAt(victorTransform.position + victorTransform.up);
		}

		if (transform.position == endPosition) {
			targetReached = true;
			victorTransform = null;
		}
	}

	public bool TargetReached()
	{
		return targetReached;
	}
}
