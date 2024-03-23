using System.Collections.Generic;
using UnityEngine;

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
        //Refresh();
    }

    private void Update()
    {
        Refresh();
    }

    public void Refresh()
    {
        foreach(GameObject element in elements)
        {
            Destroy(element);
        }

        Vector3 origin = floorObject.transform.position;
        Vector3 minimapOrigin = transform.position;

        foreach(DoorController door in doors)
        {
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.localScale = Vector3.one * 0.1f;
            sphere.GetComponent<Renderer>().material.color = Color.blue;
            sphere.transform.parent = transform;

            //sphere.transform.position = new Vector3(door.transform.position.x, door.transform.position.z, 0) / 50;
            Vector3 delta = door.transform.position - origin;
            delta /= 50;
            sphere.transform.position = minimapOrigin + delta; // local + inverttransform

            elements.Add(sphere);
        }

        foreach(TrapController trap in traps)
        {
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.localScale = Vector3.one * 0.1f;
            sphere.GetComponent<Renderer>().material.color = Color.red;
            sphere.transform.parent = transform;

            //sphere.transform.position = new Vector3(door.transform.position.x, door.transform.position.z, 0) / 50;
            Vector3 delta = trap.transform.position - origin;
            delta /= 50;
            sphere.transform.position = minimapOrigin + delta;

            elements.Add(sphere);
        }

        foreach(CameraMovement cctv in cctvs)
        {

        }
    }
}
