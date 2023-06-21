using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrakeLights : MonoBehaviour
{

    public GameObject rearBrakesLights;
    CarControllerRemaster carControllerRemaster;
    // Start is called before the first frame update
    void Start()
    {
        rearBrakesLights.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
