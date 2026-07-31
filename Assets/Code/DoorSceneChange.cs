using UnityEngine;

public class DoorSceneChange : MonoBehaviour
{
    public string sceneName;
    public Transform nextRoomEnterLocation;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(sceneName);
        if (!GameEventManager.instance) return;
        GameEventManager.instance.miscellaneousEvents.OnSceneLoadLocationSet(GetNextRoomLocation());
        GameEventManager.instance.sceneEvents.OnSceneLoad(sceneName);
    }

    private Vector3 GetNextRoomLocation()
    {
        return !nextRoomEnterLocation ? Vector3.zero : nextRoomEnterLocation.position;
    }
}
