using System;
using UnityEngine;

public class SceneEvents
{
    public event Action<string> SceneLoad;
    public void OnSceneLoad(string sceneName)
    {
        SceneLoad?.Invoke(sceneName);
    }
}
