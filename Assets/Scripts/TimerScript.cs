using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    public float timeLeft = 5;
    public static bool timerRunning = false;
    public static TimerScript instance;
    public void Start()
    {

    }
    void Update()
    {
        if (timerRunning)
        {
            if (timeLeft > 0)
            {
                timeLeft = timeLeft - Time.deltaTime;

            }
            else
            {
                Debug.Log("aika loppu");
                timeLeft = 0;
                timerRunning = false;
            }

        }
    }

    public void StartTimer()
    {
        timerRunning = true;

    }
}
