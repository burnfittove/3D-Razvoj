using System;
using System.Collections.Generic;
using System.Linq;
using Code.Managers;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMethods : MonoBehaviour
{
    public string nextScene;
    private List<Button> _buttons = new();

    private void Start()
    {
        var buttonObjects = GameObject.FindGameObjectsWithTag("ButtonUI");
        
        foreach (var button in buttonObjects)
        {
            button.TryGetComponent(out Button buttonComponent);
            if (!buttonComponent) continue;
            _buttons.Add(buttonComponent);
        }
    }

    public void ChangeScene(Transform nextSceneLocation)
    {
        var playerCharacter = GameObject.FindGameObjectWithTag("Player");
        if (!SceneChangeManager.instance)
        {
            Debug.LogError("SceneChangeManager not found in scene!");
            return;
        }

        if (!playerCharacter)
        {
            Debug.LogError("PlayerCharacter not found in scene!");
            return;
        }
        
        DisableAllButtons();
        SceneChangeManager.instance.AddObjectPosition(playerCharacter, nextSceneLocation.position);
        SceneChangeManager.instance.LoadScene(nextScene);
    }

    public void Quit()
    {
        DisableAllButtons();
        Application.Quit();
    }

    public void LoadFromCheckpoint()
    {
        if (!SaveDataManager.Instance)
        {
            Debug.LogError("SaveDataManager not found in scene!");
            return;
        }
        
        DisableAllButtons();
        SaveDataManager.Instance.LoadCheckpoint();
    }

    private void DisableAllButtons()
    {
        foreach (var button in _buttons.Where(button => button))
        {
            button.interactable = false;
        }
    }
}
