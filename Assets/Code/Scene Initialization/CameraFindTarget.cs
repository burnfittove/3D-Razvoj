using Unity.Cinemachine;
using UnityEngine;

public class CameraFindTarget : MonoBehaviour
{
    private CinemachineCamera _camera;

    private void Awake()
    {
        _camera = GetComponent<CinemachineCamera>();
        
        // if (_camera.Target.TrackingTarget) return;  // If there is already a defined target, return
        var _player = GameObject.FindGameObjectWithTag("Player");
        if (!_player)
        {
            Debug.LogWarning("Couldn't find player");
            return;
        }
        _camera.Target.TrackingTarget = _player.transform;   // Otherwise, find the player via tag and use their transform
    }
}
