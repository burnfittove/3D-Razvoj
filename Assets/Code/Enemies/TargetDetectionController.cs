using UnityEngine;

public class TargetDetectionController : MonoBehaviour
{
    public Transform detectionAreaOrigin;
    public float detectionAreaRadius;
    public LayerMask targetMask;
    public bool HasTarget;
    public Vector3 _lastSeenPosition;

    private void Update()
    {
        var colliders = Physics.OverlapSphere(detectionAreaOrigin.position, detectionAreaRadius, targetMask);

        if (colliders.Length <= 0 || !colliders[0])
        {
            HasTarget = false;
            return;
        }
        _lastSeenPosition = colliders[0].transform.position;
        HasTarget = true;
    }

    public Vector3 GetTargetPosition()
    {
        return _lastSeenPosition;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(detectionAreaOrigin.position, detectionAreaRadius);
    }
}
