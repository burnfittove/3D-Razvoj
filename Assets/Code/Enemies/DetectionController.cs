using System;
using UnityEngine;

public class DetectionController : MonoBehaviour
{
    public Transform detectionAreaOrigin;
    public float detectionAreaRadius;
    public LayerMask detectionLayerMask;
    private Collider[] colliders;
    public Transform target;
    
    private void Update()
    {
        colliders = Physics.OverlapSphere(detectionAreaOrigin.position, detectionAreaRadius, detectionLayerMask);   // Detect the player
        if (colliders == null || colliders.Length == 0) // If the player isn't nearby...
        {
            target = null;  // reset the target and...
            return;         // return.
        }
        target = colliders[0].transform;    // Otherwise, set the transform as the target.
    }

    public Transform GetTarget()
    {
        return !target ? null : target;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(detectionAreaOrigin.position, detectionAreaRadius);
    }
}
