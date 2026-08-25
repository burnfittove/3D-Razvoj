using UnityEngine;

public class PlayerSoundController : MonoBehaviour
{
    public AudioSource _audioSource;
    public Vector2 pitchRangeInclusive = new(0.2f, 0.6f);
    
    private void PlayFootstepSound()
    {
        _audioSource.pitch = Random.Range(pitchRangeInclusive.x, pitchRangeInclusive.y);
        _audioSource.Play();
    }
}
