using UnityEngine;

public class DisplayTextOnContact : MonoBehaviour
{
    public string text;
    public float time;

    private void OnTriggerEnter(Collider other)
    {
        if (!GameEventManager.instance)
        {
            Debug.LogWarning("Couldn't find GameEventManager");
            return;
        }
        
        GameEventManager.instance.textEvents.OnDisplayText(text, time);
    }
}
