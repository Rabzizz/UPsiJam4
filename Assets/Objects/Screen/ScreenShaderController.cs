using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShaderController : MonoBehaviour
{
    public void ActivateGlitch(int activate)
    {
        GetComponent<Renderer>().material.SetInteger("Activate", activate);
    }
}
