using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour, IActivable
{
    [Header("Inputs")]
    public bool open;
    public float limitUp;
    public float limitDown;

    // -- Tools -- //
    bool wasOpen;

    void Start()
    {
        open = true;
        wasOpen = true;
    }

    void Update()
    {
        // For editor tests, avoid button in editor
        if (open != wasOpen)
        {
            SwitchDoor(open);
            wasOpen = open;
        }
    }


    void SwitchDoor(bool open)
    {
        this.open = open;

        if (open)
            LeanTween.moveY(gameObject, limitUp, 1f).setEase(LeanTweenType.easeOutSine);
        else
            LeanTween.moveY(gameObject, limitDown, 1f).setEase(LeanTweenType.easeOutSine);
    }

    public void Activate() => SwitchDoor(open=false);
}
