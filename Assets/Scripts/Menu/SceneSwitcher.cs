using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher:MonoBehaviour {
    public void NewGame(string level) {
        SceneManager.LoadScene(level);
    }

    public void Quit() {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }
}
