using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShaderController : MonoBehaviour
{
    [SerializeField] StudioEventEmitter OffSound;
    [SerializeField] StudioEventEmitter GlitchSound;
    [SerializeField]
    MeshRenderer m_Renderer;
    public void ActivateGlitch(float activate)
    {
        if(activate > 0f)
        {
            GlitchSound.Play();
        }
        else
        {
            OffSound.Play();
            transform.parent.GetComponent<StudioEventEmitter>().Stop();
        }
        m_Renderer.sharedMaterial.SetFloat("_ActivateInt", activate);
        m_Renderer.sharedMaterial.color = Color.black;
    }
}
