using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public InputActionReference inputMovement;
    public float walkSpeed = 10f;

    private Rigidbody rb;
    private Vector2 inputMove;

    [SerializeField] private StudioEventEmitter fmodEvent;

    // Start is called before the first frame update
    void Start()
    {
        inputMovement.action.performed += (ctx) => Move(ctx.ReadValue<Vector2>());
        inputMovement.action.canceled += (ctx) => Move(new Vector2(0,0));

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        Vector3 playerVelocity = new Vector3(inputMove.x * walkSpeed, rb.velocity.y, inputMove.y * walkSpeed);
        rb.velocity = transform.TransformDirection(playerVelocity);
        if (inputMove.magnitude > 0)
        {
            if (!fmodEvent.IsPlaying()) fmodEvent.Play();
        }
        else
        {
            fmodEvent.Stop();
        }
    }

    public void Move(Vector2 inputMove)
    {
        this.inputMove = inputMove;
    }
}
