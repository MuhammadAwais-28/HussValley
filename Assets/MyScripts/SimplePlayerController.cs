using UnityEngine;

public class SimplePlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 3f;
    public float rotationSpeed = 12f;

    [Header("References")]
    public FixedJoystick joyStick;
    public Transform cameraTransform;
    public Animator animator;                      // the Animator on your character model

    private Rigidbody rb;
    private static readonly int SpeedHash = Animator.StringToHash("Speed");

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        if (cameraTransform == null && Camera.main != null)
            cameraTransform = Camera.main.transform;

        if (animator == null)
            animator = GetComponentInChildren<Animator>();
    }

    private void FixedUpdate()
    {
        float horizontal = joyStick.Horizontal;
        float vertical = joyStick.Vertical;

        Vector3 camForward = cameraTransform.forward;
        camForward.y = 0f;
        camForward.Normalize();

        Vector3 camRight = cameraTransform.right;
        camRight.y = 0f;
        camRight.Normalize();

        Vector3 moveDirection = camForward * vertical + camRight * horizontal;
        bool moving = moveDirection.sqrMagnitude > 0.01f;

        if (moving)
        {
            Vector3 dir = moveDirection.normalized;

            rb.linearVelocity = new Vector3(
                dir.x * moveSpeed,
                rb.linearVelocity.y,
                dir.z * moveSpeed);

            Quaternion targetRot = Quaternion.LookRotation(dir, Vector3.up);
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRot, rotationSpeed * Time.fixedDeltaTime));
        }
        else
        {
            rb.linearVelocity = new Vector3(0f, rb.linearVelocity.y, 0f);
        }

        if (animator != null)
            animator.SetFloat(SpeedHash, moving ? 1f : 0f, 0.1f, Time.fixedDeltaTime);
    }

    // Called by RoundManager when the round ends
    private void OnDisable()
    {
        if (animator != null) animator.SetFloat(SpeedHash, 0f);
    }
}