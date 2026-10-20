using UnityEngine;

public class CameraController : MonoBehaviour
{
    public FixedTouchField touchField;
    public Transform playerBody;
    public float sensitivity = 2f;

    private float verticalRotation = 0f;

    void Update()
    {
        if (touchField != null)
        {
            // Horizontal rotation (yaw)
            playerBody.Rotate(Vector3.up * touchField.TouchDist.x * sensitivity);

            // Vertical rotation (pitch)
            verticalRotation -= touchField.TouchDist.y * sensitivity;
            verticalRotation = Mathf.Clamp(verticalRotation, -70f, 70f);

            transform.localEulerAngles = new Vector3(verticalRotation, 0f, 0f);
        }
    }
}
