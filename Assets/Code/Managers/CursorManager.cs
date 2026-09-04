using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Managers
{
    public class CursorManager : MonoBehaviour
    {
        public string[] scenesWhereCursorIsShown = {"MAIN MENU", "GAME OVER", "Intro"};
        
        private void Awake()
        {
            var currentScene = SceneManager.GetActiveScene().name;
            if (scenesWhereCursorIsShown.Any(scene => currentScene == scene))
            {
                Cursor.lockState = CursorLockMode.None;
                return;
            }
            
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Start()
        {
            SceneManager.sceneLoaded += SetCursorMode;
        }

        private void SetCursorMode(Scene currentScene, LoadSceneMode mode)
        {
            if (scenesWhereCursorIsShown.Any(scene => currentScene.name == scene))
            {
                Cursor.lockState = CursorLockMode.None;
                return;
            }
            
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}