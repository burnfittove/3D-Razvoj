using UnityEngine;

public class DoorPlaySound : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Awake()
    {
        TryGetComponent(out _audioSource);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_audioSource.isPlaying) return;
        if (!other.CompareTag("Player")) return;
        _audioSource.Play();
    }
}
