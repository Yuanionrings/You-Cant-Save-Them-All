using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private static float timer;
    private Text time;

    void Start()
    {
        timer = 60;
        time = GetComponent<Text>();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if ((int)(timer % 60) < 10)
        {
            time.text = "Time Left: " + (int)((timer - (timer % 60)) / 60) + ":0" + (int)(timer % 60);
        }
        else
        {
            time.text = "Time Left: " + (int)((timer - (timer % 60)) / 60) + ":" + (int)(timer % 60);
        }
    }

    public static void AddTime(float extraTime)
    {
        timer += extraTime;
    }

    public static void SubtractTime(float lossTime)
    {
        timer -= lossTime;
    }

    public static float getTime()
    {
        return timer;
    }
}
