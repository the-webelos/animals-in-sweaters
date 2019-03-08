using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelection : MonoBehaviour {
    public int player;
    public GameObject[] characterPrefabs;
    private GameObject currentCharacter;
    private int selectionIndex;

    private void Awake() {
		Select(0);
    }

    public void Select(int index) {
		if (index < 0 || characterPrefabs.Length <= index) {
			return;
		}

        selectionIndex = index;

		if (currentCharacter != null) {
			Destroy(currentCharacter);
		}

        ChangeCurrentSelection(selectionIndex);
        SetPlayerPrefab(selectionIndex);
    }

    private void SetPlayerPrefab(int index) {
        GameManager.instance.ChangePlayerPrefab(player, characterPrefabs[index]);
    }

    private void ChangeCurrentSelection(int index) {
        currentCharacter = Instantiate(characterPrefabs[index], transform.position, transform.rotation);
        currentCharacter.transform.localScale *= 3;
        PlayerColor playerColor = currentCharacter.GetComponentInChildren<PlayerColor>();
        playerColor.SetColor(new Color(player * 1f, 1f, 1f, 1f));
    }
}
