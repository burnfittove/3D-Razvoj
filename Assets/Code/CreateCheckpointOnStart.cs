using Code.Managers;
using UnityEngine;

public class CreateCheckpointOnStart : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var saveDataManager = SaveDataManager.Instance;
        if (!saveDataManager) return;
        saveDataManager.CreateCheckpoint();
    }
}
