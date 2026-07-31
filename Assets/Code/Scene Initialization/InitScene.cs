using UnityEngine;

public class InitScene : MonoBehaviour
{
    private void Start()
    {
        if (!GameEventManager.instance) return;
        GameEventManager.instance.sceneEvents.OnSceneLoaded();
    }
}
