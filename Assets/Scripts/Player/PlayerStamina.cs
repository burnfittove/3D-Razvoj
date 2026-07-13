using UnityEngine;

public class PlayerStamina : MonoBehaviour
{
    public float maxStamina;
    public float staminaRegenerationRate;
    public float staminaConsumptionRate;
    public float staminaRegenerationWaitTime;
    private float _waitTime;
    [SerializeField] private float _stamina;
    public bool hasStamina;

    private void Start()
    {
        _stamina = maxStamina;
        hasStamina = true;
        
        GameEventManager.instance.miscellaneousEvents.SpiritCollected += RecoverStamina;
    }

    public void ConsumeStamina()
    {
        // If there's no stamina, return
        if (!hasStamina) return;
        
        // Consume stamina
        _stamina -= staminaConsumptionRate * Time.deltaTime;
        
        // Keep resetting the timer
        _waitTime = staminaRegenerationWaitTime;
    }

    private void RegenerateStamina()
    {
        if (_waitTime > 0) return;
        if (_stamina >= maxStamina) return;
        _stamina += staminaRegenerationRate * Time.deltaTime;
    }

    private void Update()
    {
        // Check if the player has stamina
        hasStamina = _stamina > 0;
        
        // Recover stamina
        _waitTime -= Time.deltaTime;
        RegenerateStamina();
        
        // Clamp stamina
        _stamina = Mathf.Clamp(_stamina, 0, maxStamina);
    }

    private void RecoverStamina()
    {
        _stamina += 20;
    }
}
