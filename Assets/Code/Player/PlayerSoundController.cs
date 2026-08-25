using UnityEngine;

public class PlayerSoundController : MonoBehaviour
{
    public AudioSource _audioSource;
    
    private void PlayFootstepSound()
    {
        _audioSource.pitch = Random.Range(0.4f, 0.8f);
        _audioSource.Play();
    }
}
