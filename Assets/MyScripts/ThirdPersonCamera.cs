using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [Header("References")]
    public FixedTouchField touchField;
    public Transform target;                       // the Player

    [Header("Position")]
    public float distance = 1.5f;                  // camera distance behind the player
    public Vector3 pivotOffset = new Vector3(0f, 0.3f, 0f); // point the camera looks at, above the player's center

    [Header("Look Settings")]
    public float sensitivity = 0.15f;
    public float maxDeltaPerFrame = 80f;
    public float minPitch = -10f;
    public float maxPitch = 60f;
    public float startPitch = 20f;

    [Header("Collision")]
    public LayerMask collisionMask = ~0;           // untick the Player layer in the Inspector
    public float collisionRadius = 0.1f;

    private float yaw;
    private float pitch;

    private void Start()
    {
        pitch = startPitch;
        if (target != null) yaw = target.eulerAngles.y;
    }

    private void LateUpdate()
    {
        if (target == null) return;

        if (touchField != null)
        {
            Vector2 delta = Vector2.ClampMagnitude(touchField.TouchDist, maxDeltaPerFrame);
            touchField.TouchDist = Vector2.zero;

            yaw += delta.x * sensitivity;
            pitch -= delta.y * sensitivity;
            pitch = Mathf.Clamp(pitch, minPitch, maxPitch);
        }

        Quaternion rot = Quaternion.Euler(pitch, yaw, 0f);
        Vector3 pivot = target.position + pivotOffset;
        Vector3 backDir = rot * Vector3.back;

        // Pull the camera closer only for real walls (ignore the player and the chasers)
        float dist = distance;
        RaycastHit[] hits = Physics.SphereCastAll(pivot, collisionRadius, backDir, distance,
                                                  collisionMask, QueryTriggerInteraction.Ignore);
        foreach (RaycastHit h in hits)
        {
            if (h.collider.transform.IsChildOf(target)) continue;               // the player
            if (h.collider.GetComponentInParent<ChaserAI>() != null) continue;  // the chasers
            if (h.distance > 0f && h.distance < dist)
                dist = Mathf.Max(0.4f, h.distance);
        }

        transform.position = pivot + backDir * dist;
        transform.rotation = rot;
    }
}