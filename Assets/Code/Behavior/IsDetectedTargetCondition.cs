using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "IsDetectedTarget", story: "Agent is in proximity to [Target]", category: "Conditions", id: "a13ce46e92d98f777772072f4429fd9a")]
public partial class IsDetectedTargetCondition : Condition
{
    [SerializeReference] public BlackboardVariable<FindTarget> Target;

    public override bool IsTrue()
    {
        if (Target.Type.IsValueType) return false;
        return true;
    }

    public override void OnStart()
    {
    }

    public override void OnEnd()
    {
    }
}
