using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class WriteReadSaveData
{
    private readonly string savePath = Application.persistentDataPath + "/savedata.json";
    
    public bool SaveGame(SaveData data)
    {
        var json = JsonConvert.SerializeObject(data);    // Convert to JSON
        File.WriteAllText(savePath, json);  // Save to file
        return true;    // Confirm save
    }

    public SaveData LoadGame()
    {
        if (!File.Exists(savePath)) return null;    // Return null if there is no save file
        var json = File.ReadAllText(savePath);  // Read the data from the file
        return JsonConvert.DeserializeObject<SaveData>(json);    // Convert the data to SaveData
    }

    public bool DoesFileExists()
    {
        return File.Exists(savePath);
    }
}
