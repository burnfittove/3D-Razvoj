using System;
using UnityEngine;

public class MiscellaneousEvents
{
    public event Action SpiritCollected;
    public void OnSpiritCollected() => SpiritCollected?.Invoke();
}
