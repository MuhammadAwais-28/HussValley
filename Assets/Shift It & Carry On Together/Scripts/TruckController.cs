using UnityEngine;

public class TruckController : MonoBehaviour
{
    public Camera vehicleCamera;

    [Header("Audio")]
    public AudioSource engineAudio;

    [HideInInspector] public bool racePressed;
    [HideInInspector] public bool brakePressed;
    [HideInInspector] public bool leftPressed;
    [HideInInspector] public bool rightPressed;

    [Header("Truck Settings")]
    public float moveSpeed = 10f;
    public float reverseSpeed = 5f;
    public float turnSpeed = 60f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (vehicleCamera != null)
            vehicleCamera.gameObject.SetActive(false);

        if (engineAudio != null)
        {
            engineAudio.loop = true;
            engineAudio.Stop();
        }
    }

    private void FixedUpdate()
    {
        if (VehicleManager.CurrentTruck != this)
            return;

        bool isMoving = false;

        // Forward
        if (racePressed)
        {
            isMoving = true;

            rb.MovePosition(
                rb.position +
                transform.forward * moveSpeed * Time.fixedDeltaTime
            );
        }

        // Reverse
        if (brakePressed)
        {
            isMoving = true;

            rb.MovePosition(
                rb.position -
                transform.forward * reverseSpeed * Time.fixedDeltaTime
            );
        }

        // Play/Stop Engine Sound
        if (engineAudio != null)
        {
            if ((racePressed || brakePressed) && !engineAudio.isPlaying)
            {
                engineAudio.Play();
            }
            else if (!racePressed && !brakePressed && engineAudio.isPlaying)
            {
                engineAudio.Stop();
            }
        }

        // Steering only while moving
        if (isMoving)
        {
            if (leftPressed)
            {
                rb.MoveRotation(
                    rb.rotation *
                    Quaternion.Euler(0, -turnSpeed * Time.fixedDeltaTime, 0)
                );
            }

            if (rightPressed)
            {
                rb.MoveRotation(
                    rb.rotation *
                    Quaternion.Euler(0, turnSpeed * Time.fixedDeltaTime, 0)
                );
            }
        }
    }
}