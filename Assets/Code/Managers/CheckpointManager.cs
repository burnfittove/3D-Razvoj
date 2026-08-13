using Code.Saving;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Managers
{
    public class CheckpointManager : MonoBehaviour
    {
        public static CheckpointManager Instance { get; private set; }
        public string checkpointSceneName;
        public Vector3 checkpointTarget;

        private void Awake()
        {
            if (Instance && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

        private void CreateCheckpointHandler()
        {
            checkpointSceneName = SceneManager.GetActiveScene().name;
            checkpointTarget = Vector3.zero;

            var saveDataMapper = new SaveDataMapper();

            var isSaveSuccessful = saveDataMapper.SaveGame();
            Debug.Log(isSaveSuccessful ? "Successfully saved checkpoint!" : "Failed to save checkpoint!");
        }
    }
}