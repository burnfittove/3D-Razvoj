using UnityEngine;

public class FindTarget : MonoBehaviour
{
    [HideInInspector] public GameObject targetObject;

    public void SetTarget(GameObject newTarget)
    {
        if (!newTarget) targetObject = null;
        targetObject = newTarget;
    }

    public GameObject GetTarget()
    {
        return targetObject;
    }
}
