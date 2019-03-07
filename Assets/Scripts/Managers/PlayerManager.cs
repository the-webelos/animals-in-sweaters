using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static GameObject player1Prefab;
    public static GameObject player2Prefab;

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
		GameObject player = Instantiate(index == 0 ? player1Prefab : player2Prefab, spawnPoint.position, spawnPoint.rotation);
		PlayerInput input = player.GetComponent<PlayerInput>();
		input.playerIndex = index;
		if (index == 0) {
			input.useMouseLook = false;
		} else {
			input.useMouseLook = true;
		}

		input.SetLabels();

		PlayerColor playerColor = player.GetComponentInChildren<PlayerColor>();
		playerColor.SetColor(new Color(index * 1f, 1f, 1f, 1f));
	}

    public void UpdatePlayerPrefabs(int player, GameObject prefab) {
        if (player == 0)
            player1Prefab = prefab;
        if (player == 1)
            player2Prefab = prefab;
    }
}
