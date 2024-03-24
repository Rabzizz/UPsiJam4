using UnityEngine;

public class DoorActivatorController : MonoBehaviour
{
    public DoorController door;

    private void OnMouseDown()
    {
        Debug.Log("Door activated");
        door.doorSticker.SetActive(true);
    }
}
