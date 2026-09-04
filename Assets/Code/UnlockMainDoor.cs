using UnityEngine;

public class UnlockMainDoor : MonoBehaviour
{
    private DisplayTextOnContact displayTextComponent;
    private TouchSceneChange sceneChangeComponent;

    private void Awake()
    {
        TryGetComponent(out displayTextComponent);
        TryGetComponent(out sceneChangeComponent);
    }

    private void Start()
    {
        if (SpiritManager.instance.AllSpiritsCollected)
        {
            SetDoorState(true);
            return;
        }
        
        SetDoorState(false);
    }
    
    private void SetDoorState(bool isLocked)
    {
        displayTextComponent.enabled = isLocked;
        sceneChangeComponent.enabled = !isLocked;
    }
}
