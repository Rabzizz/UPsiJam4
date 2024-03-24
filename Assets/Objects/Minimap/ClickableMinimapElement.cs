using System;
using UnityEngine;

public class ClickableMinimapElement : MonoBehaviour
{
    public event EventHandler OnClick;
    public GameObject doorController;

    private void OnMouseDown()
    {
        if(GameManager.Instance.gameState == GameState.Phase2)
            doorController.GetComponent<DoorController>().Activate();
    }
}
