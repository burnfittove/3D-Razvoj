using UnityEngine;

public abstract class HealthComponent : MonoBehaviour
{
    public float maxHealth;
    public float CurrentHealth { get; protected set; }

    protected virtual void Awake()
    {
        CurrentHealth = maxHealth;
    }

    public virtual void TakeDamage(float damage)
    {
        if (CurrentHealth <= 0) return;
        CurrentHealth -= damage;
        Die();
    }
    
    public virtual void Heal(float heal)
    {
        if (CurrentHealth >= maxHealth) return;
        CurrentHealth += heal;
    }

    protected virtual void Die()
    {
        if (CurrentHealth > 0) return;
    }
}
