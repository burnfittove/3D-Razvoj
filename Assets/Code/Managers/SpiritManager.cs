using System;
using System.Collections.Generic;
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
            Debug.LogWarning("Multiple instances of SpiritManager in the scene!");
            gameObject.SetActive(false);
            return;
        }

        instance = this;
    }

    private void Start()
    {
        GameEventManager.instance.miscellaneousEvents.SpiritCollected += IncreaseSpiritCount;
        GameEventManager.instance.miscellaneousEvents.SpiritCollected += () => Debug.Log(spiritCount);
    }

    public bool IsSpiritActive(string spiritId)
    {
        return spiritStates.ContainsKey(spiritId) && spiritStates[spiritId];
    }

    public void AddSpirit(string spiritId)
    {
        // spiritStates.TryAdd(gameObject, true);  // If a spirit is already in the hash map, the method will fail and the key value pair will not be affected.
        if (spiritStates.TryAdd(spiritId, true))
        {
            spiritPrefabs.Add(spiritId);
        }
    }

    public void UpdateSpirit(string spiritId, bool newState)
    {
        if (!spiritStates.ContainsKey(spiritId)) return;
        spiritStates[spiritId] = newState;
    }

    private void IncreaseSpiritCount()
    {
        spiritCount++;

        if (spiritCount % 5 != 0) return;
        if (!CheckpointManager.instance) return;

        CheckpointManager.instance.CreateCheckpoint();
    }
}
