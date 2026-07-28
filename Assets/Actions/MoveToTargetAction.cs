using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using UnityEngine.AI;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "MoveToTarget", story: "Move [Enemy] to [Target]", category: "Action", id: "8b61d06d828c7239687f58cc51ed463b")]
public partial class MoveToTargetAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Enemy;
    [SerializeReference] public BlackboardVariable<Transform> Target;

    private NavMeshAgent agent;
    
    protected override Status OnStart()
    {
        agent = Enemy.Value.GetComponent<NavMeshAgent>();
        if (agent) agent.destination = Target.Value.position;
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

