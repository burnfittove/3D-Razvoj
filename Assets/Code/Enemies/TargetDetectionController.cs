using System;
using UnityEngine;

public class TargetDetectionController : MonoBehaviour
{
    public Transform detectionAreaOrigin;
    public float detectionAreaRadius;
    public LayerMask targetMask;
    private FindTarget _findTarget;
    public bool HasTarget;
    
    private void Awake()
    {
        _findTarget = GetComponent<FindTarget>();
    }

    private void Update()
    {
        var colliders = Physics.OverlapSphere(detectionAreaOrigin.position, detectionAreaRadius, targetMask);

        if (colliders.Length <= 0 || !colliders[0])
        {
            HasTarget = false;
            return;
        }
        _findTarget.SetTarget(colliders[0].transform);
        HasTarget = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(detectionAreaOrigin.position, detectionAreaRadius);
    }
}
