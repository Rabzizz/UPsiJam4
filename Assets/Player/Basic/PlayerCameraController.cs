using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.EventSystems.StandaloneInputModule;

public class PlayerCameraController : MonoBehaviour
{

    public InputActionReference inputLook;
    public float mouseSensitivity = 50f;
    public Transform playerTransform;

    private Vector2 lookVector;
    private float xRotation = 0f;

    // Start
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        inputLook.action.performed += (ctx) => Look(ctx.ReadValue<Vector2>());
        inputLook.action.canceled += (ctx) => Look(new Vector2());
    }

    // Update is called once per frame
    void Update()
    {
        //if (moving)
        //{
            float mouseX = lookVector.x * mouseSensitivity * Time.deltaTime;
            float mouseY = lookVector.y * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 45f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerTransform.Rotate(Vector3.up * mouseX);
        //}
    }

    public void Look(Vector2 valueXY)
    {
        lookVector = valueXY;
    }
}
