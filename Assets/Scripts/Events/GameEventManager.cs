using UnityEngine;

public class GameEventManager : MonoBehaviour
{
    public static GameEventManager instance;
    public InputEvents inputEvents;
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
        miscellaneousEvents = new MiscellaneousEvents();
    }
}
