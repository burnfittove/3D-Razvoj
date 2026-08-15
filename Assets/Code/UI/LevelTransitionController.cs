using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransitionController : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        if (_animator) return;
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        if (!GameEventManager.instance) return;
        GameEventManager.instance.sceneEvents.OnTransitionStarted += TransitionStartedHandler;
        SceneManager.sceneLoaded += FadeOut;
    }

    private void FadeOut(Scene arg0, LoadSceneMode arg1)
    {
        if (!_animator)
        {
            Debug.Log("No animator found, fetching...");
            _animator = GetComponent<Animator>();
        }
        _animator?.SetTrigger("FadeOut");
    }

    private void TransitionStartedHandler()
    {
        if (!_animator)
        {
            Debug.Log("No animator found");
            return;
        }
        _animator?.SetTrigger("FadeIn");
    }
    
    public void FadeInCompleted()
    {
        if (!GameEventManager.instance) return;
        GameEventManager.instance.sceneEvents.FadeInCompleted();
    }

    public void FadeOutCompleted()
    {
        if (!GameEventManager.instance) return;
        GameEventManager.instance.sceneEvents.TransitionCompleted();
    }
}
