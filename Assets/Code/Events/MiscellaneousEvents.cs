using System;
using UnityEngine;

public class MiscellaneousEvents
{
    public event Action SpiritCollected;
    public void OnSpiritCollected() => SpiritCollected?.Invoke();
    
    public event Action<Vector3> SceneLoadLocationSet;
    public void OnSceneLoadLocationSet(Vector3 location) => SceneLoadLocationSet?.Invoke(location);
}
