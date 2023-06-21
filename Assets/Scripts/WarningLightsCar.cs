using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningLightsCar : MonoBehaviour
{

    public CarBlinkers carBlinkers;
    public BikeBlinkers bikeBlinkers;
    private bool isToggled= false;
    private Coroutine toggleCoroutine;

    public void HandleWarningLightsButtonClicked()
    {
        if(toggleCoroutine != null)
        {
            StopCoroutine(toggleCoroutine);
            carBlinkers.blinkerLeft.SetActive(false);
            bikeBlinkers.blinkerLeft.SetActive(false);
            carBlinkers.blinkerRight.SetActive(false);
            bikeBlinkers.blinkerRight.SetActive(false);
            toggleCoroutine = null;
        }
        else
        {
            toggleCoroutine = StartCoroutine(ToggleLightsRepeatedly());
        }

    }

    private IEnumerator ToggleLightsRepeatedly()
    {
        while (true)
        {
            isToggled = !isToggled;
            carBlinkers.blinkerLeft.SetActive(isToggled);
            bikeBlinkers.blinkerLeft.SetActive(isToggled);
            carBlinkers.blinkerRight.SetActive(isToggled);
            bikeBlinkers.blinkerRight.SetActive(isToggled);
            yield return new WaitForSeconds(0.5f); // Wait for 1 second before toggling again
        }
    }

}
[System.Serializable]
public class CarBlinkers
{
    public GameObject blinkerLeft;
    public GameObject blinkerRight;
}

[System.Serializable]
public class BikeBlinkers
{
    public GameObject blinkerLeft;
    public GameObject blinkerRight;
}
