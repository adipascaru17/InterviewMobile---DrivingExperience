using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedDisplay : MonoBehaviour
{
    public GameObject carObject;
    public GameObject bikeObject;
    private CarControllerRemaster carController;
    private MotorcycleController bikeController;
    private Text speedText;

    private void Start()
    {
        carController = carObject.GetComponent<CarControllerRemaster>();
        bikeController = bikeObject.GetComponent<MotorcycleController>();
        speedText = GetComponent<Text>();
        
    }

    private void Update()
    {
        if (carObject.activeSelf) 
        { 
            int speedValue = Mathf.RoundToInt(carController.GetSpeed());
            // Update the displayed speed text with the current speed from the CarController script.
            speedText.text = "Speed: " + speedValue.ToString() + " km/h";
        }
        else if (bikeObject.activeSelf)
        {
            int speedValue = Mathf.RoundToInt(bikeController.GetSpeed());
            speedText.text = "Speed: " + speedValue.ToString() + " km/h";
        }
    }
}
