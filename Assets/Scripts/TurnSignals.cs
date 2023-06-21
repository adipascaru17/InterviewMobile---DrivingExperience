using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TurnSignals : MonoBehaviour
{

    /*public GameObject blinkerLeft;
    public GameObject blinkerRight;*/
    public CarBlinkers carBlinkers;
    public BikeBlinkers bikeBlinkers;
    private bool isToggledRight = false;
    private bool isToggledLeft = false;
    private Coroutine toggleCoroutine;

    /*[HideInInspector]
    public bool leftBlinkers = false;
    [HideInInspector]
    public bool rightBlinkers = false;*/
    // Start is called before the first frame update
    void Start()
    {
        carBlinkers.blinkerLeft.SetActive(false);
        carBlinkers.blinkerRight.SetActive(false);
        bikeBlinkers.blinkerLeft.SetActive(false);
        bikeBlinkers.blinkerRight.SetActive(false);
    }

    void Update()
    {
       
    }


    public void HandleLeftButtonClicked()
    {
        StopCoroutine(ToggleRepeatedlyRight());
        carBlinkers.blinkerRight.SetActive(false);
        bikeBlinkers.blinkerRight.SetActive(false);
        if (toggleCoroutine != null)
        {

            StopCoroutine(toggleCoroutine);
            carBlinkers.blinkerLeft.SetActive(false);
            bikeBlinkers.blinkerLeft.SetActive(false);
            toggleCoroutine = null;

        }
        else
        {
            toggleCoroutine = StartCoroutine(ToggleRepeatedlyLeft());
        }
           
       
    }

     public void HandleRightButtonClicked()
    {
        StopCoroutine(ToggleRepeatedlyLeft());
        carBlinkers.blinkerLeft.SetActive(false);
        bikeBlinkers.blinkerLeft.SetActive(false);
        if (toggleCoroutine != null)
        {
            StopCoroutine(toggleCoroutine);
            carBlinkers.blinkerRight.SetActive(false);
            bikeBlinkers.blinkerRight.SetActive(false);
            toggleCoroutine = null;

        }
        else
        {
            toggleCoroutine = StartCoroutine(ToggleRepeatedlyRight());
        }

    }

    private IEnumerator ToggleRepeatedlyRight()
    {
        while (true)
        {
            isToggledRight = !isToggledRight;        
            carBlinkers.blinkerRight.SetActive(isToggledRight);
            bikeBlinkers.blinkerRight.SetActive(isToggledRight);
            yield return new WaitForSeconds(0.5f); // Wait for 1 second before toggling again
        }
    }

    private IEnumerator ToggleRepeatedlyLeft()
    {
        while (true)
        {
            isToggledLeft = !isToggledLeft;
            carBlinkers.blinkerLeft.SetActive(isToggledLeft);
            bikeBlinkers.blinkerLeft.SetActive(isToggledLeft);
            yield return new WaitForSeconds(0.5f); // Wait for 1 second before toggling again
        }
    }

    private void OnDestroy()
    {
        if (toggleCoroutine != null)
        {
            StopCoroutine(toggleCoroutine);
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
}
