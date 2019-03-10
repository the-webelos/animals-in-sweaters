using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
	public Transform[] spawnPoints;

	private Dictionary<int, GameObject> players;

	void Awake()
	{
		GameManager.GetStageManager().LoadStage();
	    players = new Dictionary<int, GameObject>();

		for (int i = 0; i < spawnPoints.Length; i++) {
			SpawnPlayer(spawnPoints[i], i, GameManager.instance.GetPlayerPrefab(i));
		}
	}

	void SpawnPlayer(Transform spawnPoint, int index, GameObject p)
	{
		GameObject player = Instantiate(p, spawnPoint.position, spawnPoint.rotation);
		players[index] = player;

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

	private void Update() {
	}
}
