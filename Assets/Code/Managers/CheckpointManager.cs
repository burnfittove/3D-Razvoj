using Code.Saving;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

namespace Code.Managers
{
    public class CheckpointManager : MonoBehaviour
    {
        public static CheckpointManager instance { get; private set; }
        public string checkpointSceneName;
        public Vector3 checkpointTarget;

        private void Awake()
        {
            if (instance && instance != this)
            {
                Destroy(gameObject);
                return;
            }

            instance = this;
        }

        public void CreateCheckpoint()
        {
            checkpointSceneName = SceneManager.GetActiveScene().name;
            checkpointTarget = Vector3.zero;

            var saveDataMapper = new SaveDataMapper();

            var isSaveSuccessful = saveDataMapper.SaveGame();
            Debug.Log(isSaveSuccessful ? "Successfully saved checkpoint!" : "Failed to save checkpoint!");
        }

        private void LoadCheckpoint()
        {
            var saveDataMapper = new SaveDataMapper();

            if (!saveDataMapper.LoadGame())
            {
                Debug.Log("Failed to load checkpoint!");
                return;
            }

            if (!SceneChangeManager.instance) return;
            SceneChangeManager.instance.AddObjectPosition(GameObject.FindGameObjectWithTag("Player"), checkpointTarget);
            SceneChangeManager.instance.LoadScene(checkpointSceneName);
        }
    }
}