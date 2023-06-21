using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadLightsBehaviour : MonoBehaviour
{
    private Light carLightL;
    private Light carLightR;
    private Light bikeLightL;
    private Light bikeLightR;
    public GameObject carHaloLHigh;
    public GameObject carHaloRHigh;
    public GameObject bikeHaloLHigh;
    public GameObject bikeHaloRHigh;
    public GameObject carHaloR;
    public GameObject carHaloL;
    public GameObject bikeHaloR;
    public GameObject bikeHaloL;
    public CarHeadlights carheadlights;
    public BikeHeadlights bikeHeadlights;
    private bool isToggledLow = false;
    private bool isToggledHigh = false;
    
    private bool checkActive;
    // Start is called before the first frame update
    void Start()
    {
        carHaloLHigh.SetActive(false);
        carHaloRHigh.SetActive(false);
        bikeHaloLHigh.SetActive(false);
        bikeHaloRHigh.SetActive(false);

        bikeHaloR.SetActive(false);
        bikeHaloL.SetActive(false);

        carHaloR.SetActive(false);
        carHaloL.SetActive(false);

        carheadlights.headlightL.SetActive(false);
        carheadlights.headlightR.SetActive(false);
        bikeHeadlights.headlightL.SetActive(false);
        bikeHeadlights.headlightR.SetActive(false);
        carLightR = carheadlights.headlightR.GetComponent<Light>();
        carLightL = carheadlights.headlightL.GetComponent<Light>();

        bikeLightR = bikeHeadlights.headlightR.GetComponent<Light>();
        bikeLightL = bikeHeadlights.headlightL.GetComponent<Light>();

        
    }


    public void HandleButtonHeadlightsOnClick()
    {
        if (isToggledLow)
        {
            carheadlights.headlightL.SetActive(false);
            carheadlights.headlightR.SetActive(false);
            bikeHeadlights.headlightL.SetActive(false);
            bikeHeadlights.headlightR.SetActive(false);
            bikeHaloR.SetActive(false);
            bikeHaloL.SetActive(false);
            carHaloR.SetActive(false);
            carHaloL.SetActive(false);
            isToggledLow = false;
        }
        else 
        {
            carheadlights.headlightL.SetActive(true);
            carheadlights.headlightR.SetActive(true);
            bikeHeadlights.headlightL.SetActive(true);
            bikeHeadlights.headlightR.SetActive(true);
            bikeHaloR.SetActive(true);
            bikeHaloL.SetActive(true);
            carHaloR.SetActive(true);
            carHaloL.SetActive(true);
            isToggledLow = !isToggledLow;
        }

    }

    public void HandleButtonHighBeamOnClick()
    {
        if (carheadlights.headlightL.activeSelf || bikeHeadlights.headlightL.activeSelf)
        {
            IncreaseLights();
        }

    }

    public void IncreaseLights()
    {
        if (!isToggledHigh)
        {
            carLightL.intensity += 30;
            carLightR.intensity += 30;
            bikeLightL.intensity += 30;
            bikeLightR.intensity += 30;
            carHaloLHigh.SetActive(true);
            carHaloRHigh.SetActive(true);
            bikeHaloLHigh.SetActive(true);
            bikeHaloRHigh.SetActive(true);
            isToggledHigh = true;

        }
        else
        {
            carLightL.intensity -= 30;
            carLightR.intensity -= 30;
            bikeLightL.intensity -= 30;
            bikeLightR.intensity -= 30;
            carHaloLHigh.SetActive(false);
            carHaloRHigh.SetActive(false);
            bikeHaloLHigh.SetActive(false);
            bikeHaloRHigh.SetActive(false);
            isToggledHigh = false;
        }

    }
}

[System.Serializable]
public class CarHeadlights
{
    public GameObject headlightR;
    public GameObject headlightL;
}

[System.Serializable]
public class BikeHeadlights
{
    public GameObject headlightR;
    public GameObject headlightL;
}
