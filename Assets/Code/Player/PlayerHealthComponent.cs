using UnityEngine;

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
    public float regenerationCooldown;
    public float regenerationRate;
    private float _cooldownBuffer;
    private PlayerController _playerController;

    protected override void Awake()
    {
        base.Awake();
        _animator = GetComponentInChildren<Animator>();
        _playerController = GetComponent<PlayerController>();
        _cooldownBuffer = regenerationCooldown;
    }

    private void Start()
    {
        if (!GameEventManager.instance)
        {
            Debug.LogWarning($"No instance of GameEventManager found in scene! Unable to subscribe {nameof(HealOnSpiritCollected)}.");
            return;
        }
        GameEventManager.instance.miscellaneousEvents.SpiritCollected += HealOnSpiritCollected;
    }

    private void Update()
    {
        _cooldownBuffer -= Time.deltaTime;

        if (_cooldownBuffer > 0) return;
        Heal(regenerationRate * Time.deltaTime);
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, maxHealth);
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
        if (CurrentHealth <= 0) return;
        CurrentHealth -= damage;
        Die();
        _cooldownBuffer = regenerationCooldown;
        VignetteController.instance.UpdatePostProcessingEffects(CalculateHealthState(maxHealth, CurrentHealth));   // Calculate the current health state and pass it to the VignetteController
    }

    public override void Heal(float healAmount)
    {
        if (CurrentHealth >= maxHealth) return;
        CurrentHealth += healAmount;
        VignetteController.instance.UpdatePostProcessingEffects(CalculateHealthState(maxHealth, CurrentHealth));   // Calculate the current health state and pass it to the VignetteController
    }

    private void HealOnSpiritCollected()
    {
        Heal(2);
    }

    protected override void Die()
    {
        if (CurrentHealth > 0) return;
        _animator?.SetTrigger("Dead");
        _playerController.isDead = true;
    }
}
