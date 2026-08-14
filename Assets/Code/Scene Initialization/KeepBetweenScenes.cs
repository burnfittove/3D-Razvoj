using System;
using UnityEngine;

public class KeepBetweenScenes : MonoBehaviour
{
    private void Awake()
    {
        if (!PersistantObjectManager.Instance) return;
        PersistantObjectManager.Instance.AddObject(gameObject);
    }
}
