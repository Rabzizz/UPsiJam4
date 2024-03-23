using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public class NavmeshRuntimeBaker : MonoBehaviour
{
    public NavMeshSurface surface;

    private void Update()
    {
        // Heavy, significant changes (new map, surface changes)
        // Not optimal at all
        surface.BuildNavMesh();
        
        // Update with moving objects (obstacles)
        //surface.UpdateNavMesh(surface.navMeshData);
    }
}
