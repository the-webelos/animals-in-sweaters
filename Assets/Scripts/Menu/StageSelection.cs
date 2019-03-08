using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StageSelection : MonoBehaviour
{
	public GameObject[] stagePrefabs;
	float selectionChangeTime = 1.5f;

	private int selection = 0;
	float stageAngle;
	bool rotating = false;
	float rotateTargetAngle;
	float origAngle;
	float timer;

	GameObject center;

    // Update is called once per frame
    void Awake()
    {
		center = new GameObject();
		center.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);

		stageAngle = 360f / stagePrefabs.Length;
		Debug.Log("Angle: " + stageAngle);

		foreach (GameObject stagePrefab in stagePrefabs) {
			GameObject stage = Instantiate(stagePrefab, Vector3.back * 30f, Quaternion.identity, center.transform);
			foreach (Rigidbody rb in stage.GetComponentsInChildren<Rigidbody>()) {
				rb.isKinematic = true;
			}

			center.transform.Rotate(Vector3.up, stageAngle);
			center.transform.LookAt(Vector3.zero);
		}
	}

	private void Update()
	{
		if (!rotating) {
			int stageChange = GetStageChange();

			if (stageChange != 0) {
				ChangeStage(stageChange);
			}

			if (Input.GetKey("enter")) {
				SceneManager.LoadScene("level-1");
			}
		} else {
			if (timer >= selectionChangeTime) {
				Debug.Log("Snap: " + rotateTargetAngle);
				center.transform.eulerAngles = new Vector3(0f, rotateTargetAngle, 0f);
				rotating = false;
			} else {
				float t = timer / selectionChangeTime;
				t = Mathf.Sin(t * Mathf.PI * 0.5f);

				center.transform.eulerAngles = new Vector3(0f, Mathf.Lerp(origAngle, rotateTargetAngle, t), 0f);

				timer += Time.deltaTime;
			}
		}
	}

	private int GetStageChange() {
		if (Input.GetKey("left")) {
			return -1;
		} else if (Input.GetKey("right")) {
			return 1;
		}
		return 0;
	}

	int mod(int x, int m)
	{
		int r = x % m;
		return r < 0 ? r + m : r;
	}

	void ChangeStage(int adjust) {
		selection += adjust;

		selection = mod(selection, stagePrefabs.Length);

		origAngle = center.transform.eulerAngles.y;
		rotateTargetAngle = origAngle + (stageAngle * adjust);

		timer = 0f;

		rotating = true;

		Debug.Log("Change: " + selection + " " + origAngle + " target: " + rotateTargetAngle);
	}
}
