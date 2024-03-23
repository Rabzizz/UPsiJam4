using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.EventSystems.StandaloneInputModule;

public class CameraMovement : MonoBehaviour
{

    public InputActionReference InputLook;
    public InputActionReference InputValidate;
    public float mouseSensitivity = 50f;

    [SerializeField] private Camera setupCamera;

    [SerializeField] private bool moving;
    [SerializeField] private Vector2 lookVector;
    private float xRotation = 0f;
    private float yRotation = 0f;
    private Camera mainCamera;

    // Start
    void Start()
    {
        GetComponents<Camera>().ToList().ForEach(c => c.enabled = false);

        mainCamera = Camera.main;
        Camera.main.enabled = false;
        setupCamera.enabled = true;
        
        InputLook.action.performed += (ctx) => Look(ctx.ReadValue<Vector2>());
        InputLook.action.canceled += (ctx) => moving = false;

        InputValidate.action.performed += (_) => Validate();

        PlayerInputSystemController.Instance.SwitchToActionMap(ActionMap.CCTVCamera);
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
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
        PlayerInputSystemController.Instance.SwitchToActionMap(ActionMap.Character);

    }
}
