using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    public Text countdownText;

    private void Start()
    {
        /*StartCoroutine(StartCountdown());*/
    }

    public IEnumerator StartCountdown()
    {
        countdownText.text = "5";
        yield return new WaitForSeconds(1f);

        countdownText.text = "4";
        yield return new WaitForSeconds(1f);

        countdownText.text = "3";
        yield return new WaitForSeconds(1f);

        countdownText.text = "2";
        yield return new WaitForSeconds(1f);

        countdownText.text = "1";
        yield return new WaitForSeconds(1f);

        countdownText.text = "GO!";
        yield return new WaitForSeconds(1f);

        countdownText.gameObject.SetActive(false);
        // Start the race logic here
    }
}
