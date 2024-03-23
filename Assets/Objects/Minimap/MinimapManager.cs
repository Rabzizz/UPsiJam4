using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public class MinimapManager : MonoBehaviour
{
    public MeshFilter floorObject;

    //public List<IActivable> activables;

    public List<DoorController> doors;
    public List<TrapController> traps;
    public List<CameraMovement> cctvs;

    public List<GameObject> elements;

    private void Start()
    {
        Bounds bounds = floorObject.sharedMesh.bounds;

        Vector3 temp = bounds.size * 50;
        temp.y = 0.1f;
        transform.localScale = temp;

        // test
        Refresh();
    }

    public void Refresh()
    {
        // Clear
        foreach(GameObject element in elements)
        {
            Destroy(element);
        }

        // Add all
        foreach(DoorController door in doors)
        {
            SpawnElementOnMinimap(door.transform, Color.blue, true, door);
        }

        foreach(TrapController trap in traps)
        {
            SpawnElementOnMinimap(trap.transform, Color.red, true, trap);
        }

        foreach(CameraMovement cctv in cctvs)
        {
            SpawnElementOnMinimap(cctv.transform, Color.green, false);
        }
    }

    public void SpawnElementOnMinimap(Transform elementRefTransform, Color color, bool clickable, IActivable activable=null)
    {
        Vector3 origin = floorObject.transform.position;
        Vector3 minimapOrigin = transform.position;

        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.localScale = Vector3.one * 0.1f;
        sphere.GetComponent<Renderer>().material.color = color;
        sphere.transform.parent = transform;

        Vector3 delta = elementRefTransform.transform.position - origin;
        delta /= 50;
        Vector3 localPos = transform.InverseTransformPoint(minimapOrigin + delta);
        sphere.transform.localPosition = localPos;

        // If clickable call event
        if(clickable)
        {
            ClickableMinimapElement clickableElement = sphere.AddComponent<ClickableMinimapElement>();
            clickableElement.OnClick += (s,e) => activable.Activate();
        }

        // Add for next clear
        elements.Add(sphere);
    }
}
