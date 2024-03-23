using UnityEngine;

// -- Main move controller --
// Handles the main moves input catchings and algorithmes
public class MoveController : MonoBehaviour
{
    //[Header("Components")]
    //public new Rigidbody rigidbody;
    //public CharacterAnimationController animations;

    //[Header("Parameters")]
    //public float speed = 1f;
    //public float rotationSpeed = 2f;

    //[Header("Handlers")]
    //// Mainly for death, cutscenes, etc
    //public bool isAllowToMove;

    //// -- Tools -- //
    //float speedFactor = 1;

    //Vector2 inputMove = Vector2.zero;
    //Vector2 inputLook = Vector2.zero;

    //float inputAngle = 0f;
    //Vector2 appliedMove = Vector2.zero;

    //bool isRunning = true;
    //bool isSprinting = false;
    //bool isGrounded = true;

    //public CameraMode cameraMode = CameraMode.ThirdPerson;
    //public Transform targetToWatch;

    //// -- Outputs -- //
    //[HideInInspector]
    //public float InputAngle => inputAngle;
    //[HideInInspector]
    //public Vector2 AppliedMove => appliedMove; // maybe clone
    //[HideInInspector]
    //public bool IsGrounded => isGrounded;

    //// ---------- Main ---------- //

    //private void Update()
    //{
    //    if (!isAllowToMove)
    //        return;

    //    // Character won't move if not grounded
    //    if(isGrounded)
    //        animations.Move(appliedMove);

    //    // Calculate direction from aiming
    //    switch (cameraMode)
    //    {
    //        case CameraMode.FreeLook:   
    //            CalculateDirectionFromDirectionLook();
    //            break;
    //        case CameraMode.TargetLook:
    //            CalculateDirectionFromTarget();
    //            break;
    //    }
    //}

    //private void FixedUpdate()
    //{
    //    if (!isAllowToMove)
    //        return;

    //    // -- 1st / 3rd --
    //    if (cameraMode == CameraMode.FirstPerson || cameraMode == CameraMode.ThirdPerson) // Link
    //    {
    //        // Calculez la rotation cible en fonction de l'entrée
    //        Quaternion inputRotation = Quaternion.Euler(0f, inputLook.x * rotationSpeed, 0f);

    //        // Interpolez de manière fluide vers la rotation cible
    //        rigidbody.transform.rotation = Quaternion.Lerp(rigidbody.rotation, rigidbody.rotation * inputRotation, 10f * Time.fixedDeltaTime);
    //    }

    //    // -- FreeLook -- 
    //    else if((cameraMode == CameraMode.FreeLook || cameraMode == CameraMode.TargetLook) // LinkOnMove
    //            && inputMove.magnitude > 0.1f) {
    //        rigidbody.transform.rotation = Quaternion.Euler(0f, inputAngle, 0f);
    //    }
    //}

    //// ---------- Inputs ---------- //

    //public void Look(Vector2 valueXY)
    //{
    //    inputLook = valueXY;
    //}

    //public void Move(Vector2 valueXZ)
    //{
    //    inputMove = valueXZ;
    //    CalculateMove();
    //}

    //public void Sprint(bool sprint)
    //{
    //    isSprinting = sprint;
    //    CalculateMove();
    //}

    //public void SwitchWalkRun(bool run)
    //{
    //    isRunning = run;
    //    CalculateMove();
    //}

    //// ---------- Tools ---------- //

    //void CalculateMove()
    //{
    //    // Calcul move with parameters
    //    if (isSprinting)
    //        speedFactor = 2;
    //    else if (isRunning)
    //        speedFactor = 1;
    //    else
    //        speedFactor = 0.5f;

    //    appliedMove = new Vector2(inputMove.y * speedFactor, inputMove.x);
    //}

    //// Calculate rotation of player from camera direction on Free Camera
    //float rotationSmoothTime = 0.01f;   // DONT FUCKING CHANGE THAT unless you know what you do
    //float rotationVelocity;
    //float targetAngle;
    //private void CalculateDirectionFromDirectionLook()
    //{
    //    targetAngle = Camera.main.transform.eulerAngles.y;

    //    // Smooth rotation and assign all necessary values
    //    inputAngle = Mathf.SmoothDampAngle(transform.parent.eulerAngles.y, targetAngle, ref rotationVelocity, rotationSmoothTime);
    //}

    //// Calculate rotation of player depending on target direction
    //private void CalculateDirectionFromTarget()
    //{
    //    // Calculate angle from target
    //    Vector3 targetDirection = new Vector3(targetToWatch.position.x - transform.parent.position.x, 0f, targetToWatch.position.z - transform.parent.position.z);
    //    float targetAngle = Mathf.Atan2(targetDirection.x, targetDirection.z) * Mathf.Rad2Deg;

    //    inputAngle = targetAngle;
    //}
}
