using UnityEngine;

public class PlayerStamina : MonoBehaviour
{
    public float maxStamina;
    public float staminaRegenerationRate;
    public float staminaConsumptionRate;
    public float staminaRegenerationWaitTime;
    private float _waitTime;
    public bool hasStamina;
    public float Stamina { get; private set; }
    public float MaxStamina => maxStamina;

    private void Start()
    {
        Stamina = maxStamina;
        hasStamina = true;
        
        GameEventManager.instance.miscellaneousEvents.SpiritCollected += RecoverStamina;
    }

    public void ConsumeStamina()
    {
        // If there's no stamina, return
        if (!hasStamina) return;
        
        // Consume stamina
        Stamina -= staminaConsumptionRate * Time.deltaTime;
        
        // Keep resetting the timer
        _waitTime = staminaRegenerationWaitTime;
    }

    private void RegenerateStamina()
    {
        if (_waitTime > 0) return;
        if (Stamina >= maxStamina) return;
        Stamina += staminaRegenerationRate * Time.deltaTime;
    }

    private void Update()
    {
        // Check if the player has stamina
        hasStamina = Stamina > 0;
        
        // Recover stamina
        _waitTime -= Time.deltaTime;
        RegenerateStamina();
        
        // Clamp stamina
        Stamina = Mathf.Clamp(Stamina, 0, maxStamina);
    }

    private void RecoverStamina()
    {
        Stamina += 20;
    }
}
