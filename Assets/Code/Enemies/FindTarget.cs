using UnityEngine;

public class FindTarget : MonoBehaviour
{
    [HideInInspector] public Vector3 targetPosition;

    public void SetTarget(Transform newTarget)
    {
        if (!newTarget) targetPosition = Vector3.zero;
        targetPosition = newTarget.position;
    }
}
