using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelection : MonoBehaviour {
    public int player;
    public GameObject[] players;
    private GameObject currentPlayer;
    private int selectionIndex = 0;

    private void Awake() {
        ChangeCurrentPlayer(selectionIndex);
        ChangePlayerPrefab(selectionIndex);
    }

    public void Select(int index) {
        if (index == selectionIndex || index < 0 || players.Length <= index)
            return;

        selectionIndex = index;

        Destroy(currentPlayer);
        ChangeCurrentPlayer(selectionIndex);
        ChangePlayerPrefab(selectionIndex);
    }

    private void ChangePlayerPrefab(int index) {
        GameManager.instance.ChangePlayerPrefab(player, players[index]);
    }

    private void ChangeCurrentPlayer(int index) {
        currentPlayer = Instantiate(players[index].gameObject, transform.position, transform.rotation);
        currentPlayer.transform.localScale *= 3;
        PlayerColor playerColor = currentPlayer.GetComponentInChildren<PlayerColor>();
        playerColor.SetColor(new Color(player * 1f, 1f, 1f, 1f));
    }
}
