using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour, IActivable
{
    [Header("Inputs")]
    public bool open;
    public float limitUp;
    public float limitDown;
    public GameObject doorSticker;

    // -- Tools -- //
    bool wasOpen;

    void Start()
    {
        if (doorSticker != null)
            doorSticker.SetActive(false);
        wasOpen = !open;
    }

    void Update()
    {
        // For editor tests, avoid button in editor
        // if (open != wasOpen)
        // {
        //     SwitchDoor(open);
        //     wasOpen = open;
        // }
    }
    public void SwitchDoor(bool open)
    {
        this.open = !open;

        if (open)
        {
            if(doorSticker != null)
                doorSticker.SetActive(true);
            LeanTween.moveY(gameObject, limitUp, 1f).setEase(LeanTweenType.easeOutSine);
        }
        else
        {
            if (doorSticker != null)
                doorSticker.SetActive(false);
            LeanTween.moveY(gameObject, limitDown, 1f).setEase(LeanTweenType.easeOutSine);
        }
    }

    public void Activate() => SwitchDoor(open);
}
