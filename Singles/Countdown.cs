using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public string time;
    public Text counter;

    public System.TimeSpan GetTimeToNextDay(){
        var dateToday = System.DateTime.UtcNow;
        var dateTomorrow = System.DateTime.UtcNow.AddDays(1).Date;
        System.TimeSpan diff = dateTomorrow - dateToday;

        diff = new System.TimeSpan(diff.Days, diff.Hours, diff.Minutes, diff.Seconds);

        return diff;
    }

    void Update(){
        time = GetTimeToNextDay().ToString();
        counter.text = time;
    }

}
