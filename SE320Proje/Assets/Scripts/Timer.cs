using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    public Text ClockText;
    public static int IntSecond;
    public static float second = 0f;
    public static int minute = 0;

    private void Update()
    {
        if (second >= 60.0)
        {
            minute += 1;
            second = 0;
        }

        second += Time.deltaTime;
        IntSecond = Convert.ToInt32(second);
        ClockText.text = minute + ":" + IntSecond.ToString();
    }
}