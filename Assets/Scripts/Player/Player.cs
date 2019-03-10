using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	PlayerInput playerInput;
	PlayerColor playerColor;
	PlayerMovement playerMovement;
	PlayerAttack playerAttack;
	PlayerHealth playerHealth;


	// Start is called before the first frame update
	void Start()
	{
		playerInput = GetComponent<PlayerInput>();
		playerColor = GetComponentInChildren<PlayerColor>();
		playerMovement = GetComponent<PlayerMovement>();
		playerAttack = GetComponentInChildren<PlayerAttack>();
		playerHealth = GetComponent<PlayerHealth>();
	}

	// Update is called once per frame
	void Update()
	{
		if (playerHealth.IsDead()) {
			playerMovement.enabled = false;
			playerAttack.enabled = false;
		}
	}

	public void Setup(int index) {
		playerInput.playerIndex = index;

		if (index == 0) {
			playerInput.useMouseLook = false;
		} else {
			playerInput.useMouseLook = true;
		}

		playerInput.SetLabels();
		playerColor.SetColor(new Color(index * 1f, 1f, 1f, 1f));
	}
}