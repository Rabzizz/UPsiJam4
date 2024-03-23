using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathFindAgentController : MonoBehaviour
{
    [Header("Components")]
    public NavMeshAgent agent;

    [Header("Inputs")]
    public Transform target; // Plutot Vector3 a voir

    private void Update()
    {
        agent.SetDestination(target.position);
    }
}
