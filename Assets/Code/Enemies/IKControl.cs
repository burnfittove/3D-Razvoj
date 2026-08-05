using UnityEngine;

public class IKControl : MonoBehaviour
{
    public Animator _animator;
    public Transform rightHand;
    public Transform scythe;

    private void OnAnimatorIK(int layerIndex)
    {
        if (!_animator) return;
        _animator.SetLookAtWeight(1);
        _animator.SetLookAtPosition(rightHand.position);
    }
}
