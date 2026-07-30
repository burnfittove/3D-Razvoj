using UnityEngine;

public class GameEventManager : MonoBehaviour
{
    public static GameEventManager instance;
    public InputEvents inputEvents;
    public SceneEvents sceneEvents;
    public MiscellaneousEvents miscellaneousEvents;
    
    private void Awake()
    {
        if (instance && instance != this)
        {
            Debug.LogWarning("Multiple instances of GameEventManager");
            gameObject.SetActive(false);
            return;
        }
        instance = this;
        
        inputEvents = new InputEvents();
        sceneEvents = new SceneEvents();
        miscellaneousEvents = new MiscellaneousEvents();
    }
}
