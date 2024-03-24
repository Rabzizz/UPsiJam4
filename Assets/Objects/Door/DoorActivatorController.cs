using UnityEngine;

public class DoorActivatorController : MonoBehaviour
{
    public DoorController door;
    public MinimapManager minimap;

    private void Start()
    {
        if(transform.GetComponentInParent<MinimapManager>() != null)
            minimap = transform.GetComponentInParent<MinimapManager>();
    }

    private void OnMouseDown()
    {
        Debug.Log("Door activated");

        minimap.AddDoor(door);
    }
}
