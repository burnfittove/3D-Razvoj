using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Code.Managers
{
    public class PauseManager : MonoBehaviour
    {
        public static PauseManager Instance;
        public bool canPause;
        public Canvas pauseCanvas;
        public Button[] buttons;
        
        public string[] scenesWhereNoPause = {"MAIN MENU", "GAME OVER", "Intro", "Early End", "End"};
        
        private void Awake()
        {
            if (Instance &&  Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

        private void Start()
        {
            GameEventManager.instance.inputEvents.Pause += PauseGame;
            GameEventManager.instance.sceneEvents.OnSceneLoad += DisablePause;
            SceneManager.sceneLoaded += CheckIfCanPause;
            
            pauseCanvas.enabled = false;
            
            foreach (var button in buttons)
            {
                button.interactable = true;
            }
            
            canPause = scenesWhereNoPause.All(scene => scene != SceneManager.GetActiveScene().name);
        }

        private void DisablePause(string scene)
        {
            canPause = false;
        }

        private void CheckIfCanPause(Scene currentScene, LoadSceneMode mode)
        {
            foreach (var button in buttons)
            {
                button.interactable = true;
            }
            canPause = scenesWhereNoPause.All(scene => scene != currentScene.name);
        }

        private void PauseGame(InputAction.CallbackContext ctx)
        {
            if (!canPause) return;
            if (!ctx.started) return;
            SetState(true);
        }

        public void SetState(bool state)
        {
            Time.timeScale = state ? 0 : 1;
            Cursor.lockState = state ? CursorLockMode.None : CursorLockMode.Locked;
            pauseCanvas.enabled = state;
        }
    }
}