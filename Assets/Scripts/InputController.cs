using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputController : MonoBehaviour
{
    public MainGameplay main;
	public bool blink_left = false;
	public bool blink_right = false;


	private void OnPress(bool isDown)
    {

		if (!gameObject.activeInHierarchy)
		{
			return;
		}

		if (blink_left) // Turn Signal Left
		{
			if (isDown)
			{
				main.TurnSignals(-1);
			}
			
		}
		else if (blink_right) // Turn Signal Right
		{
			if (isDown)
			{
				main.TurnSignals(1);
			}
		
		}
	}
}
