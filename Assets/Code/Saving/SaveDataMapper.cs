using Code.Managers;
using UnityEngine;

namespace Code.Saving
{
    public class SaveDataMapper
    {
        private readonly WriteReadSaveData writeReadSaveData = new();
        private SaveData saveData;
        private readonly PlayerHealthComponent playerHealthComponent;

        public SaveDataMapper()
        {
            GameObject.FindGameObjectWithTag("Player")?.TryGetComponent(out playerHealthComponent); // Whenever this objects is created, it tries to find the player character and their health component
        }
        
        private SaveData MapDataToObject()
        {
            if (!SpiritManager.instance || !SaveDataManager.Instance || !playerHealthComponent) return null;   // If these requirements are missing, return failed save
            
            saveData = new SaveData
            {
                spiritCount = SpiritManager.instance.spiritCount,                   // Set amount of spirits collected
                spiritStates = SpiritManager.instance.spiritStates,                 // Set collected spirits and their states
                playerHealth = playerHealthComponent.CurrentHealth,                 // Set the player character's health
                lastScene = SaveDataManager.Instance.checkpointSceneName,           // Set the scene in which the checkpoint was saved
                checkpointTargetPos = SaveDataManager.Instance.checkpointTarget,    // Set the position to which the player should be placed
            };
            
            // ##### DEBUG #####
            Debug.Log(saveData.spiritCount);
            Debug.Log(saveData.spiritStates);
            Debug.Log(saveData.playerHealth);
            Debug.Log(saveData.lastScene);
            Debug.Log(saveData.checkpointTargetPos);
            
            return saveData;    // Return saved data
        }

        public bool LoadGame(SaveData data)
        {
            if (!SpiritManager.instance || !SaveDataManager.Instance || !playerHealthComponent) return false;   // If these requirements are missing, return failed load
            SpiritManager.instance.spiritCount = data.spiritCount;                  // Set amount of spirits collected
            SpiritManager.instance.spiritStates = data.spiritStates;                // Set collected spirits and their hashes
            playerHealthComponent.CurrentHealth = data.playerHealth;                // Set the player character's health
            SaveDataManager.Instance.checkpointSceneName = data.lastScene;          // Set the scene in which the checkpoint was saved
            SaveDataManager.Instance.checkpointTarget = data.checkpointTargetPos;   // Set the position to which the player should be placed
            return true;    // Return successful load
        }
        
        public bool SaveGame()
        {
            saveData = MapDataToObject();
            if (saveData == null) return false;
            return writeReadSaveData.SaveGame(saveData);
        }

        public SaveData RetrieveData()
        {
            var data = writeReadSaveData.LoadGame();   // Load the save game data
            Debug.Log("2");
            return data;
        }
    }
}