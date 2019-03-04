﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
	public GameObject playerPrefab;
	public Transform[] spawnPoints;

	void Start()
	{
		for (int i = 0; i < spawnPoints.Length; i++) {
			SpawnPlayer(spawnPoints[i], i);
		}
	}

	void SpawnPlayer(Transform spawnPoint, int index)
	{
		GameObject player = Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
		PlayerInput input = player.GetComponent<PlayerInput>();
		input.playerIndex = index;
		if (index == 0) {
			input.useMouseLook = false;
		} else {
			input.useMouseLook = true;
		}

		input.SetLabels();
	}
}
