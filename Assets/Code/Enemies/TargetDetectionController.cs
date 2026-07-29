using UnityEngine;

public class TargetDetectionController : MonoBehaviour
{
    public Transform detectionAreaOrigin;
    public float detectionAreaRadius;
    public LayerMask targetMask;
    private FindTarget _findTarget;
    
    private void Awake()
    {
        _findTarget = GetComponent<FindTarget>();
    }

    private void Update()
    {
        var colliders = Physics.OverlapSphere(detectionAreaOrigin.position, detectionAreaRadius, targetMask);

        if (colliders.Length <= 0 || !colliders[0]) return;
        _findTarget.SetTarget(colliders[0].transform);
    }
}
