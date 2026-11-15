using UnityEngine;

public class TruckInteraction : MonoBehaviour
{
    public static TruckInteraction CurrentTruck;

    public GameObject driveButton;

    private void Start()
    {
        driveButton.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Entered trigger of " + gameObject.name);
            CurrentTruck = this;
            driveButton.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (CurrentTruck == this)
                CurrentTruck = null;

            driveButton.SetActive(false);
        }
    }

    public void DriveTruck()
    {
        VehicleManager.Instance.EnterVehicle(
            GetComponent<TruckController>()
        );

        driveButton.SetActive(false);
    }
}