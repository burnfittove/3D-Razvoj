using System;
using UnityEngine;

public class SceneEvents
{
    public event Action<string> OnSceneLoad;
    public void SceneLoad(string sceneName)
    {
        OnSceneLoad?.Invoke(sceneName);
    }
    
    public event Action OnTransitionStarted;
    public void TransitionStarted()
    {
        OnTransitionStarted?.Invoke();
    }
    
    public event Action OnTransitionCompleted;
    public void TransitionCompleted()
    {
        OnTransitionCompleted?.Invoke();
    }
    
    public event Action OnFadeInCompleted;
    public void FadeInCompleted()
    {
        OnFadeInCompleted?.Invoke();
    }
}
