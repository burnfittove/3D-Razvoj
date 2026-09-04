using System.Collections.Generic;
using Code.Managers;
using UnityEngine;

public class SpiritManager : MonoBehaviour
{
    public static SpiritManager instance;
    public Dictionary<string, bool> spiritStates = new();
    public int spiritCount;
    public int saveAfterNumberOfSpirits = 8;
    public int maxNumberOfSpirits = 37;
    public bool AllSpiritsCollected => spiritCount >= maxNumberOfSpirits;
    public bool sendCheckpointMessage = true;
    public string checkpointMessage = "saving...";

    private void Awake()
    {
        if (instance && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    private void Start()
    {
        GameEventManager.instance.miscellaneousEvents.SpiritCollected += IncreaseSpiritCount;
    }

    public bool IsSpiritActive(string spiritId)
    {
        return spiritStates.ContainsKey(spiritId) && spiritStates[spiritId];
    }

    public void AddSpirit(string spiritId)
    {
        if (spiritStates.ContainsKey(spiritId))
        {
            Debug.LogWarningFormat($"Spirit {spiritId} is already in use!", this);
            return;
        }

        spiritStates.TryAdd(spiritId, true);  // If a spirit is already in the hash map, the method will fail and the key value pair will not be affected.
    }

    public void UpdateSpirit(string spiritId, bool newState)
    {
        if (!spiritStates.ContainsKey(spiritId)) return;
        spiritStates[spiritId] = newState;
    }

    private void IncreaseSpiritCount()
    {
        spiritCount++;  // Increment

        if (spiritCount >= maxNumberOfSpirits)                  // If all spirits are collected...
        {
            TryForCheckpoint(true);    // create a checkpoint and ignore 
            if (GameEventManager.instance) GameEventManager.instance.textEvents.OnDisplayText($"I think that's everything... or, uhm, everyone. I should leave through the main door.", 7);
            return;
        }
        
        TryForCheckpoint(); // Try to create a checkpoint
    }
    
    private void TryForCheckpoint(bool ignoreAutocompleteCheck = false)
    {
        if (spiritCount % saveAfterNumberOfSpirits != 0 && !ignoreAutocompleteCheck) return;   // If the number of collected spirits is not divisible by saveAfterNumberOfSpirits, return;
        // a checkpoint is created every saveAfterNumberOfSpirits spirits collected
        if (!SaveDataManager.Instance) return;  // If there is no SaveDataManager, return

        SaveDataManager.Instance.CreateCheckpoint();    // Create a checkpoint
        if (sendCheckpointMessage) GameEventManager.instance.textEvents.OnDisplayText($"{checkpointMessage}", .2f);
    }
}
