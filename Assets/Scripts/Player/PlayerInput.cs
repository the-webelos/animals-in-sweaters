using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {
	public bool useMouseLook = true;
	public int playerIndex = 0;

	int floorMask;
	float camRayLength = 100f;

	string inputHorizontalLabel;
	string inputVerticalLabel;
	string inputLookXLabel;
	string inputLookYLabel;
	string inputFire1Label;
	string inputFire2Label;
    string inputJumpLabel;

    float inputHorizontal;
	float inputVertical;
	float lookX;
	float lookY;
	bool fire1;
	bool fire2;
    bool jump;

	private void Awake() {
        floorMask = LayerMask.GetMask("Environment");
        SetLabels();
	}

	public void SetLabels() {
		inputHorizontalLabel = "Player" + playerIndex + " Horizontal";
		inputVerticalLabel = "Player" + playerIndex + " Vertical";
		inputLookXLabel = "Player" + playerIndex + " LookX";
		inputLookYLabel = "Player" + playerIndex + " LookY";
		inputFire1Label = "Player" + playerIndex + " Fire1";
		inputFire2Label = "Player" + playerIndex + " Fire2";
        inputJumpLabel = "Player" + playerIndex + " Jump";
    }

	private void Update() {
		inputHorizontal = Input.GetAxisRaw(inputHorizontalLabel);
		inputVertical = Input.GetAxisRaw(inputVerticalLabel);

		if (useMouseLook) {
			Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit floorHit;

			if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask)) {
				Vector3 playerToMouse = floorHit.point - transform.position;
				lookX = playerToMouse.x;
				lookY = playerToMouse.z;
			}
		} else {
			lookX = Input.GetAxis(inputLookXLabel);
			lookY = Input.GetAxis(inputLookYLabel) * -1f;
		}

		fire1 = Input.GetButton(inputFire1Label);
		fire2 = Input.GetButton(inputFire2Label);

        jump = Input.GetButton(inputJumpLabel);
	}

	public float GetHorizontal() { return inputHorizontal; }
	public float GetVertical() { return inputVertical; }

	public float GetLookX() { return lookX; }
	public float GetLookY() { return lookY; }

	public bool GetFire1() { return fire1; }
	public bool GetFire2() { return fire2; }

    public bool GetJump() {
        return jump;
    }
}
