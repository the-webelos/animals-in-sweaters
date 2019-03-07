using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance = null;
    public PlayerManager playerManager;
    public int numberOfPlayers = 2;

    public GameObject[] playerPrefabs;

    void Awake() {
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        instance.playerManager = GetComponent<PlayerManager>();
        instance.playerPrefabs = new GameObject[numberOfPlayers];
    }

    public void ChangePlayerPrefab(int player, GameObject prefab) {
        Debug.Log("Player prefabs " + playerPrefabs.ToString());
        instance.playerPrefabs[player] = prefab;
    }
}
