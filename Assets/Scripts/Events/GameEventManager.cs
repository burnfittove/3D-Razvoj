using UnityEngine;

public class GameEventManager : MonoBehaviour
{
    public static GameEventManager instance;
    public InputEvents inputEvents;
    public MiscellaneousEvents miscellaneousEvents;
    
    private void Awake()
    {
        if (instance != null) return;
        Debug.LogWarning("Multiple instances of GameEventManager");
        Destroy(gameObject);
        instance = this;
        
        inputEvents = new InputEvents();
        miscellaneousEvents = new MiscellaneousEvents();
    }
}
