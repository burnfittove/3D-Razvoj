using System;
using TMPro;
using UnityEngine;

namespace Code.Managers
{
    public class TextManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;
        private Animator _animator;

        private void Awake()
        {
            text.TryGetComponent(out _animator);
        }

        private void Start()
        {
            GameEventManager.instance.textEvents.DisplayText += DisplayTextHandler;
        }

        private void DisplayTextHandler(string text, float time)
        {
            
        }
    }
}