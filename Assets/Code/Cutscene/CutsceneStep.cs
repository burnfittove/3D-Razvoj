using JetBrains.Annotations;
using UnityEngine;

[CreateAssetMenu(fileName = "CutsceneStep", menuName = "Cutscene/CutsceneStep")]
public class CutsceneStep : ScriptableObject
{
    public Texture2D stepImage;
    public string stepText;
    [CanBeNull] public CutsceneStep nextStep;
}
