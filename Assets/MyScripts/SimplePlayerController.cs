using UnityEngine;

public class SimplePlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;

    [Header("Joystick Reference")]
    public FixedJoystick joyStick;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void FixedUpdate()
    {
        float horizontal = joyStick.Horizontal;
        float vertical = joyStick.Vertical;

        Vector3 moveDirection =
            transform.forward * vertical +
            transform.right * horizontal;

        Vector3 velocity = moveDirection.normalized * moveSpeed;

        rb.linearVelocity = new Vector3(
            velocity.x,
            rb.linearVelocity.y,
            velocity.z
        );
    }
}