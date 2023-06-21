using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vehicle : MonoBehaviour
{
	public MainGameplay main { get; set; }


	public CarLights[] blinkers_left;
	public CarLights[] blinkers_right;
	

	[HideInInspector]
	public bool leftBlinkers = false;
	[HideInInspector]
	public bool rightBlinkers = false;

	private bool _halosEnabled = true;


    public void TurnSignals(int dir) // -1 = left       1 = right
	{

		if (dir == -1)
		{
			Blinkers(1, false);
			leftBlinkers = true;
			rightBlinkers = false;
		}
		else if (dir == 0)
		{
			Blinkers(0, false);
			leftBlinkers = false;
			rightBlinkers = false;
		}
		else if (dir == 1)
		{
			Blinkers(-1, false);
			rightBlinkers = true;
			leftBlinkers = false;
			
		}
	}

	public void Blinkers(int dir, bool b)
	{
		if (dir == -1)
		{
			ChangeLightsStatus(blinkers_left, b && _halosEnabled);
		}
		else if (dir == 1)
		{
			ChangeLightsStatus(blinkers_right, b && _halosEnabled);
		
		}
		else if (dir == 0)
		{

			ChangeLightsStatus(blinkers_right, false);
			ChangeLightsStatus(blinkers_left, false);
			leftBlinkers = false;
			rightBlinkers = false;
		}
	}
	public static void ChangeLightsStatus(CarLights[] vehicleLights, bool value)
	{
		if (vehicleLights != null)
		{
			for (int i = 0; i < vehicleLights.Length; i++)
			{
				vehicleLights[i].TurnSignals(value);
			}
		}
	}
}
