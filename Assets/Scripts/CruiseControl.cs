using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CruiseControl : MonoBehaviour
{
    public GameObject carObject;
    public GameObject bikeObject;
    private CarControllerRemaster carController;
    private MotorcycleController bikeController;
    private bool cruiseControlEnabledCar;
    private bool cruiseControlEnabledBike;

    void Start()
    {
        carController = carObject.GetComponent<CarControllerRemaster>();
        cruiseControlEnabledCar = false;

        bikeController = bikeObject.GetComponent<MotorcycleController>();
        cruiseControlEnabledBike = false;
    }

    public void ToggleCruiseControlCar()
    {
        cruiseControlEnabledCar = !cruiseControlEnabledCar;

        if (cruiseControlEnabledCar)
        {
            carController.ActivateCruiseControl();
            Debug.Log("Cruise Control enabled");
        }
        else
        {
            carController.DeactivateCruiseControl();
            Debug.Log("Cruise Control disabled");
        }
    }

    public void ToggleCruiseControlBike()
    {
        cruiseControlEnabledBike = !cruiseControlEnabledBike;

        if (cruiseControlEnabledBike)
        {
            bikeController.ActivateCruiseControl();
            Debug.Log("Cruise Control enabled");
        }
        else
        {
            bikeController.DeactivateCruiseControl();
            Debug.Log("Cruise Control disabled");
        }
    }
}
