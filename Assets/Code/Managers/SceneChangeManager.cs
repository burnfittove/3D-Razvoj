using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Managers
{
    public class SceneChangeManager : MonoBehaviour
    {
        private Dictionary<GameObject, Vector3> _objectPositions = new Dictionary<GameObject, Vector3>();
        public static SceneChangeManager instance;

        private void Awake()
        {
            if (instance && instance != this)
            {
                Debug.LogWarning("Multiple instance of SceneChangeManager in scene!");
                gameObject.SetActive(false);
                return;
            }

            instance = this;
        }

        private void Start()
        {
            SceneManager.sceneLoaded += SetObjectPositions;
        }

        private void SetObjectPositions(Scene scene, LoadSceneMode mode)
        {
            foreach (var keyValPair in _objectPositions)
            {
                if (!keyValPair.Key) continue;  // Early return
                if (keyValPair.Key.TryGetComponent(out CharacterController characterController))
                {
                    characterController.transform.position = keyValPair.Value;
                    continue;
                }
                keyValPair.Key.transform.position = keyValPair.Value;   // Set the object's position
                Debug.Log("Step 4");
            }
            
            _objectPositions.Clear();   // Clear the hash map (notice how i'm calling it a hash map because i'm really smart and know how to write code ⚞^. .^⚟)
            Debug.Log("Step 5");
        }

        public void AddObjectPosition(GameObject gameObject, Vector3 position)
        {
            Debug.Log("Step 2");
            _objectPositions.Add(gameObject, position);
        }

        public void LoadScene(string sceneName)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
            Debug.Log("Step 3");
        }
    }
}