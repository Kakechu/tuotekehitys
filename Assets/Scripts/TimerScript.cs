using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    public float timeLeft = 7;
    public float foodtimeLeft = 7;
    public static bool timerRunning = false;
    public static bool foodtimerRunning = false;
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
        //ruoka-ajastin
        if (foodtimerRunning)
        {
            if (foodtimeLeft > 0)
            {
                foodtimeLeft = foodtimeLeft - Time.deltaTime;

            }
            else
            {
                Debug.Log("ruoka-aika loppu");
                foodtimeLeft = 0;
                foodtimerRunning = false;
            }
        }



    }

    public void StartTimer()
    {
        timerRunning = true;
    }

    public void StartFoodTimer()
    {
        foodtimerRunning = true;
    }
}
