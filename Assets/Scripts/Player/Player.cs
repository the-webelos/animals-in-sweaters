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
	int index;

	// Start is called before the first frame update
	void Start()
	{
		playerInput = GetComponent<PlayerInput>();
		playerColor = GetComponentInChildren<PlayerColor>();
		playerMovement = GetComponent<PlayerMovement>();
		playerAttack = GetComponentInChildren<PlayerAttack>();
		playerHealth = GetComponent<PlayerHealth>();

		Setup();
	}

	// Update is called once per frame
	void Update()
	{
		if (playerHealth.IsDead()) {
			playerMovement.enabled = false;
			playerAttack.enabled = false;
		}
	}

	public void SetPlayerIndex(int index)
	{
		this.index = index;
	}

	void Setup() {
		playerInput.playerIndex = index;

		if (index == 0) {
			playerInput.useMouseLook = false;
		} else {
			playerInput.useMouseLook = true;
		}

		playerInput.SetLabels();
		playerColor.SetColor(new Color(index * 1f, 1f, 1f, 1f));
	}

	public PlayerHealth GetPlayerHealth() {
		return playerHealth;
	}
}