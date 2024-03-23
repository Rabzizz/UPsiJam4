using System;
using UnityEngine;
using UnityEngine.AI;

public class EnnemyController : MonoBehaviour
{
    [Header("Components")]
    public NavMeshAgent agent;

    [Header("Inputs")]
    [SerializeField]
    private Transform target;
    public bool follow;

    // -- Tools -- //
    Vector3 lastDestination;
    NavMeshPathStatus agentStatus;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        // For editor test
        if (follow && lastDestination != target.position)
        {
            SetDestinationToReach(target.position);
            lastDestination = target.position;
        }

        // Check for agent pathfinding problem
        if(agent.pathStatus != NavMeshPathStatus.PathComplete)
        {
            StopDestination();
        }
    }

    public void SetDestinationToReach(Vector3 position)
    {
        agent.SetDestination(position);
        agent.isStopped = false;
    }

    // Carful, also stop destination
    void StopDestination()
    {
        agent.destination = transform.position;
        agent.isStopped = true;

        // On peut faire + ici si jamais
    }

    public void StopAgent()
    {
        agent.isStopped = true;
    }
}
