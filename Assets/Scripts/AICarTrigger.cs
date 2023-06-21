using UnityEngine;

public class AICarTrigger : MonoBehaviour
{
    public GameObject playerCar;
    public RaceManager raceManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == playerCar)
        {
            raceManager.StartRace(); // Call the race start method in the RaceManager
        }
    }
}