using UnityEngine;
using UnityEngine.UI;

public class StaminaUI : MonoBehaviour
{
    private Slider _slider;
    private PlayerStamina _staminaComponent;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }
    
    private void Start()
    {
        _staminaComponent = FindAnyObjectByType<PlayerStamina>();
        if (!_staminaComponent) return;
        _slider.maxValue = _staminaComponent.MaxStamina;
        _slider.value = _staminaComponent.Stamina;
    }

    private void Update()
    {
        if (!_staminaComponent) return;
        _slider.value = _staminaComponent.Stamina;
    }
}
