using UnityEngine;

public class UnlockMainDoor : MonoBehaviour
{
    public GameObject displayTextComponent;
    public GameObject sceneChangeComponent;

    public bool isUnlocked;

    private void Start()
    {
        if (SpiritManager.instance.AllSpiritsCollected)
        {
            SetDoorState(false);
            return;
        }
        
        SetDoorState(true);
    }

    private void Update()
    {
        SetDoorState(isUnlocked);
    }

    private void SetDoorState(bool isLocked)
    {
        displayTextComponent.SetActive(!isLocked);
        sceneChangeComponent.SetActive(isLocked);
    }
}
