using System.IO;
using Code.Managers;
using UnityEngine;

namespace Code.Saving
{
    public class SaveDataMapper
    {
        private readonly SaveDataToFile saveDataToFile = new();
        private SaveData saveData;
        private readonly PlayerHealthComponent playerHealthComponent;

        public SaveDataMapper()
        {
            GameObject.FindGameObjectWithTag("Player")?.TryGetComponent(out playerHealthComponent);
        }
        
        private SaveData MapDataToObject()
        {
            if (!playerHealthComponent)
            {
                Debug.LogWarning("Couldn't find PlayerHealthComponent");
                return null;
            }
            
            saveData = new SaveData
            {
                spiritCount = SpiritManager.instance.spiritCount,
                spiritStates = SpiritManager.instance.spiritStates,
                playerHealth = playerHealthComponent.CurrentHealth,
                lastScene = CheckpointManager.instance.checkpointSceneName,
                checkpointTargetPos = CheckpointManager.instance.checkpointTarget,
            };
            
            Debug.Log(saveData.spiritCount);
            Debug.Log(saveData.spiritStates);
            Debug.Log(saveData.playerHealth);
            Debug.Log(saveData.lastScene);
            Debug.Log(saveData.checkpointTargetPos);
            
            return saveData;
        }

        private bool MapDataToGame(SaveData data)
        {
            if (!SpiritManager.instance || !CheckpointManager.instance) return false;
            SpiritManager.instance.spiritCount = data.spiritCount;
            SpiritManager.instance.spiritStates = data.spiritStates;
            playerHealthComponent.CurrentHealth = data.playerHealth;
            CheckpointManager.instance.checkpointSceneName = data.lastScene;
            CheckpointManager.instance.checkpointTarget = data.checkpointTargetPos;
            return true;
        }
        
        public bool SaveGame()
        {
            saveData = MapDataToObject();
            if (saveData == null) return false;
            return saveDataToFile.SaveGame(saveData);
        }

        public bool LoadGame()
        {
            var data = saveDataToFile.LoadGame();   // Load the save game data
            
            return data != null && // If there is no data, return
                   MapDataToGame(data); // Otherwise, map the data to game objects
        }
    }
}