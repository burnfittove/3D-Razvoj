using System.IO;
using UnityEngine;

public class WriteReadSaveData
{
    private readonly string savePath = Application.persistentDataPath + "/savedata.json";
    
    public bool SaveGame(SaveData data)
    {
        var json = JsonUtility.ToJson(data);    // Convert to JSON
        File.WriteAllText(savePath, json);  // Save to file
        return true;    // Confirm save
    }

    public SaveData LoadGame()
    {
        if (!File.Exists(savePath)) return null;    // Return null if there is no save file
        var json = File.ReadAllText(savePath);  // Read the data from the file
        return JsonUtility.FromJson<SaveData>(json);    // Convert the data to SaveData
    }
    
    public string GetSaveFilePath()
    {
        return savePath;
    }
}
