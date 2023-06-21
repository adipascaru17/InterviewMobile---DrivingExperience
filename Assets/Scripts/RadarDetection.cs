using UnityEngine;
using UnityEngine.UI;

public class RadarDetection : MonoBehaviour
{
    public GameObject carObject;
    public GameObject bikeObject;
    public float speedThreshold = 50f;
    public string warningMessage = "Speed limit is 50km/h";
    public float displayDuration = 2f;

    private Text warningText;
    private CarControllerRemaster carController;
    private MotorcycleController bikeController;
    private bool isDisplayingWarning;
    private float displayTimer;

    private void Start()
    {
        warningText = GameObject.Find("WarningText").GetComponent<Text>();
        carController = carObject.GetComponent<CarControllerRemaster>();
        bikeController = bikeObject.GetComponent<MotorcycleController>();
        warningText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == carObject || other.gameObject == bikeObject)
        {
            float currentCarSpeed = carController.GetSpeed();
            float currentBikeSpeed = bikeController.GetSpeed();

            if (currentCarSpeed > speedThreshold || currentBikeSpeed > speedThreshold)
            {
                warningText.text = warningMessage;
                warningText.gameObject.SetActive(true);
                isDisplayingWarning = true;
                displayTimer = 0f;
            }
            else
            {
                warningText.gameObject.SetActive(false);
            }
        }
    }

    private void Update()
    {
        if (isDisplayingWarning)
        {
            displayTimer += Time.deltaTime;

            if (displayTimer >= displayDuration)
            {
                warningText.gameObject.SetActive(false);
                isDisplayingWarning = false;
            }
        }
    }
}