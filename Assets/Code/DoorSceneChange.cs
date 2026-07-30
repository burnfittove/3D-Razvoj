using UnityEngine;

public class DoorSceneChange : MonoBehaviour
{
    public string sceneName;

    private void OnTriggerEnter(Collider other)
    {
        if (!GameEventManager.instance) return;
        Debug.Log(sceneName);
        GameEventManager.instance.sceneEvents.OnSceneLoad(sceneName);
    }
}
