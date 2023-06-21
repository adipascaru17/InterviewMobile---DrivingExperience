using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameplay : MonoBehaviour
{
	public Vehicle vehicle { get; private set; }

   void Start()
    {
		vehicle = gameObject.GetComponent<Vehicle>();
        
    }
    public void TurnSignals(int dir) // -1 = left       1 = right
	{
		if (vehicle.leftBlinkers && dir == -1) // Left Blinker Off
		{
			vehicle.TurnSignals(0);
		}
		else if (vehicle.rightBlinkers && dir == 1) // Right Blinker Off
		{
			vehicle.TurnSignals(0);
		}
		else if (vehicle.leftBlinkers && dir == 1)
		{
			vehicle.TurnSignals(1);
		}
		else if (vehicle.rightBlinkers && dir == -1)
		{
			vehicle.TurnSignals(-1);
		}
		else if (!vehicle.rightBlinkers && !vehicle.leftBlinkers)
		{
			vehicle.TurnSignals(dir);
		}
	}
}
