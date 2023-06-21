using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarLights : MonoBehaviour
{
    public bool has_halos = false;
    public GameObject[] halos;

    public void TurnSignals(bool on)
    {
        if (has_halos)
        {
            for(int i=0; i < halos.Length; i++)
            {
                if (on)
                {
                    halos[i].SetActive(true);
                }
                else
                {
                    halos[i].SetActive(false); 
                }
            }
        }
    }
}
