using Code.Cutscene;
using UnityEngine;

public class NextCutsceneStep : MonoBehaviour
{
    public void NextStep()
    {
        var cutsceneManager = CutsceneManager.instance;
        if (!cutsceneManager) return;
        cutsceneManager.UpdateStep();
    }
}
