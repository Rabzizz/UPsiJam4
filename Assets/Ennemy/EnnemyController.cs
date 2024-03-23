using UnityEngine;
using UnityEngine.AI;

public class EnnemyController : MonoBehaviour
{
    [Header("Components")]
    public NavMeshAgent agent;

    [Header("Inputs")]
    private Vector3 targetPosition;
    public Vector3 TargetPosition { 
        get => targetPosition;
        set
        {
            SetPositionToReach(targetPosition);
        }
    }

    void SetPositionToReach(Vector3 position)
    {
        agent.SetDestination(position);
    }
}
