using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    private AudioSource _audioSource;

    public string[] scenesWhereMusicDoesntPlay;

    private void Awake()
    {
        TryGetComponent(out _audioSource);
        
        var currentScene = SceneManager.GetActiveScene().name;
        if (scenesWhereMusicDoesntPlay.Any(scene => currentScene == scene))
        {
            _audioSource.Stop();
            return;
        }
        
        _audioSource.Play();
    }

    private void Start()
    {
        SceneManager.sceneLoaded += SetMusicState;
    }

    private void SetMusicState(Scene currentScene, LoadSceneMode mode)
    {
        if (scenesWhereMusicDoesntPlay.Any(scene => currentScene.name == scene))
        {
            _audioSource.Stop();
            return;
        }

        if (_audioSource.isPlaying) return;
        _audioSource.Play();
    }
}
