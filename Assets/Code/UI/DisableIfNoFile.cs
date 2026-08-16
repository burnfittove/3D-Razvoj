using Code.Managers;
using UnityEngine;
using UnityEngine.UI;

public class DisableIfNoFile : MonoBehaviour
{
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void Start()
    {
        if (!SaveDataManager.Instance)
        {
            Debug.LogError("Couldn't find SaveDataManager!", this);
            return;
        }

        _button.interactable = SaveDataManager.Instance.DoesFileExists();
    }
}
