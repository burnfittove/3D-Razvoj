using UnityEngine;

public abstract class HealthComponent : MonoBehaviour
{
    public float maxHealth;
    protected float _currentHealth;

    protected virtual void Awake()
    {
        _currentHealth = maxHealth;
    }

    public virtual void TakeDamage(float damage)
    {
        if (_currentHealth <= 0) return;
        _currentHealth -= damage;
        Die();
    }
    
    public virtual void Heal(float heal)
    {
        if (_currentHealth >= maxHealth) return;
        _currentHealth += heal;
    }

    protected virtual void Die()
    {
        if (_currentHealth > 0) return;
    }
}
