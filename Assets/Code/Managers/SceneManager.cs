using UnityEngine;

namespace Code.Managers
{
    public class SceneManager : MonoBehaviour
    {
        private void Start()
        {
            if (!GameEventManager.instance) return;
            GameEventManager.instance.sceneEvents.SceneLoad += LoadScene;
        }

        private void LoadScene(string sceneName)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }
    }
}