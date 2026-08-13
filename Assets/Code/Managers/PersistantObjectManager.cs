using System;
using System.Collections.Generic;
using UnityEngine;

public class PersistantObjectManager : MonoBehaviour
{
    public static PersistantObjectManager Instance;
    public List<GameObject> persistantObjects;

    private void Awake()
    {
        if (Instance && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
    }

    public void AddObject(GameObject obj)
    {
        persistantObjects.Add(obj);
        DontDestroyOnLoad(obj);
    }

    public void DestroyAllObjects()
    {
        foreach (var obj in persistantObjects)
        {
            Destroy(obj);
        }
    }
}
