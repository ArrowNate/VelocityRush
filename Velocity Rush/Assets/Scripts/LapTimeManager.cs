using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapTimeManager : MonoBehaviour
{
    [SerializeField] private GameObject minuteBox;
    [SerializeField] private GameObject secondBox;
    [SerializeField] private GameObject milliSecondBox;

    [SerializeField] private static int minuteCount;
    [SerializeField] private static int secondCount;
    [SerializeField] private static float milliSecondCount;
    [SerializeField] private static string milliDisplay;

    private void Update()
    {
        milliSecondCount += Time.deltaTime * 10;
        milliDisplay = milliSecondCount.ToString("F0");
        milliSecondBox.GetComponent<Text>().text = "" + milliDisplay;

        if (milliSecondCount >= 10)
        {
            milliSecondCount = 0;
            secondCount += 1;
        }

        if (secondCount <= 9)
        {
            secondBox.GetComponent<Text>().text = "0" + secondCount + ".";
        }
        else
        {
            secondBox.GetComponent<Text>().text = "" + secondCount + ".";
        }

        if (secondCount >= 60)
        {
            secondCount = 0;
            minuteCount += 1;
        }

        if (minuteCount <= 9)
        {
            minuteBox.GetComponent<Text>().text = "0" + minuteCount + ":";
        }
        else
        {
            minuteBox.GetComponent<Text>().text = "" + minuteCount + ":";
        }
    }
}