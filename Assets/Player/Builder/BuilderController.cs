using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class BuilderController : MonoBehaviour
{

    public InputActionReference InputBuild;
    public LayerMask layerMaskCCTV;
    public LayerMask layerMaskTrap;
    public float maxDistance;
    public List<GameObject> items;
    public int selectedItem = 0;

    RaycastHit hit;
    bool canBuildCCTV;
    bool canBuildTrap;

    public LayerMask layerMasksRemovable;
    RaycastHit hitRemove;
    RaycastHit hitTrap;
    bool canRemove;

    void Start()
    {
        InputBuild.action.canceled += (_) => Build();
        transform.parent.GetComponentInChildren<UIController>().OnElementSelected += (index) => selectedItem = (int)index;
    }

    private void FixedUpdate()
    {
        canBuildCCTV = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, maxDistance, layerMaskCCTV);
        canRemove = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitRemove, maxDistance, layerMasksRemovable);
        canBuildTrap = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitTrap, maxDistance, layerMaskTrap);

        if (canBuildCCTV)
            Debug.Log("Can cctv");
        if (canBuildTrap)
            Debug.Log("Can trap");
        if (canRemove)
            Debug.Log("Can Remove");
    }

    public void Build()
    {
        if (canRemove)
        {
            Destroy(hitRemove.transform.gameObject);
            return;
        }
        else
        {
            if (canBuildCCTV)
            {
                var itemBuilded = Instantiate(items[selectedItem], hit.point, Quaternion.identity);
                Vector3 direction = Vector3.Cross(hit.normal, Vector3.up).normalized;
                itemBuilded.transform.rotation = Quaternion.LookRotation(direction);
            }

            if (canBuildTrap)
            {
                var itemBuilded = Instantiate(items[selectedItem], hitTrap.point, Quaternion.identity);
            }
        }
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(hit.point, 0.1f);
    }
}
