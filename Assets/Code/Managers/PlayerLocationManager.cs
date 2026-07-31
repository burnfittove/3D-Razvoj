using UnityEngine;

namespace Code.Managers
{
    public class PlayerLocationManager : MonoBehaviour
    {
        [SerializeField] private GameObject _player;
        [SerializeField] private Vector3 _nextRoomEnterLocation;
        
        private void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
            
            if (!GameEventManager.instance) return;
            GameEventManager.instance.miscellaneousEvents.SceneLoadLocationSet += SetNextRoomEnterLocation;
            GameEventManager.instance.sceneEvents.SceneLoaded += SetPlayerLocation;
        }
        
        private void SetNextRoomEnterLocation(Vector3 location)
        {
            _nextRoomEnterLocation = location;
        }

        private void SetPlayerLocation()
        { 
            _player.transform.position = _nextRoomEnterLocation;
        }
    }
}