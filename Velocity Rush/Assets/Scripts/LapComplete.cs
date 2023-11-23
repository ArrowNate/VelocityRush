using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapComplete : MonoBehaviour
{
    [SerializeField] private GameObject lapCompleteTrigger;
    [SerializeField] private GameObject halfLapTrigger;
    [SerializeField] private Text minuteDisplay;
    [SerializeField] private Text secondDisplay;
    [SerializeField] private Text millisecondDisplay;
    //[SerializeField] private Text bestLapTimeDisplay;

    private LapTimeManager lapTimeManager;

    private void OnTriggerEnter(Collider other)
    {
        if (lapTimeManager.SecondCount <= 9)
        {
            secondDisplay.text = "0" + lapTimeManager.SecondCount + ".";
        }
        else
        {
            secondDisplay.text = "" + lapTimeManager.SecondCount + ".";
        }

        if (lapTimeManager.MinuteCount <= 9)
        {
            minuteDisplay.text = "0" + lapTimeManager.MinuteCount + ".";
        }
        else
        {
            minuteDisplay.text = "" + lapTimeManager.MinuteCount + ".";
        }

        millisecondDisplay.text = lapTimeManager.MilliDisplay;

        // Update best lap time
        //lapTimeManager.UpdateBestLapTime();

        // Reset the lap time
        lapTimeManager.ResetLapTime();

        // Display best lap time
        //bestLapTimeDisplay.text = "Best Lap: " + lapTimeManager.BestLapTime.ToString("F0");

        halfLapTrigger.SetActive(true);
        lapCompleteTrigger.SetActive(false);
    }
}