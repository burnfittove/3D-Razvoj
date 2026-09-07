using System;
using Code.Cutscene;
using UnityEngine;
using UnityEngine.UI;

public class NextCutsceneStep : MonoBehaviour
{
    private Button button;

    private void Awake()
    {
        TryGetComponent(out button);
    }

    private void Start()
    {
        GameEventManager.instance.sceneEvents.OnSceneLoad += _ => button.interactable = false;
    }

    public void NextStep()
    {
        var cutsceneManager = CutsceneManager.instance;
        if (!cutsceneManager) return;
        cutsceneManager.UpdateStep();
    }
}
