using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Managers
{
    public class CursorManager : MonoBehaviour
    {
        private void Awake()
        {
            Cursor.lockState = SceneManager.GetActiveScene().name is "MAIN MENU" or "GAME OVER" ? CursorLockMode.None : CursorLockMode.Locked;
        }

        private void Start()
        {
            SceneManager.sceneLoaded += SetCursorMode;
            Debug.Log(gameObject.name + ": Cursor Loaded");
        }

        private void SetCursorMode(Scene scene, LoadSceneMode mode)
        {
            Cursor.lockState = scene.name is "MAIN MENU" or "GAME OVER" ? CursorLockMode.None : CursorLockMode.Locked;
        }
    }
}