using Code.Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TouchSceneChange : MonoBehaviour
{
    public string sceneName;
    public Transform nextRoomEnterLocation;

    private void OnTriggerEnter(Collider other)
    {
        if (sceneName == string.Empty) return;
        if (!SceneChangeManager.instance) return;
        SceneChangeManager.instance.AddObjectPosition(other.gameObject, GetNextRoomLocation());
        SceneChangeManager.instance.LoadScene(sceneName);
    }

    private Vector3 GetNextRoomLocation()
    {
        return !nextRoomEnterLocation ? Vector3.zero : nextRoomEnterLocation.position;
    }

    private Quaternion GetNextRoomRotation()
    {
        return !nextRoomEnterLocation ? Quaternion.identity : nextRoomEnterLocation.rotation;
    }
}
