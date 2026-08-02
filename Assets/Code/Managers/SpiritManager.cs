using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpiritManager : MonoBehaviour
{
    public static SpiritManager instance;
    private readonly Dictionary<GameObject, bool> spiritStates = new Dictionary<GameObject, bool>();

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

    private void Update()
    {
        // spiritStates.ToList().ForEach(obj => Debug.Log($"{obj.Key.gameObject.name}: {obj.Value}"));
    }

    public bool IsSpiritActive(GameObject gameObject)
    {
        return spiritStates.ContainsKey(gameObject);
    }

    public void AddSpirit(GameObject gameObject)
    {
        spiritStates.TryAdd(gameObject, true);  // If a spirit is already in the hash map, the method will fail and the key value pair will not be affected.
    }

    public void UpdateSpirit(GameObject gameObject, bool newState)
    {
        if (!spiritStates.ContainsKey(gameObject)) return;
        spiritStates[gameObject] = newState;
    }
}
