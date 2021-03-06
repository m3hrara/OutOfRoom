using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementComponent : MonoBehaviour
{

    [SerializeField]
    float walkSpeed = 5;
    [SerializeField]
    float runSpeed = 10;
    [SerializeField]
    float jumpForce = 5;
    [SerializeField]
    float forceMagnitude;
    //components
    private PlayerController playerController;
    Rigidbody rigidbody;
    Animator playerAnimator;
    public GameObject followTarget;

    //references
    Vector2 inputVector = Vector2.zero;
    Vector3 moveDirection = Vector3.zero;
    Vector2 lookInput = Vector2.zero;

    public bool isPaused = false;

    public float aimSensitivity = 0.2f;

    //animator hashes
    public readonly int movementXHash = Animator.StringToHash("MovementX");
    public readonly int movementYHash = Animator.StringToHash("MovementY");
    public readonly int isJumpingHash = Animator.StringToHash("IsJumping");
    public readonly int isRunningHash = Animator.StringToHash("IsRunning");

    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        playerController = GetComponent<PlayerController>();
        isPaused = false;
    }

    void Update()
    {
        if(!isPaused)
        {
            //aiming/looking
            followTarget.transform.rotation *= Quaternion.AngleAxis(lookInput.x * aimSensitivity, Vector3.up);
            followTarget.transform.rotation *= Quaternion.AngleAxis(lookInput.y * aimSensitivity, Vector3.left);

            var angles = followTarget.transform.localEulerAngles;
            angles.z = 0;

            var angle = followTarget.transform.localEulerAngles.x;

            if (angle > 180 && angle < 300)
            {
                angles.x = 300;
            }
            else if (angle < 180 && angle > 70)
            {
                angles.x = 70;
            }

            followTarget.transform.localEulerAngles = angles;

            //rotate player rotation based on look
            transform.rotation = Quaternion.Euler(0, followTarget.transform.rotation.eulerAngles.y, 0);

            followTarget.transform.localEulerAngles = new Vector3(angles.x, 0, 0);

            //movement
            if (playerController.isJumping) return;
            if (!(inputVector.magnitude > 0)) moveDirection = Vector3.zero;

            moveDirection = transform.forward * inputVector.y + transform.right * inputVector.x;
            float currentSpeed = playerController.isRunning ? runSpeed : walkSpeed;

            Vector3 movementDirection = moveDirection * (currentSpeed * Time.deltaTime);

            transform.position += movementDirection;
        }

    }

    public void OnMovement(InputValue value)
    {
        inputVector = value.Get<Vector2>();
        playerAnimator.SetFloat(movementXHash, inputVector.x);
        playerAnimator.SetFloat(movementYHash, inputVector.y);
    }

    public void OnRun(InputValue value)
    {
        playerController.isRunning = value.isPressed;
        playerAnimator.SetBool(isRunningHash, playerController.isRunning);
    }

    public void OnJump(InputValue value)
    {
        if(playerController.isJumping)
        {
            return;
        }
        playerController.isJumping = value.isPressed;
        playerAnimator.SetBool(isJumpingHash, playerController.isJumping);
        rigidbody.AddForce((transform.up + moveDirection) * jumpForce, ForceMode.Impulse);
    }

    //public void OnAim(InputValue value)
    //{
    //    playerController.isAiming = value.isPressed;
    //}

    public void OnLook(InputValue value)
    {
        lookInput = value.Get<Vector2>();
        // if we aim up,down, adjust anims to have mask that properly animates aim
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !playerController.isJumping) return;

        playerController.isJumping = false;
        playerAnimator.SetBool(isJumpingHash, false);
        if(collision.gameObject.CompareTag("moveable"))
        {
            Rigidbody rb = collision.collider.attachedRigidbody;
            if(rb !=null)
            {
                Vector3 forceDir = collision.gameObject.transform.position - transform.position;
                forceDir.y = 0;
                forceDir.Normalize();
                rb.AddForceAtPosition(forceDir * forceMagnitude, transform.position, ForceMode.Impulse);
            }
        }
    }
}