using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightToggle : MonoBehaviour
{
    public Light sun;
    public float dayIntensity = 1f;
    public float nightIntensity = 0.1f;
    public Material nightSkyboxMaterial;
    public Material currentSkybox;

    private bool isDay = true;

    private void Start()
    {
        // Set the initial state based on the starting time of your scene
        SetDayState(isDay);
      
    }

    public void ToggleDayNight()
    {
        isDay = !isDay;
        SetDayState(isDay);
    }

    private void SetDayState(bool isDay)
    {
        if (isDay)
        {
            // Set day properties
            sun.intensity = dayIntensity;
            RenderSettings.skybox = currentSkybox;
        }
        else
        {
            // Set night properties
            sun.intensity = nightIntensity;
            RenderSettings.skybox = nightSkyboxMaterial;
        }
    }
}

