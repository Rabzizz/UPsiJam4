using System;
using UnityEngine;

public class ClickableMinimapElement : MonoBehaviour
{
    public event EventHandler OnClick;
    public GameObject doorController;

    private void OnMouseDown()
    {
        doorController.GetComponent<DoorController>().Activate();
    }
}
