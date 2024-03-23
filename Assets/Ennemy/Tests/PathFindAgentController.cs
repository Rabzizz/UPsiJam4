using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// We won't use this, as we don't have camera. This is just a test exemple
// We just need to send position for ennemy
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
