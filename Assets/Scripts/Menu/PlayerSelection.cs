using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelection : MonoBehaviour {
    private List<GameObject> players;
    private int selectionIndex = 0;

    private void Start() {
        players = new List<GameObject>();

        foreach(Transform t in transform) {
            players.Add(t.gameObject);
            t.gameObject.SetActive(false);
        }

        players[selectionIndex].gameObject.SetActive(true);
    }

    public void Select(int index) {
        if (index == selectionIndex || index < 0 || players.Count <= index)
            return;

        players[selectionIndex].gameObject.SetActive(false);
        players[index].gameObject.SetActive(true);
        selectionIndex = index;
    }
}
