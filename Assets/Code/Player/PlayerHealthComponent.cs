using UnityEngine;
using UnityEngine.InputSystem;

public enum HealthState
{
    High,
    Medium,
    Low,
    Critical
}

public class PlayerHealthComponent : HealthComponent
{
    private Animator _animator;

    protected override void Awake()
    {
        base.Awake();
        
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // ### DEBUG ###
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            TakeDamage(1);
            Debug.Log($"Max Health: {maxHealth}\t\t| Current Health: {_currentHealth}");
        }
        
        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            Heal(1);
            Debug.Log($"Max Health: {maxHealth}\t\t| Current Health: {_currentHealth}");
        }
    }

    public HealthState CalculateHealthState(float maxHealth, float currentHealth)
    {
        if (currentHealth > maxHealth * .9f) return HealthState.High;
        if (currentHealth > maxHealth * .6f) return HealthState.Medium;
        if (currentHealth > maxHealth * .3f) return HealthState.Low;
        return HealthState.Critical;
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        VignetteController.instance.UpdatePostProcessingEffects(CalculateHealthState(maxHealth, _currentHealth));   // Calculate the current health state and pass it to the VignetteController
    }

    public override void Heal(float healAmount)
    {
        base.Heal(healAmount);
        VignetteController.instance.UpdatePostProcessingEffects(CalculateHealthState(maxHealth, _currentHealth));   // Calculate the current health state and pass it to the VignetteController
    }
}
