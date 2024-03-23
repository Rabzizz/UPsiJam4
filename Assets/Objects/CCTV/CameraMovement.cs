using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.EventSystems.StandaloneInputModule;

public class CameraMovement : MonoBehaviour
{

    public InputActionReference InputLook;
    public float mouseSensitivity = 50f;


    [SerializeField] private bool moving;
    [SerializeField] private Vector2 inputLook;
    private float xRotation = 0f;
    private float yRotation = 0f;

    // Start
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        InputLook.action.performed += (ctx) => Look(ctx.ReadValue<Vector2>());
        InputLook.action.canceled += (ctx) => moving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            float mouseX = -inputLook.x * mouseSensitivity * Time.deltaTime;
            float mouseY = inputLook.y * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            yRotation -= mouseX;
            yRotation = Mathf.Clamp(yRotation, -180f, 0f);

            transform.localRotation = Quaternion.Euler(0f, yRotation, xRotation);
        }

    }

    public void Look(Vector2 valueXY)
    {
        moving = true;
        inputLook = valueXY;
    }
}
