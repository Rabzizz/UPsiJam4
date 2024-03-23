using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BuilderController : MonoBehaviour
{

    public InputActionReference InputBuild;
    public LayerMask layerMasks;
    public float maxDistance;
    public List<GameObject> items;
    public int selectedItem = 0;

    RaycastHit hit;

    void Start()
    {
        InputBuild.action.performed += (_) => Build();
    }

    private void FixedUpdate()
    {
        Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, maxDistance, layerMasks);
    }

    public void Build()
    {
        Instantiate(items[selectedItem], hit.point, Quaternion.Euler(-hit.normal));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(hit.point, 0.1f);
    }
}
