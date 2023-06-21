using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchVehicles : MonoBehaviour
{
    public CameraFollowNew cameraController;
    public GameObject car;
    public GameObject motorcycle;
    public GameObject carTransform; 
    public GameObject motorcycleTransform;
    // Start is called before the first frame update
    void Start()
    {
        car.SetActive(true);
        motorcycle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleButtonClicked()
    {
        if (motorcycle.activeSelf)
        {
            motorcycle.SetActive(false);
            car.SetActive(true);
            OnSwitchCameraPlayerButtonClick();


        }
        else 
        {
            car.SetActive(false);
            motorcycle.SetActive(true);
            OnSwitchCameraPlayerButtonClick();
            
        }
    }

    public void OnSwitchCameraPlayerButtonClick()
    {
        if (cameraController.Player == carTransform)
        {
            cameraController.ChangePlayer(motorcycleTransform);
        }
        else
        {
            cameraController.ChangePlayer(carTransform);
        }
    }
}
