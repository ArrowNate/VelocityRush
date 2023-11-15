using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapTimeManager : MonoBehaviour
{
    [SerializeField] private GameObject minuteBox;
    [SerializeField] private GameObject secondBox;
    [SerializeField] private GameObject milliSecondBox;
    [SerializeField] private GameObject bestLapTimeBox;

    private static int _minuteCount;
    private static int _secondCount;
    private static float _milliSecondCount;
    private static string _milliDisplay;

    private static float _bestLapTime = float.MaxValue; // Initialize to a very large value

    // Expose properties for read-only access
    public static int MinuteCount => _minuteCount;
    public static int SecondCount => _secondCount;
    public static float MilliSecondCount => _milliSecondCount;
    public static string MilliDisplay => _milliDisplay;
    public static float BestLapTime => _bestLapTime;

    private void Update()
    {
        _milliSecondCount += Time.deltaTime * 10;
        _milliDisplay = _milliSecondCount.ToString("F0");
        milliSecondBox.GetComponent<Text>().text = "" + _milliDisplay;

        if (_milliSecondCount >= 10)
        {
            _milliSecondCount = 0;
            _secondCount += 1;
        }

        if (_secondCount <= 9)
        {
            secondBox.GetComponent<Text>().text = "0" + _secondCount + ".";
        }
        else
        {
            secondBox.GetComponent<Text>().text = "" + _secondCount + ".";
        }

        if (_secondCount >= 60)
        {
            _secondCount = 0;
            _minuteCount += 1;
        }

        if (_minuteCount <= 9)
        {
            minuteBox.GetComponent<Text>().text = "0" + _minuteCount + ":";
        }
        else
        {
            minuteBox.GetComponent<Text>().text = "" + _minuteCount + ":";
        }

        // Update the best lap time display
        bestLapTimeBox.GetComponent<Text>().text = "Best Lap: " + FormatTime(_bestLapTime);
    }

    // Reset lap time method
    public static void ResetLapTime()
    {
        _minuteCount = 0;
        _secondCount = 0;
        _milliSecondCount = 0;
    }

    // Update best lap time method
    public static void UpdateBestLapTime()
    {
        if (_milliSecondCount < _bestLapTime)
        {
            _bestLapTime = _milliSecondCount;
        }
    }

    // Helper method to format time for display
    private string FormatTime(float time)
    {
        int minutes = (int)(time / 60);
        int seconds = (int)(time % 60);
        int milliseconds = (int)((time * 100) % 100);

        return string.Format("{0:00}:{1:00}.{2:00}", minutes, seconds, milliseconds);
    }
}