using System.Collections.Generic;
using UnityEngine;

public class SpiritManager : MonoBehaviour
{
    public static SpiritManager instance;
    private readonly Dictionary<string, bool> spiritStates = new();
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
}
