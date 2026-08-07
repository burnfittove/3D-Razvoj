using UnityEngine;

public abstract class HealthComponent : MonoBehaviour
{
    public float maxHealth;
    private float _currentHealth;

    protected virtual void Awake()
    {
        _currentHealth = maxHealth;
    }

    public virtual void TakeDamage(float damage)
    {
        _currentHealth -= damage;
    }
    
    public virtual void Heal(float heal)
    {
        _currentHealth += heal;
    }

    protected abstract void Die();
}
