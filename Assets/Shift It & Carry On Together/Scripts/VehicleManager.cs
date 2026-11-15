using UnityEngine;

public class VehicleManager : MonoBehaviour
{
    public static VehicleManager Instance;

    public static TruckController CurrentTruck;

    [Header("Player")]
    public GameObject player;
    public Camera playerCamera;
    public GameObject joystickPanel;

    [Header("Vehicle")]
    public GameObject drivingPanel;

    private TruckController activeTruck;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        joystickPanel.SetActive(true);
        drivingPanel.SetActive(false);

        if (playerCamera != null)
            playerCamera.gameObject.SetActive(true);
    }

    public void EnterVehicle(TruckController truck)
    {
        Debug.Log("Entered: " + truck.name);
        activeTruck = truck;
        CurrentTruck = truck;

        player.SetActive(false);

        playerCamera.gameObject.SetActive(false);
        truck.vehicleCamera.gameObject.SetActive(true);

        joystickPanel.SetActive(false);
        drivingPanel.SetActive(true);
    }

    public void ExitVehicle()
    {
        if (activeTruck == null)
            return;

        activeTruck.vehicleCamera.gameObject.SetActive(false);

        player.SetActive(true);
        playerCamera.gameObject.SetActive(true);

        joystickPanel.SetActive(true);
        drivingPanel.SetActive(false);

        CurrentTruck = null;
        activeTruck = null;
    }
}