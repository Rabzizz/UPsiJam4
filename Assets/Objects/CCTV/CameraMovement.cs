using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;
using static UnityEngine.EventSystems.StandaloneInputModule;

public class CameraMovement : MonoBehaviour
{

    public InputActionReference inputLook;
    public InputActionReference inputValidate;
    public float mouseSensitivity = 50f;

    [SerializeField] private Camera setupCamera;
    [SerializeField] public Camera viewCamera;

    [SerializeField] private bool moving;
    [SerializeField] private Vector2 lookVector;
    private float xRotation = 0f;
    private float yRotation = 0f;
    private Camera mainCamera;
    private bool isValidate = false;


    public MeshRenderer meshRender;
    public Material material;
    public bool hasBeenSeen;
    // Start
    void Start()
    {
        if (!GameManager.Instance.SetCCTVTarget(viewCamera))
        {
            Destroy(this);
        }

        GetComponents<Camera>().ToList().ForEach(c => c.enabled = false);

        mainCamera = Camera.main;
        mainCamera.enabled = false;
        setupCamera.enabled = true;
        
        inputLook.action.performed += (ctx) => Look(ctx.ReadValue<Vector2>());
        inputLook.action.canceled += (ctx) => moving = false;

        inputValidate.action.canceled += (_) => { if (!isValidate) Validate(); };

        PlayerInputSystemController.Instance.SwitchToActionMap(ActionMap.CCTVCamera);
    }

    private void OnDestroy()
    {

        meshRender.gameObject.GetComponent<ScreenShaderController>().ActivateGlitch(0f);
        inputLook.action.performed -= (ctx) => Look(ctx.ReadValue<Vector2>());
        inputLook.action.canceled -= (ctx) => moving = false;

        inputValidate.action.canceled -= (_) => Validate();
        GameManager.Instance.ReTakeTarget(viewCamera);
    }

    // Update is called once per frame
    void Update()
    {
        if (moving && !isValidate)
        {
            float mouseX = -lookVector.x * mouseSensitivity * Time.deltaTime;
            float mouseY = lookVector.y * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            yRotation -= mouseX;
            yRotation = Mathf.Clamp(yRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(0f, yRotation, xRotation);
        }

    }

    public void Look(Vector2 valueXY)
    {
        moving = true;
        lookVector = valueXY;
    }

    public void Validate()
    {
        setupCamera.enabled = false;
        mainCamera.enabled = true;
        isValidate = true;
        PlayerInputSystemController.Instance.SwitchToActionMap(ActionMap.Character);
    }

    public void MonsterInView()
    {
        if(!hasBeenSeen)
        {
            meshRender.gameObject.GetComponent<ScreenShaderController>().ActivateGlitch(1f);
            LeanTween.delayedCall(3.47f, () => Destroy(transform.parent.gameObject));
        }
    }
}
