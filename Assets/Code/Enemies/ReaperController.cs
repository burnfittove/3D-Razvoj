using System;
using UnityEngine;

public class ReaperController : MonoBehaviour
{
    [SerializeField] private float damage;
    public float Damage { get; private set; }

    private void Awake()
    {
        Damage = damage;
    }
}
