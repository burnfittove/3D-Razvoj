using System;
using UnityEngine;

namespace Code.Managers
{
    public class PauseManager : MonoBehaviour
    {
        public static PauseManager Instance;
        public bool isPaused;
        public Canvas pauseCanvas;
        
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
            throw new NotImplementedException();
        }

        public void SetState(bool state)
        {
            pauseCanvas.enabled = state;
        }

        private void PauseGame()
        {
            SetState(true);
            Time.timeScale = 0;
        }
    }
}