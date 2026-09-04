using Code.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Cutscene
{
    public class CutsceneManager : MonoBehaviour
    {
        public static CutsceneManager instance;
        public RawImage imageComponent;
        public TMP_Text textComponent;

        public CutsceneStep currentStep;

        public string nextScene;

        private void Awake()
        {
            if (instance && instance != this)
            {
                Destroy(gameObject);
                return;
            }

            instance = this;
        }

        private void Start()
        {
            if (!imageComponent || !textComponent)
            {
                Debug.LogErrorFormat("No image or text component", this);
                return;
            }
            
            UpdateImageAndText();
        }

        private void UpdateImageAndText()
        {
            imageComponent.texture = currentStep.stepImage;
            textComponent.text = currentStep.stepText;
        }

        public void UpdateStep()
        {
            if (currentStep.nextStep)
            {
                currentStep = currentStep.nextStep; // Get the next step from the current step
                UpdateImageAndText();
                return;
            }
            
            // Change scene
            var sceneChangeManager = SceneChangeManager.instance;
            if (!sceneChangeManager) return;
            sceneChangeManager.LoadScene(nextScene);
        }
    }
}