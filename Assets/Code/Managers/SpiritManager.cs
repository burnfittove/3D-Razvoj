using System.Collections.Generic;
using Code;
using Code.Managers;
using UnityEngine;

public class SpiritManager : MonoBehaviour
{
    public static SpiritManager instance;
    public Dictionary<string, bool> spiritStates = new();
    public int spiritCount;
    public List<string> spiritPrefabs;

    private void Awake()
    {
        if (instance && instance != this)
        {
            Debug.Log("SpiritManager already exists, destroying!");
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
        // if (spiritStates.TryAdd(spiritId, true))
        // {
        //     spiritPrefabs.Add(spiritId);
        // }
    }

    public void UpdateSpirit(string spiritId, bool newState)
    {
        if (!spiritStates.ContainsKey(spiritId)) return;
        spiritStates[spiritId] = newState;
    }

    private void IncreaseSpiritCount()
    {
        spiritCount++;  // Increment

        if (spiritCount % 5 != 0) return;   // If the number of collected spirits is not divisible by 5, return; a checkpoint is created every 5 spirits collected
        if (!SaveDataManager.Instance) return;  // If there is no SaveDataManager, return

        SaveDataManager.Instance.CreateCheckpoint();    // Create a checkpoint
    }
}
