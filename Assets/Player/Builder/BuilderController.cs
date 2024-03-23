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
    bool canBuild;

    void Start()
    {
        InputBuild.action.canceled += (_) => Build();
    }

    private void FixedUpdate()
    {
        canBuild = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, maxDistance, layerMasks);
    }

    public void Build()
    {
        if (canBuild)
        {
            var itemBuilded = Instantiate(items[selectedItem], hit.point, Quaternion.identity);

            var direction = Vector3.Cross(hit.normal, Vector3.up).normalized;

            itemBuilded.transform.rotation = Quaternion.LookRotation(direction);
        }
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(hit.point, 0.1f);
    }
}
