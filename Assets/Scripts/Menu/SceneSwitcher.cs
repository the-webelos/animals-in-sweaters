using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher:MonoBehaviour {
   public void NewGame(string level) {
        SceneManager.LoadScene(level);
   }
}
