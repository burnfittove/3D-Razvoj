using System;
using UnityEngine;

public class SceneEvents
{
    public event Action<string> OnSceneLoad;
    public void SceneLoad(string sceneName)
    {
        OnSceneLoad?.Invoke(sceneName);
    }
    
    public event Action OnFadeOut;
    public void FadeOut()
    {
        OnFadeOut?.Invoke();
    }
    
    public event Action OnFadeIn;
    public void FadeIn()
    {
        OnFadeIn?.Invoke();
    }
}
