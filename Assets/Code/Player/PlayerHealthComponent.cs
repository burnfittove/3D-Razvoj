using UnityEngine;

public class PlayerHealthComponent : HealthComponent
{
    private Animator _animator;

    protected override void Awake()
    {
        base.Awake();
        
        _animator = GetComponent<Animator>();
    }

    protected override void Die()
    {
        throw new System.NotImplementedException();
    }
}
