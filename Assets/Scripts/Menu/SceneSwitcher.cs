﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher:MonoBehaviour {
    public void StartBattle() {
        SceneManager.LoadScene("battle");
    }

	public void SelectStage()
	{
		SceneManager.LoadScene("stage-select");
	}

	public void SelectCharacters()
	{
		SceneManager.LoadScene("character-selection");
	}

	public void ChangeSettings() {
        SceneManager.LoadScene("change-settings");
    }

    public void MainMenu() {
        SceneManager.LoadScene("main-menu");
    }

    public void Quit() {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }
}
