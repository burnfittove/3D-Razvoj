using TMPro;
using UnityEngine;

namespace Code.Managers
{
    public class TextManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text textComponent;
        private Animator _animator;
        private float _timer;
        private bool _reset;

        private void Awake()
        {
            textComponent?.TryGetComponent(out _animator);
        }

        private void Start()
        {
            GameEventManager.instance.textEvents.DisplayText += DisplayTextHandler;
        }

        private void Update()
        {
            if (_timer <= 0)
            {
                _animator.SetTrigger("HideText");
                return;
            }
            
            _timer -= Time.deltaTime;
        }

        private void DisplayTextHandler(string text, float time)
        {
            // Reset trigger
            _animator.ResetTrigger("HideText");
            
            // Set trigger
            _animator.SetTrigger("DisplayText");
            
            // Set text and timer
            textComponent.text = text;
            _timer = time;
        }
    }
}