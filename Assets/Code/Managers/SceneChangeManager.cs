using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Managers
{
    public class SceneChangeManager : MonoBehaviour
    {
        private Dictionary<GameObject, Vector3> _objectPositions = new();
        public static SceneChangeManager instance;
        private string _sceneNameBuffer;

        private void Awake()
        {
            if (instance && instance != this)
            {
                Debug.Log("SceneChangeManager already exists, destroying!");
                Destroy(gameObject);
                return;
            }

            instance = this;
        }

        private void Start()
        {
            SceneManager.sceneLoaded += SetObjectPositions;
            
            if (!GameEventManager.instance) return;
            GameEventManager.instance.sceneEvents.OnFadeInCompleted += FinalLoadScene;
        }

        private void SetObjectPositions(Scene scene, LoadSceneMode mode)
        {
            foreach (var keyValPair in _objectPositions)
            {
                if (!keyValPair.Key) continue;  // Early return
                keyValPair.Key.transform.position = keyValPair.Value;   // Set the object's position
            }
            
            _objectPositions.Clear();   // Clear the hash map (notice how i'm calling it a hash map because i'm really smart and know how to write code ⚞^. .^⚟)
        }

        public void AddObjectPosition(GameObject gameObject, Vector3 position)
        {
            _objectPositions.Add(gameObject, position);
        }

        public void LoadScene(string sceneName)
        {
            if (!GameEventManager.instance) return; // If there's no GameEventManager, don't even try to change scenes
            _sceneNameBuffer = sceneName;   // Cache scene name
            GameEventManager.instance.sceneEvents.TransitionStarted();  // Start a fade in
        }

        private async void FinalLoadScene()
        {
            await SceneManager.LoadSceneAsync(_sceneNameBuffer);
        }
    }
}