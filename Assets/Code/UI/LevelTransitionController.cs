using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransitionController : MonoBehaviour
{
    public Animator _animator;

    private void Start()
    {
        if (!GameEventManager.instance) return;
        GameEventManager.instance.sceneEvents.OnTransitionStarted += TransitionStartedHandler;
        SceneManager.sceneLoaded += FadeOut;
    }

    private void FadeOut(Scene arg0, LoadSceneMode arg1)
    {
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
