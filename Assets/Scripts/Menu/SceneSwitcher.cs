using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher:MonoBehaviour {
    public void NewGame(string level) {
        SceneManager.LoadScene(level);
    }

    public void SelectCharacters() {
        SceneManager.LoadScene("character-selection");
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
