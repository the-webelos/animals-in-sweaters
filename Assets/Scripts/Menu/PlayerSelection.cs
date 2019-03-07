using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelection : MonoBehaviour {
    public int player;
    private List<GameObject> players;
    private int selectionIndex = 0;

    private void Start() {
        players = new List<GameObject>();

        foreach(Transform t in transform) {
            players.Add(t.gameObject);
            t.gameObject.SetActive(false);
        }

        players[selectionIndex].gameObject.SetActive(true);

        UpdatePlayerVariables(players[selectionIndex].gameObject);
    }

    public void Select(int index) {
        if (index == selectionIndex || index < 0 || players.Count <= index)
            return;

        players[selectionIndex].gameObject.SetActive(false);
        players[index].gameObject.SetActive(true);
        selectionIndex = index;

        UpdatePlayerVariables(players[selectionIndex].gameObject);
    }

    private void UpdatePlayerVariables(GameObject prefab) {
        GetComponent<PlayerManager>().UpdatePlayerPrefabs(player, prefab);
    }
}
