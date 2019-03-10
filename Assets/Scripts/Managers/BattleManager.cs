using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
	public Transform[] spawnPoints;
	public Text winText;

	private Dictionary<int, Player> players;
	Player winner = null;
	bool zoomToWinner;
	VictoryZoom victoryZoom;

	void Awake()
	{
		victoryZoom = Camera.main.GetComponent<VictoryZoom>();

		GameManager.GetStageManager().LoadStage();
	    players = new Dictionary<int, Player>();

		for (int i = 0; i < spawnPoints.Length; i++) {
			SpawnPlayer(spawnPoints[i], i, GameManager.instance.GetPlayerPrefab(i));
		}

		winText.text = "";
	}

	void SpawnPlayer(Transform spawnPoint, int index, GameObject p)
	{
		GameObject player = Instantiate(p, spawnPoint.position, spawnPoint.rotation);
		players[index] = player.GetComponent<Player>();

		players[index].SetPlayerIndex(index);
	}

	private void Update() {
		if (players[0].GetPlayerHealth().IsDead()) {
			winner = players[1];
		} else if (players[1].GetPlayerHealth().IsDead()) {
			winner = players[0];
		}

		if (winner != null) {
			if (!zoomToWinner) {
				zoomToWinner = true;
				victoryZoom.SetVictorTransform(winner.transform);
			} else {
				if (victoryZoom.TargetReached()) {
					if (winText.text == "") {
						Invoke("GotoCharacterSelect", 2f);
					}
					winText.text = "Winner!";
				}
			}
		}
	}

	void GotoCharacterSelect() {
		SceneSwitcher.AfterBattle();
	}
}
