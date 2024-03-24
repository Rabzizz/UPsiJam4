using System;
using UnityEngine;

public class ClickableMinimapElement : MonoBehaviour
{
    public event EventHandler OnClick;

    private void OnMouseDown()
    {
        OnClick?.Invoke(this, EventArgs.Empty);
    }
}
