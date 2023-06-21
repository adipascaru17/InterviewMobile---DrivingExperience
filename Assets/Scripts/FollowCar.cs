using UnityEngine;

public class FollowCar : MonoBehaviour
{
    public float speed = 10f;
    public float turnSpeed = 50f;

    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        
        rb.AddForce(transform.forward * movement.z * speed);
        rb.AddTorque(transform.up * moveHorizontal * turnSpeed);
    }
}