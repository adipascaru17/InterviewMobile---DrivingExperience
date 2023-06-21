using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControllerRemaster : MonoBehaviour
{
    public enum ControlMode
    {
        Keyboard,
        Buttons
    };

    public ControlMode controlMode;
    private Rigidbody playerRB;
    public WheelColliders colliders;
    public WheelTransform wheelTransform;
    public float accelerationInput;
    public float steeringInput;
    private bool isBreaking;
    private float currentbreakForce;

    public float brakeInput;
    public GameObject brakeLights;

    public float motorPower;
    public float brakePower;
    private float slipAngle;
    public float speed;
    private float cruiseControlSpeed;
    private bool isCruiseControlActive;
    public AnimationCurve steeringCurve;
   
    // Start is called before the first frame update
    void Start()
    {
        brakeLights.SetActive(false);
        playerRB = gameObject.GetComponent<Rigidbody>();
        
    }

   

    // Update is called once per frame
    void Update()
    {
        speed = playerRB.velocity.magnitude;
        CheckInput();
        Engine();
        ApplySteering();
        ApplyWheelMovement();
        ApplyBrake();

    }

    private void FixedUpdate()
    {
        if (isCruiseControlActive)
        {
            GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity.normalized * cruiseControlSpeed;
        }
    }

    public void MoveInput(float input)
    {
        accelerationInput = input;
    }

    public void SteerInput(float input)
    {
        steeringInput = input;
    }

    void CheckInput()
    {
        if(controlMode == ControlMode.Keyboard)
        {
            accelerationInput = Input.GetAxis("Vertical");
            steeringInput = Input.GetAxis("Horizontal");
            isBreaking = Input.GetKey(KeyCode.Space);
        }
        
        slipAngle = Vector3.Angle(transform.forward, playerRB.velocity-transform.forward); // angle between the direction on car and velocity
        if (slipAngle < 120f)
        {
            if (accelerationInput < 0)
            {
                brakeInput = Mathf.Abs(accelerationInput);
                brakeLights.SetActive(true);
                accelerationInput = 0;
                
            }

        }
        
        else
        {
            brakeLights.SetActive(false);
            brakeInput = 0;
        }

        if (isBreaking)
        {
            accelerationInput = 0;
            brakeInput = 1;
        }



    }

    void ApplyBrake()
    {
        
            colliders.FrontLeftCollider.brakeTorque = brakeInput * brakePower * 0.7f;  // 70% braking power on front wheels
            colliders.FrontRightCollider.brakeTorque = brakeInput * brakePower * 0.7f;
            colliders.BackRightCollider.brakeTorque = brakeInput * brakePower * 0.3f; //  30% braking power on back wheels
            colliders.BackLeftCollider.brakeTorque = brakeInput * brakePower * 0.3f;
     
    }

    void Engine()
    {
        colliders.BackRightCollider.motorTorque = motorPower * accelerationInput;
        colliders.BackLeftCollider.motorTorque = motorPower * accelerationInput;
    
    }

    void ApplySteering()
    {
        float steeringAngle = steeringInput * steeringCurve.Evaluate(speed);
        colliders.FrontRightCollider.steerAngle = steeringAngle;
        colliders.FrontLeftCollider.steerAngle = steeringAngle;
    }

    void ApplyWheelMovement()
    {
        UpdateWheel(colliders.FrontRightCollider, wheelTransform.FrontRightWheel);
        UpdateWheel(colliders.FrontLeftCollider, wheelTransform.FrontLeftWheel);
        UpdateWheel(colliders.BackRightCollider, wheelTransform.BackRightWheel);
        UpdateWheel(colliders.BackLeftCollider, wheelTransform.BackLeftWheel);
    }

    
    // making the wheels move 
    void UpdateWheel(WheelCollider coll, Transform wheelTransform)
    {
        Quaternion quat;
        Vector3 position;
        coll.GetWorldPose(out position, out quat); // the rotation and position of wheelColliders
        wheelTransform.transform.position = position;
        wheelTransform.transform.rotation = quat;
    }

    public void ActivateCruiseControl()
    {
        isCruiseControlActive = true;
        cruiseControlSpeed = GetComponent<Rigidbody>().velocity.magnitude;
        
    }

    public void DeactivateCruiseControl()
    {
        isCruiseControlActive = false;
    }

    public float GetSpeed()
    {
        // Return the current speed of the car.
        return GetComponent<Rigidbody>().velocity.magnitude * 3.6f; // Multiply by 3.6 to convert from m/s to km/h.
    }
}

[System.Serializable] // tell Unity to use this class as a Data Structure
public class WheelColliders
{
    public WheelCollider FrontRightCollider;
    public WheelCollider FrontLeftCollider;
    public WheelCollider BackRightCollider;
    public WheelCollider BackLeftCollider;
}

[System.Serializable]
public class WheelTransform
{
    public Transform FrontRightWheel;
    public Transform FrontLeftWheel;
    public Transform BackRightWheel;
    public Transform BackLeftWheel;
}



