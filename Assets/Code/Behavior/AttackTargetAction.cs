using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Attack Target", story: "[Agent] attacks [AgentTarget] for damage", category: "Action", id: "eb3bbf86f00af60040899baf43bd28a9")]
public partial class AttackTargetAction : Action
{
    [SerializeReference] public BlackboardVariable<ReaperController> Agent;
    [SerializeReference] public BlackboardVariable<TargetDetectionController> AgentTarget;
    private PlayerHealthComponent _playerHealthComponent;
    
    protected override Status OnStart()
    {
        AgentTarget.Value.foundTarget.TryGetComponent(out _playerHealthComponent);       
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        _playerHealthComponent?.TakeDamage(Agent.Value.Damage);
        Debug.Log("did damage.");
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

