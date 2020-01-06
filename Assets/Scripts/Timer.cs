using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public TimeSpan countdownTimer = new TimeSpan(0, 30, 0);
    [SerializeField] Text timer = null;

    private void Awake()
    {
        int length = FindObjectsOfType<Timer>().Length;
        if(length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        InvokeRepeating("ReduceTime", 0, 1);
    }

    private void ReduceTime()
    {
        countdownTimer = countdownTimer.Subtract(new TimeSpan(0, 0, 1));
        timer.text = countdownTimer.ToString();
    }
}
