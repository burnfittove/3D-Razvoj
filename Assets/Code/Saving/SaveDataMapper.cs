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
                lastScene = CheckpointManager.Instance.checkpointSceneName,
                checkpointTargetPos = CheckpointManager.Instance.checkpointTarget,
            };
            
            return saveData;
        }
        
        public bool SaveGame()
        {
            saveData = MapDataToObject();
            if (saveData == null) return false;
            return saveDataToFile.SaveGame(saveData);
        }
    }
}