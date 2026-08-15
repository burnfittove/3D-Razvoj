using UnityEngine;

public class GameEventManager : MonoBehaviour
{
    public static GameEventManager instance;
    public InputEvents inputEvents;
    public SceneEvents sceneEvents;
    public TextEvents textEvents;
    public MiscellaneousEvents miscellaneousEvents;
    
    private void Awake()
    {
        if (instance && instance != this)
        {
            Debug.Log("GameEventManager already exists, destroying!");
            Destroy(gameObject);
            return;
        }
        instance = this;
        
        inputEvents = new InputEvents();
        sceneEvents = new SceneEvents();
        textEvents = new TextEvents();
        miscellaneousEvents = new MiscellaneousEvents();
    }
}
