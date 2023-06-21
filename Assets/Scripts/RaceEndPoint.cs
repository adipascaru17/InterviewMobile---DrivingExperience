using UnityEngine;

public class RaceEndPoint : MonoBehaviour
{
    public RaceManager raceManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerCar") || other.CompareTag("AICar") || other.CompareTag("PlayerBike"))
        {
            raceManager.FinishRace();
        }
    }
}
