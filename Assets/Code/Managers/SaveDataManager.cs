using Code.Saving;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Managers
{
    public class SaveDataManager : MonoBehaviour
    {
        public static SaveDataManager Instance { get; private set; }
        public string checkpointSceneName;
        public Vector3 checkpointTarget;
        private SaveData _data;
        
        private void Awake()
        {
            if (Instance && Instance != this)
            {
                Debug.Log($"Instance of {typeof(SaveDataManager)} already exists, destroying object!");
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

        private void Start()
        {
            SceneManager.sceneLoaded += LoadData;
        }

        private void LoadData(Scene arg0, LoadSceneMode arg1)
        {
            if (_data == null) return;  // If there's no data, return
            var saveDataMapper = new SaveDataMapper();  // Create new object
            
            var result = saveDataMapper.LoadGame(_data);    // Attempt to load data
            if (result)                                 // If loading was successful...
            {
                _data = null;                           // erase the cached data...
                return;                                 // and return.
            }
            Debug.LogError("Couldn't load save data!"); // Otherwise, warn of an error; something went wrong
        }

        public void CreateCheckpoint()
        {
            checkpointSceneName = SceneManager.GetActiveScene().name;   // Get the scene name
            checkpointTarget = Vector3.zero;    // Set the position to (0, 0, 0)

            var saveDataMapper = new SaveDataMapper();  // Create new object

            var isSaveSuccessful = saveDataMapper.SaveGame();   // Attempt to save
            Debug.LogError(isSaveSuccessful ? "Successfully saved checkpoint!" : "Failed to save checkpoint!"); // If the save was unsuccessful, return an error message
        }

        public void LoadCheckpoint()
        {
            var saveDataMapper = new SaveDataMapper();

            var loadedData = saveDataMapper.RetrieveData();
            
            if (loadedData == null)
            {
                Debug.LogWarning("Couldn't find save data!");
                return;
            }
            
            _data = loadedData; // Cache save data

            var player = GameObject.FindGameObjectWithTag("Player");

            // Only proceed if there is a player character
            if (!player)
            {
                Debug.LogError("Couldn't find player character!");
                return;
            }
            
            // Load last scene on last location
            checkpointSceneName = _data.lastScene;
            checkpointTarget = _data.checkpointTargetPos;
            
            // Only proceed if there is SceneChangeManager
            if (!SceneChangeManager.instance)
            {
                Debug.LogError("Couldn't find SceneChangeManager!");
                return;
            }
            SceneChangeManager.instance.AddObjectPosition(player, checkpointTarget);
            SceneChangeManager.instance.LoadScene(checkpointSceneName);
        }
    }
}