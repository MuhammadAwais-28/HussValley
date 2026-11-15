using UnityEngine;

public class DriveButtonHandler : MonoBehaviour
{
    public void EnterSelectedTruck()
    {
        Debug.Log("CurrentTruck = " + TruckInteraction.CurrentTruck);

        if (TruckInteraction.CurrentTruck != null)
        {
            TruckInteraction.CurrentTruck.DriveTruck();
        }
    }
}