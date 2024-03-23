using UnityEngine;

// This is used for first person control. TODO centralize content in MoveController + switch between this and CharacterMoveController(Third) => + clean
// but this class could be used to configure and manage the whole player
public class PlayerController : MonoBehaviour
{
    //// -- Inputs

    //public float speed = 1f;
    //public float rotationSpeed = 20f;
    //public float jumpForce = 5f;

    //[Tooltip("Prevent character from moving")]
    //public bool disableMove = false;

    //// -- Events

    //public UnityEvent<bool> OnIsMovingStatusChanged;

    //// -- Components

    //new Rigidbody rigidbody;
    //Animator animator;
    //PlayerInput inputs;

    //// -- Tools

    //Vector2 inputMove = Vector2.zero;
    //Vector2 inputLook = Vector2.zero;

    //float sprintFactor = 1;

    //// Jump

    //bool isJumping = false;
    //bool isFalling = false;
    //Vector2 appliedMove = Vector2.zero;

    //private void Start()
    //{
    //    animator = GetComponent<Animator>();
    //    rigidbody = GetComponent<Rigidbody>();
    //    inputs = GetComponent<PlayerInput>();
    //}

    //private void Update()
    //{
    //    animator.SetFloat("Move", appliedMove.y * sprintFactor);
    //    animator.SetFloat("MoveHorizontal", appliedMove.x);

        

    //    //Can we use: rigidbody.detectCollisions? to detecte side collision?
    //}

    //private void FixedUpdate()
    //{
    //    transform.Rotate(Vector3.up * inputLook.x * rotationSpeed);//* Time.deltaTime * rotationSpeed);
    //}

    //// ---- Ground trigger ---- //
    //// TODO: move to the foot so it follow the player jump position
    ////https://answers.unity.com/questions/196381/how-do-i-check-if-my-rigidbody-player-is-grounded.html

    //private void OnTriggerStay(Collider other)
    //{
    //    ResetJump();
        
    //    //Debug.Log(isFalling + " / " + isJumping);
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    float speedBeforeFalling = 2f; // TODO as parameter => + todo distance with raycast maybe is better?
    //    if (rigidbody.velocity.y < speedBeforeFalling || isFalling == true)
    //        return;

    //    // Reset move
    //    appliedMove = Vector2.zero;

    //    // Set states and anim
    //    isFalling = true;
    //    isJumping = false;

    //    animator.SetTrigger("Jump");
    //    animator.SetBool("Fall", true);

    //    //Debug.Log(animator.GetCurrentAnimatorStateInfo(0).le);
    //    //animator.Play()
    //    //Debug.Log(isFalling + " / " + isJumping);
    //}

    //private void ResetJump()
    //{
    //    // !! TODO fix: !!
    //    // isfallin = true, isjumpig = false
    //    // but isFalling is getting false then.... HOWWWWW ????
    //    // I think isJumping is getting true before, somewhere else but is neither possible
    //    if (isFalling && !isJumping)
    //    {
    //        isFalling = false;
    //        isJumping = false;

    //        animator.SetBool("Fall", false);
    //        animator.applyRootMotion = true;

    //        appliedMove = inputMove;
    //    }
    //}

    //// --------- Inputs -------- //

    //public void OnMove(InputValue value)
    //{
    //    // Just optimize
    //    Vector2 receiveValue = value.Get<Vector2>();

    //    // break if move is disabled or falling
    //    if (disableMove || (isFalling && receiveValue.magnitude != 0))
    //        return;

    //    inputMove = receiveValue;
    //    appliedMove = inputMove;

    //    CheckStatus();
    //}

    //public void OnLook(InputValue value)
    //{
    //    inputLook = value.Get<Vector2>();

    //    CheckStatus();
    //}

    //public void OnJump(InputValue value)
    //{
    //    if (value.isPressed && !isFalling && !isJumping)
    //    {
    //        // Deactivate root motion, else velocity is not changed in x/z
    //        animator.applyRootMotion = false;

    //        // Apply velocity from current animation
    //        rigidbody.velocity = animator.velocity;

    //        // Maybe not only on y but on opposite of current surface, would make more sense
    //        Vector3 moveVector = new Vector3(0f, jumpForce, 0f);
    //        rigidbody.AddForce(moveVector, ForceMode.Impulse);

    //        isJumping = true;
    //        // => State is then changed in trigger exit (when player exit the ground)
    //    }
    //}

    //public void OnUse(InputValue value)
    //{
    //    //Debug.Log(value.Get());
    //}

    //public void OnSprint(InputValue value)
    //{
    //    sprintFactor = value.isPressed ? 2 : 1;
    //}

    //private void CheckStatus()
    //{
    //    bool isMoving = inputMove.magnitude != 0 || inputLook.magnitude != 0 || rigidbody.velocity.y != 0; // TODO use rigidbodies only?
    //    OnIsMovingStatusChanged.Invoke(isMoving);
    //}

    //// ---- Animation handlers ---- //

    //public void FootR()
    //{

    //}

    //public void FootL()
    //{

    //}

    //// Tools

    //public InputActionReference GetInputActionReference(string name)
    //{
    //    InputAction found = default;
    //    foreach (InputAction action in inputs.actions.actionMaps[0].actions)
    //    {
    //        if (action.name.Contains(name))
    //            found = action;
    //    }

    //    return InputActionReference.Create(found);
    //}
}
