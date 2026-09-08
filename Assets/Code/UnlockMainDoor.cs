using UnityEngine;

public class UnlockMainDoor : MonoBehaviour
{
    public GameObject lockedText;
    public GameObject endGame;

    private void Start()
    {
        if (SpiritManager.instance.AllSpiritsCollected)
        {
            SetDoorState(false);
            return;
        }
        
        SetDoorState(true);
    }

    private void SetDoorState(bool isLocked)
    {
        lockedText.SetActive(isLocked);
        endGame.SetActive(!isLocked);
    }
}
