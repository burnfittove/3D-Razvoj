using System.Collections.Generic;
using Code.Managers;
using UnityEngine;

public class SpiritManager : MonoBehaviour
{
    public static SpiritManager instance;
    public Dictionary<string, bool> spiritStates = new();
    public int spiritCount;
    public int saveAfterNumberOfSpirits = 10;
    public bool sendCheckpointMessage = true;
    public string checkpointMessage = "Checkpoint!";

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
            Debug.LogError($"Spirit {spiritId} is already in use!");
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

        TryForCheckpoint(); // Try to create a checkpoint
    }
    
    private void TryForCheckpoint()
    {
        if (spiritCount % saveAfterNumberOfSpirits != 0) return;   // If the number of collected spirits is not divisible by saveAfterNumberOfSpirits, return;
        // a checkpoint is created every saveAfterNumberOfSpirits spirits collected
        if (!SaveDataManager.Instance) return;  // If there is no SaveDataManager, return

        SaveDataManager.Instance.CreateCheckpoint();    // Create a checkpoint
        if (sendCheckpointMessage) GameEventManager.instance.textEvents.OnDisplayText($"{checkpointMessage}", 1);
    }
}
