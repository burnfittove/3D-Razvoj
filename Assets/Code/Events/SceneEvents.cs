using System;
using UnityEngine;

public class SceneEvents
{
    public event Action<string> SceneLoad;
    public void OnSceneLoad(string sceneName)
    {
        SceneLoad?.Invoke(sceneName);
    }
    
    public event Action SceneLoaded;
    public void OnSceneLoaded()
    {
        SceneLoaded?.Invoke();
    }
}
