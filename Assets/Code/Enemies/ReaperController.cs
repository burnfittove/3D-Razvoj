using System;
using UnityEngine;
using UnityEngine.AI;

public class ReaperController : MonoBehaviour
{
    [SerializeField] private float damage;
    public float Damage { get; private set; }
    private NavMeshAgent agent;

    private void Awake()
    {
        Damage = damage;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        GameEventManager.instance.sceneEvents.OnTransitionStarted += DisableAgent;
    }

    private void DisableAgent()
    {
        agent.speed = 0;
        agent.angularSpeed = 0;
    }
}
