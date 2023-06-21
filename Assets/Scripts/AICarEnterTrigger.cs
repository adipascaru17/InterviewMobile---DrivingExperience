using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AICarEnterTrigger : MonoBehaviour
{
    public GameObject playerCar;
    public GameObject playerBike;
    public Transform endPoint;
    public RaceManager raceManager;
    public Text countdownText;
    public GameObject raceTrigger;

    private bool raceStarted;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == playerCar || other.gameObject == playerBike)
        {
            countdownText.gameObject.SetActive(true);
            StartCoroutine(StartCountdown());          

        }
    }


    private void Update()
    {
        if (raceStarted && endPoint != null)
        {
            // Check if the player's car has reached the end point
            float distanceToEndCar = Vector3.Distance(playerCar.transform.position, endPoint.position);
            float distanceToEndBike = Vector3.Distance(playerBike.transform.position, endPoint.position);
            if (distanceToEndCar <= 1f || distanceToEndBike <= 1f) // Adjust the threshold as needed
            {
                raceManager.FinishRace();
            }
        }
    }

    private IEnumerator StartCountdown()
    {
        countdownText.text = "5";
        yield return new WaitForSeconds(1f);

        countdownText.text = "4";
        yield return new WaitForSeconds(1f);

        countdownText.text = "3";
        yield return new WaitForSeconds(1f);

        countdownText.text = "2";
        yield return new WaitForSeconds(1f);

        countdownText.text = "1";
        yield return new WaitForSeconds(1f);

        countdownText.text = "GO!";
        yield return new WaitForSeconds(1f);

        countdownText.gameObject.SetActive(false);
        // Start the race logic here
        raceManager.StartRace();
        Destroy(raceTrigger);
        
    }
}