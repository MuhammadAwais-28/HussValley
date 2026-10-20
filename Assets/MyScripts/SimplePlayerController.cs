using UnityEngine;

public class SimplePlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    [Header("Joystick Reference (optional)")]
    public FixedJoystick joyStick; // leave empty if using keyboard

    private Rigidbody rb;
    private bool isGrounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        float horizontal = joyStick != null ? joyStick.Horizontal : Input.GetAxis("Horizontal");
        float vertical = joyStick != null ? joyStick.Vertical : Input.GetAxis("Vertical");

        // Movement relative to player orientation
        Vector3 moveDir = (transform.right * horizontal) + (transform.forward * vertical);
        Vector3 moveVelocity = moveDir.normalized * moveSpeed;

        rb.linearVelocity = new Vector3(moveVelocity.x, rb.linearVelocity.y, moveVelocity.z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    public void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
