using UnityEngine;

public class TurnAroundPoint : MonoBehaviour
{
    public float degreesPerSecond;
    public Transform target;
    
    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(target.position, Vector3.up, degreesPerSecond * Time.deltaTime);
    }
}
