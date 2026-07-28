using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "MoveToTarget", story: "Move [Enemy] to [Target]", category: "Action", id: "8b61d06d828c7239687f58cc51ed463b")]
public partial class MoveToTargetAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Enemy;
    [SerializeReference] public BlackboardVariable<Transform> Target;

    protected override Status OnStart()
    {
        Debug.Log(Target.Value.name);
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        Debug.Log(Target.Value.position);
        return Status.Success;

    }

    protected override void OnEnd()
    {
    }
}

