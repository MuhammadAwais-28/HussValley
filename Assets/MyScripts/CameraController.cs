using UnityEngine;

public class CameraController : MonoBehaviour
{
    public FixedTouchField touchField;
    public Transform playerBody;

    [Header("Look Settings")]
    public float sensitivity = 0.15f;
    public float maxDeltaPerFrame = 80f;

    private float verticalRotation = 0f;

    private void Update()
    {
        if (touchField == null || playerBody == null)
            return;

        // Read touch delta and consume it immediately
        Vector2 delta = Vector2.ClampMagnitude(
            touchField.TouchDist,
            maxDeltaPerFrame);

        touchField.TouchDist = Vector2.zero;

        float touchX = delta.x * sensitivity;
        float touchY = delta.y * sensitivity;

        // Vertical camera rotation
        verticalRotation -= touchY;
        verticalRotation = Mathf.Clamp(verticalRotation, -80f, 80f);

        transform.localRotation = Quaternion.Euler(
            verticalRotation,
            0f,
            0f);

        // Horizontal player rotation
        playerBody.Rotate(Vector3.up * touchX);
    }
}