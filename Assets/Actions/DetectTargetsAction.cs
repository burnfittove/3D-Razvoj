using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "DetectTargets", story: "Check if [Detector] has Targets", category: "Action", id: "134f372c13331231b5eb14af8235c6ee")]
public partial class DetectTargetsAction : Action
{
    [SerializeReference] public BlackboardVariable<DetectionController> Detector;

    protected override Status OnStart()
    {
        if (Detector.Type.IsValueType)
        {
            return Status.Failure;
        }
        // return Detector.ObjectValue is null || Detector.ObjectValue.Equals(null);
        return !Detector.Value.GetTarget() ? Status.Failure : Status.Success;
    }

    private Status Bad()
    {
        Debug.Log("Bad");
        return Status.Failure;
    }

    private Status Good()
    {
        Debug.Log("Success");
        return Status.Success;
    }
}

