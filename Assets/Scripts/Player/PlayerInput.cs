using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
	public bool useMouseLook = true;

	int floorMask;
	float camRayLength = 100f;
	float inputHorizontal;
	float inputVertical;
	float lookX;
	float lookY;
	bool fire1;

	private void Awake()
	{
		floorMask = LayerMask.GetMask("Floor");
	}

	private void Update()
	{
		inputHorizontal = Input.GetAxisRaw("Horizontal");
		inputVertical = Input.GetAxisRaw("Vertical");

		if (useMouseLook) {
			Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit floorHit;

			if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask)) {
				Vector3 playerToMouse = floorHit.point - transform.position;
				lookX = playerToMouse.x;
				lookY = playerToMouse.z;
			}
		} else {
			lookX = Input.GetAxis("LookX");
			lookY = Input.GetAxis("LookY") * -1f;
		}

		fire1 = Input.GetButton("Fire1");
	}

	public float GetHorizontal() { return inputHorizontal; }
	public float GetVertical() { return inputVertical; }

	public float GetLookX() { return lookX; }
	public float GetLookY() { return lookY; }

	public bool GetFire1() { return fire1; }
}
