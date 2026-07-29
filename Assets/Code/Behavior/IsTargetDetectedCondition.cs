using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "Is Target Detected", story: "Agent is in proximity to [Target]", category: "Conditions", id: "0fbc1d1d411b5c0b69fddedcc7baddbb")]
public partial class IsTargetDetectedCondition : Condition
{
    [SerializeReference] public BlackboardVariable<TargetDetectionController> Target;

    public override bool IsTrue()
    {
        return Target.Value.HasTarget;
    }

    public override void OnStart()
    {
    }

    public override void OnEnd()
    {
    }
}
