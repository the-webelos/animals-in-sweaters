using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager instance = null;
	public int numberOfPlayers = 2;
	public MusicManager musicManager;

	GameObject[] playerPrefabs;

	void Awake()
	{
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy(gameObject);
			return;
		}

		DontDestroyOnLoad(gameObject);

		instance.playerPrefabs = new GameObject[numberOfPlayers];
	}

	public void ChangePlayerPrefab(int player, GameObject prefab)
	{
		instance.playerPrefabs[player] = prefab;
	}

	public GameObject GetPlayerPrefab(int index)
	{
		return instance.playerPrefabs[index];
	}

	public static StageManager GetStageManager()
	{
		return instance.GetComponent<StageManager>();
	}

	public static SceneSwitcher GetSceneSwitcher()
	{
		return instance.GetComponent<SceneSwitcher>();
	}
}
