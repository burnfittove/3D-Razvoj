using System;
using System.Linq;
using Code.Saving;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Managers
{
    public class SaveDataManager : MonoBehaviour
    {
        public static SaveDataManager Instance { get; private set; }
        [HideInInspector] public string checkpointSceneName;
        [HideInInspector] public Vector3 checkpointTarget;
        private SaveData _data;
        
        private void Awake()
        {
            if (Instance && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        // private void Start()
        // {
        //     // SceneManager.sceneLoaded += LoadData;
        // }
        //
        // private void LoadData(Scene arg0, LoadSceneMode arg1)
        // {
        //     if (_data == null) return;  // If there's no data, return
        //     var saveDataMapper = new SaveDataMapper();  // Create new object
        //     
        //     var result = saveDataMapper.LoadGame(_data);    // Attempt to load data
        //     SpiritManager.instance.spiritStates.ToList().ForEach(kvp => Debug.Log(kvp.Key + " : " + kvp.Value));
        //     if (result)                                 // If loading was successful...
        //     {
        //         _data = null;                           // erase the cached data...
        //         return;                                 // and return.
        //     }
        //     Debug.LogError("Couldn't load save data!"); // Otherwise, warn of an error; something went wrong
        // }

        public void CreateCheckpoint()
        {
            checkpointSceneName = SceneManager.GetActiveScene().name;   // Get the scene name
            checkpointTarget = Vector3.zero;    // Set the position to (0, 0, 0)

            var saveDataMapper = new SaveDataMapper();  // Create new object

            var isSaveSuccessful = saveDataMapper.SaveGame();   // Attempt to save
            if (isSaveSuccessful) Debug.Log("Save Data Saved!");
            else Debug.LogError("Save Data Failed!");
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
            
            var result = saveDataMapper.LoadGame(loadedData);

            if (!result)
            {
                Debug.LogError("Couldn't load save data!");
                return;
            }

            var player = GameObject.FindGameObjectWithTag("Player");

            // Only proceed if there is a player character
            if (!player)
            {
                Debug.LogError("Couldn't find player character!");
                return;
            }
            
            // Load last scene on last location
            checkpointSceneName = loadedData.lastScene;
            checkpointTarget = Vector3.zero;
            
            // Only proceed if there is SceneChangeManager
            if (!SceneChangeManager.instance)
            {
                Debug.LogError("Couldn't find SceneChangeManager!");
                return;
            }
            
            SceneChangeManager.instance.AddObjectPosition(player, checkpointTarget);
            SceneChangeManager.instance.LoadScene(checkpointSceneName);
        }

        public bool DoesFileExists()
        {
            var temp = new WriteReadSaveData();
            return temp.DoesFileExists();
        }
    }
}