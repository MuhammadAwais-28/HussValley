using UnityEngine;

public class MobileInput : MonoBehaviour
{
    public void RaceDown()
    {
        Debug.Log("Race Button Pressed");
        if (VehicleManager.CurrentTruck != null)
            VehicleManager.CurrentTruck.racePressed = true;
    }

    public void RaceUp()
    {
        if (VehicleManager.CurrentTruck != null)
            VehicleManager.CurrentTruck.racePressed = false;
    }

    public void LeftDown()
    {
        if (VehicleManager.CurrentTruck != null)
            VehicleManager.CurrentTruck.leftPressed = true;
    }

    public void LeftUp()
    {
        if (VehicleManager.CurrentTruck != null)
            VehicleManager.CurrentTruck.leftPressed = false;
    }

    public void RightDown()
    {
        if (VehicleManager.CurrentTruck != null)
            VehicleManager.CurrentTruck.rightPressed = true;
    }

    public void RightUp()
    {
        if (VehicleManager.CurrentTruck != null)
            VehicleManager.CurrentTruck.rightPressed = false;
    }

    public void BrakeDown()
    {
        if (VehicleManager.CurrentTruck != null)
            VehicleManager.CurrentTruck.brakePressed = true;
    }

    public void BrakeUp()
    {
        if (VehicleManager.CurrentTruck != null)
            VehicleManager.CurrentTruck.brakePressed = false;
    }
}