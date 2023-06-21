using UnityEngine;

public class RaceManager : MonoBehaviour
{
    public GameObject AICar;
    public AICarController AICarController;

    public bool raceStarted;
    public bool raceFinished;

    private void Start()
    {
        raceStarted = false;
        raceFinished = false;
    }


    public void StartRace()
    {
        if (raceStarted == false)
        {
            raceStarted = true;
            // Add any race-related behavior or logic here
            Debug.Log("Race against AI Car started!");
            AICarController.AIRaceAgainstPlayer();
        }
    }

    public void FinishRace()
    {
        if (raceStarted && !raceFinished)
        {
            raceFinished = true;
            // Add any race completion behavior or logic here
            Debug.Log("Race finished!");

            Destroy(AICar); // Destroy the AI car game object
        }
    }
}
