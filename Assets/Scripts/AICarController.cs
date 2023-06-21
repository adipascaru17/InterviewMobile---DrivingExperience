using UnityEngine;

public class AICarController : MonoBehaviour
{
    public float acceleration = 10f;
    public float maxSpeed = 100f;
    public float maxAngularVelocity = 10f;
    public Transform targetCar;
    public Transform targetBike;
    public RaceManager raceManager;


    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        AIRaceAgainstPlayer();
    }

    public void AIRaceAgainstPlayer()
    {
        if (targetCar != null && targetBike != null && raceManager.raceStarted == true)
        {
            Vector3 forwardForce = transform.forward * acceleration;
            rb.AddForce(forwardForce, ForceMode.Acceleration);

            // Limit the AI car's speed to the maximum speed
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);

        }
       
    }
}
