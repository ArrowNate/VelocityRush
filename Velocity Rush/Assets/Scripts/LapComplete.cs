using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapComplete : MonoBehaviour
{
    [SerializeField] private GameObject lapCompleteTrigger;
    [SerializeField] private GameObject halfLapTrigger;
    [SerializeField] private GameObject minuteDisplay;
    [SerializeField] private GameObject secondDisplay;
    [SerializeField] private GameObject millisecondDisplay;
    [SerializeField] private GameObject bestLapTimeDisplay;

    private void OnTriggerEnter(Collider other)
    {
        if (LapTimeManager.SecondCount <= 9)
        {
            secondDisplay.GetComponent<Text>().text = "0" + LapTimeManager.SecondCount + ".";
        }
        else
        {
            secondDisplay.GetComponent<Text>().text = "" + LapTimeManager.SecondCount + ".";
        }

        if (LapTimeManager.MinuteCount <= 9)
        {
            minuteDisplay.GetComponent<Text>().text = "0" + LapTimeManager.MinuteCount + ".";
        }
        else
        {
            minuteDisplay.GetComponent<Text>().text = "" + LapTimeManager.MinuteCount + ".";
        }

        millisecondDisplay.GetComponent<Text>().text = LapTimeManager.MilliDisplay;

        // Update best lap time
        LapTimeManager.UpdateBestLapTime();

        // Reset the lap time
        LapTimeManager.ResetLapTime();

        // Display best lap time
        bestLapTimeDisplay.GetComponent<Text>().text = "Best Lap: " + LapTimeManager.BestLapTime.ToString("F0");

        halfLapTrigger.SetActive(true);
        lapCompleteTrigger.SetActive(false);
    }
}