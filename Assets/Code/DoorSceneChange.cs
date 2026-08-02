using Code.Managers;
using UnityEngine;

public class DoorSceneChange : MonoBehaviour
{
    public string sceneName;
    public Transform nextRoomEnterLocation;

    private void OnTriggerEnter(Collider other)
    {
        if (!SceneChangeManager.instance) return;
        SceneChangeManager.instance.AddObjectPosition(other.gameObject, GetNextRoomLocation());
        SceneChangeManager.instance.LoadScene(sceneName);
    }

    private Vector3 GetNextRoomLocation()
    {
        return !nextRoomEnterLocation ? Vector3.zero : nextRoomEnterLocation.position;
    }
}
