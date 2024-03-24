using System;
using System.Collections.Generic;
using System.Linq;
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
    [SerializeField]
    private List<CameraMovement> cctvCameras = new List<CameraMovement>();

    // -- Tools -- //
    Vector3 lastDestination;
    NavMeshPathStatus agentStatus;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        foreach(var cctvCam in FindObjectsByType<CameraMovement>(FindObjectsSortMode.None))
        {
            Physics.Raycast(transform.position, (cctvCam.transform.position - transform.position).normalized, out var hit, Mathf.Infinity);
            if (hit.transform.gameObject.GetComponentInChildren<CameraMovement>())
            {
                cctvCam.MonsterInView();
                cctvCam.hasBeenSeen = true;
            }
            Debug.DrawRay(transform.position, (cctvCam.transform.position - transform.position).normalized * 1000, Color.red);
        };


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

    // ------------- Navigation ------------- //

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
        Debug.Log("Ennemy has no more path");
    }
        
    // ------------- Traps and other ------------- //

    public void HitFromTrap()
    {
        Debug.Log("Ennemy is hit");
    }
}
