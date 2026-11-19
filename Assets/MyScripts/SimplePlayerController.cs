using UnityEngine;
using UnityEngine.UI;

public class SimplePlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 0.8f;
    public float rotationSpeed = 12f;

    [Header("Sprint")]
    public Button sprintButton;
    public float sprintMultiplier = 1.8f;
    public float sprintDuration = 3f;
    public float sprintCooldown = 2f;
    [Tooltip("First sprint is always free. If ticked, every later sprint needs a rewarded ad.")]
    public bool requireAdForExtraSprint = false;

    [Header("Jump")]
    public Button jumpButton;
    public float jumpHeight = 0.6f;
    public float groundCheckExtra = 0.1f;
    [Tooltip("If ticked, every jump needs a rewarded ad.")]
    public bool requireAdForJump = false;

    [Header("References")]
    public FixedJoystick joyStick;
    public Transform cameraTransform;
    public Animator animator;

    private Rigidbody rb;
    private Collider col;
    private static readonly int SpeedHash = Animator.StringToHash("Speed");

    private bool jumpRequested;
    private bool sprinting;
    private float sprintEndTime;
    private float sprintReadyTime;
    private bool freeSprintAvailable = true;

    // Rewarded ad handling (callbacks are applied in Update, on the main thread)
    private enum PendingAction { None, Sprint, Jump }
    private PendingAction pendingAction = PendingAction.None;
    private bool adBusy;
    private bool adFinished;
    private bool rewardGranted;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
        rb.freezeRotation = true;

        if (cameraTransform == null && Camera.main != null)
            cameraTransform = Camera.main.transform;

        if (animator == null)
            animator = GetComponentInChildren<Animator>();

        if (sprintButton != null) sprintButton.onClick.AddListener(OnSprintPressed);
        if (jumpButton != null) jumpButton.onClick.AddListener(OnJumpPressed);
    }

    private void OnDestroy()
    {
        if (sprintButton != null) sprintButton.onClick.RemoveListener(OnSprintPressed);
        if (jumpButton != null) jumpButton.onClick.RemoveListener(OnJumpPressed);
    }

    private void Update()
    {
        // Finish ad flow
        if (adFinished)
        {
            adFinished = false;
            adBusy = false;

            if (rewardGranted)
            {
                rewardGranted = false;
                if (pendingAction == PendingAction.Sprint) StartSprint();
                else if (pendingAction == PendingAction.Jump) jumpRequested = true;
            }
            pendingAction = PendingAction.None;
        }

        // End sprint
        if (sprinting && Time.time >= sprintEndTime)
        {
            sprinting = false;
            sprintReadyTime = Time.time + sprintCooldown;
            if (animator != null) animator.speed = 1f;
        }
    }

    // ---------- Buttons ----------

    private void OnSprintPressed()
    {
        if (sprinting || adBusy || Time.time < sprintReadyTime) return;

        if (freeSprintAvailable)
        {
            freeSprintAvailable = false;
            StartSprint();
            return;
        }

        if (!requireAdForExtraSprint) { StartSprint(); return; }

        RequestRewardedAd(PendingAction.Sprint);
    }

    private void OnJumpPressed()
    {
        if (adBusy || !IsGrounded()) return;

        if (!requireAdForJump) { jumpRequested = true; return; }

        RequestRewardedAd(PendingAction.Jump);
    }

    private void StartSprint()
    {
        sprinting = true;
        sprintEndTime = Time.time + sprintDuration;
        if (animator != null) animator.speed = 1.5f;
    }

    private void RequestRewardedAd(PendingAction action)
    {
        var ads = AdsManager.Instance;

        // No ads available (editor, blocked by config): grant directly
        if (ads == null || ads.BlockAllAds || ads.BlockRewardedAd)
        {
            if (action == PendingAction.Sprint) StartSprint();
            else jumpRequested = true;
            return;
        }

        adBusy = true;
        pendingAction = action;
        rewardGranted = false;

        ads.ShowRewarded(
            () => { adFinished = true; },        // ad closed / failed
            () => { rewardGranted = true; }      // reward earned
        );
    }

    // ---------- Physics ----------

    private bool IsGrounded()
    {
        if (col == null) return true;
        Bounds b = col.bounds;
        return Physics.Raycast(b.center, Vector3.down, b.extents.y + groundCheckExtra,
                               ~0, QueryTriggerInteraction.Ignore);
    }

    private void FixedUpdate()
    {
        if (joyStick == null || cameraTransform == null) return;

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

        float speed = moveSpeed * (sprinting ? sprintMultiplier : 1f);
        float yVel = rb.linearVelocity.y;

        if (moving)
        {
            Vector3 dir = moveDirection.normalized;
            rb.linearVelocity = new Vector3(dir.x * speed, yVel, dir.z * speed);

            Quaternion targetRot = Quaternion.LookRotation(dir, Vector3.up);
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRot, rotationSpeed * Time.fixedDeltaTime));
        }
        else
        {
            rb.linearVelocity = new Vector3(0f, yVel, 0f);
        }

        if (jumpRequested)
        {
            jumpRequested = false;
            if (IsGrounded())
            {
                float v = Mathf.Sqrt(2f * Mathf.Abs(Physics.gravity.y) * jumpHeight);
                rb.linearVelocity = new Vector3(rb.linearVelocity.x, v, rb.linearVelocity.z);
            }
        }

        if (animator != null)
            animator.SetFloat(SpeedHash, moving ? 1f : 0f, 0.1f, Time.fixedDeltaTime);
    }

    private void OnDisable()
    {
        sprinting = false;
        if (animator != null)
        {
            animator.speed = 1f;
            animator.SetFloat(SpeedHash, 0f);
        }
    }
}