using UnityEngine;

public class DoorActivatorController : MonoBehaviour
{
    public DoorController door;
    public MinimapManager minimap;

    private void OnMouseDown()
    {
        Debug.Log("Door activated");

        minimap.AddDoor(door);
    }
}
