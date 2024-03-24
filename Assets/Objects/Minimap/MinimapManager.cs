using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public class MinimapManager : MonoBehaviour
{
    public MeshFilter floorObject;

    public List<GameObject> elements;

    public GameObject doorSymbol;

    public void AddDoor(DoorController door)
    {
        SpawnElementOnMinimap(door.transform, Color.blue, true, door);
    }

    public void AddTrap(TrapController trap)
    {
        SpawnElementOnMinimap(trap.transform, Color.red, true, trap);
    }

    public void AddCCTV(CameraMovement cctv)
    {
        SpawnElementOnMinimap(cctv.transform, Color.green, false);
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

    public void SpawnElementOnMiniMap(Transform transform)
    {

    }

    public void ClearMinimap()
    {
        foreach(GameObject element in elements)
        {
            Destroy(element);
        }

        elements.Clear();
    }
}
