using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Set Target Position", story: "Set [Position] to [Target] position", category: "Action/Blackboard", id: "8661daec140dcbd67e0f8d470d961753")]
public partial class SetTargetPositionAction : Action
{
    [SerializeReference] public BlackboardVariable<Vector3> Position;
    [SerializeReference] public BlackboardVariable<TargetDetectionController> Target;

    protected override Status OnStart()
    {
        Position.Value = Target.Value.GetTargetPosition();
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

