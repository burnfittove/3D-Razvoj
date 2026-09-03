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
            currentStep = currentStep.nextStep; // Get the next step from the current step
            UpdateImageAndText();
        }
    }
}