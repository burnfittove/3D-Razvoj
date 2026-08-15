using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

namespace Code
{
    public class HideVisualElements : MonoBehaviour
    {
        public GameObject playerCharacter;
        public Canvas staminaCanvas;
        public Volume healthVignette;
        private bool isPlayerCharacterActive;
        public List<string> playerCharacterInactiveScenes;

        private void OnEnable()
        {
            SceneManager.sceneLoaded += CheckPlayerCharacterActive;
            
            // Initial scene check
            var currentSceneName = SceneManager.GetActiveScene().name;
            var isFound = FindSceneInList(currentSceneName);
            
            SetActiveState(!isFound);
        }

        private void CheckPlayerCharacterActive(Scene scene, LoadSceneMode mode)
        {
            var isFound = FindSceneInList(scene.name);
            
            SetActiveState(!isFound);
        }

        private bool FindSceneInList(string sceneName)
        {
            if (!GameEventManager.instance)
            {
                Debug.Log($"{nameof(HideVisualElements)} couldn't find {nameof(GameEventManager.instance)}.");
                return false;
            }

            if (playerCharacterInactiveScenes.All(scene => sceneName != scene)) return false;
            Debug.Log($"Scene {sceneName} was found in the list of scenes for which to disable the player.");
            return true;
        }
        
        private void SetActiveState(bool state)
        {
            playerCharacter.SetActive(state);
            healthVignette.enabled = state;
            staminaCanvas.enabled = state;
        }
    }
}