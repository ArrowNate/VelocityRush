using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapTimeManager : MonoBehaviour
{
    [SerializeField] private Text minuteBox;
    [SerializeField] private Text secondBox;
    [SerializeField] private Text milliSecondBox;
    //[SerializeField] private Text bestLapTimeBox;

    private int _minuteCount;
    private int _secondCount;
    private float _milliSecondCount;
    private string _milliDisplay;

    //private float _bestLapTime = float.MaxValue; // Initialize to a very large value

    // Expose properties for read-only access
    public int MinuteCount => _minuteCount;
    public int SecondCount => _secondCount;
    public float MilliSecondCount => _milliSecondCount;
    public string MilliDisplay => _milliDisplay;
    //public float BestLapTime => _bestLapTime;

    private void Update()
    {
        _milliSecondCount += Time.deltaTime * 10;
        _milliDisplay = _milliSecondCount.ToString("F0");
        milliSecondBox.text = "" + _milliDisplay;

        if (_milliSecondCount >= 10)
        {
            _milliSecondCount = 0;
            _secondCount += 1;
        }

        if (_secondCount <= 9)
        {
            secondBox.text = "0" + _secondCount + ".";
        }
        else
        {
            secondBox.text = "" + _secondCount + ".";
        }

        if (_secondCount >= 60)
        {
            _secondCount = 0;
            _minuteCount += 1;
        }

        if (_minuteCount <= 9)
        {
            minuteBox.text = "0" + _minuteCount + ":";
        }
        else
        {
            minuteBox.text = "" + _minuteCount + ":";
        }

        // Update the best lap time display
        //bestLapTimeBox.text = "Best Lap: " + FormatTime(_bestLapTime);
    }

    // Reset lap time method
    public void ResetLapTime()
    {
        _minuteCount = 0;
        _secondCount = 0;
        _milliSecondCount = 0;
    }

    // Update best lap time method
    /*public void UpdateBestLapTime()
    {
        if (_milliSecondCount < _bestLapTime)
        {
            _bestLapTime = _milliSecondCount;
        }
    }*/

    // Helper method to format time for display
    private string FormatTime(float time)
    {
        int minutes = (int)(time / 60);
        int seconds = (int)(time % 60);
        int milliseconds = (int)((time * 100) % 100);

        return string.Format("{0:00}:{1:00}.{2:00}", minutes, seconds, milliseconds);
    }
}